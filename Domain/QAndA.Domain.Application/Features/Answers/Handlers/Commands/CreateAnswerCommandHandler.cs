using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QAndA.Domain.Application.Contracts.Identity;
using QAndA.Domain.Application.DTOs.Questions.ResponseDtos;
using QAndA.Domain.Application.Features.Answers.Requests.Commands;
using QAndA.Domain.Application.Helpers.Results;
using QAndA.Domain.Entities;
using QAndA.Domain.Entities.IdentityEntities;
using QAndA.Infrastructure;

namespace QAndA.Domain.Application.Features.Answers.Handlers.Commands
{
    public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommand, Result>
    {
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly AppDbContext _context;

        public CreateAnswerCommandHandler(IMapper mapper, ICurrentUserService currentUserService, AppDbContext context)
        {
            _mapper = mapper;
            _currentUserService = currentUserService;
            _context = context;
        }

        public async Task<Result> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
        {
            var answerPayload = _mapper.Map<Answer>(request.CreateAnswerRequest);
            answerPayload.Question = await GetQuestion(request.QuestionId);
            if(answerPayload is not null)
            {
                await _context.AddAsync(answerPayload);
                await _context.SaveChangesAsync();
            }


            return answerPayload is null ? Result.Failed("Not Found") : Result.SuccessFul();
           
        }


        #region Private Methods (Queries)

        private async Task<Question> GetQuestion(string id) => await _context.Questions.FirstOrDefaultAsync(x => x.Id == id);
        private async Task<AppUser> CurrentUser() => await _currentUserService.GetCurrentUser();
        #endregion
    }
}
