using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QAndA.Domain.Application.Features.Answers.Requests.Commands;
using QAndA.Domain.Application.Helpers.Results;
using QAndA.Domain.Entities;
using QAndA.Domain.Entities.IdentityEntities;
using QAndA.Infrastructure;
using QAndA.Infrastructure.Extensions;

namespace QAndA.Domain.Application.Features.Answers.Handlers.Commands
{
    public class UpdateAnswerCommandHandler : IRequestHandler<UpdateAnswerCommand, Result>
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public UpdateAnswerCommandHandler(IMapper mapper, AppDbContext context, ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<Result> Handle(UpdateAnswerCommand request, CancellationToken cancellationToken)
        {
            var answerFromDb = await GetAswer(request.Id);
            if (answerFromDb is null)
            {
                return Result.Failed("There is no answer Whit this id");
            }

            var answerPayload = _mapper.Map(request.UpdateAnswerRequest,answerFromDb);

            answerPayload.User = _mapper.Map<AppUser>( await GetCurrentUser());

            if (answerPayload is not null)
            {
                _context.Update(answerPayload);
                await _context.SaveChangesAsync();

                return Result.SuccessFul();
            }

            return Result.Failed("Failed To Update");

        }

        #region Queries
       
        private async Task<Answer> GetAswer(string id) => await _context.Answers.FirstOrDefaultAsync(ğ => ğ.Id == id);
        private async Task<AppUser> GetCurrentUser()=> await _currentUserService.GetCurrentUser();
        #endregion
    }
}   
