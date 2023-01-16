using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QAndA.Domain.Application.Features.Questions.Requests.Commands;
using QAndA.Domain.Application.Helpers.Results;
using QAndA.Domain.Entities;
using QAndA.Domain.Entities.IdentityEntities;
using QAndA.Infrastructure;
using QAndA.Infrastructure.Extensions;

namespace QAndA.Domain.Application.Features.Questions.Handlers.Commands
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, Result>
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUser;

        public UpdateQuestionCommandHandler(IMapper mapper, AppDbContext context, ICurrentUserService currentUser)
        {
            _mapper = mapper;
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<Result> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {

            var questionFromDb = await GetQuestion(request.Id);
            var questionPayload = _mapper.Map(request.UpdateQuestionRequest, questionFromDb);


            if (questionFromDb is null)
            {
                return Result.Failed("There is no question Whit this Id");
            }

            questionFromDb.User = await CurrentUser();
            questionPayload.User = _mapper.Map<AppUser>(questionFromDb.User);
            if (questionPayload is not null)
            {
                _context.Update(questionPayload);
                await _context.SaveChangesAsync();

                return Result.SuccessFul();
            }

            return Result.Failed("Failed to Update Question");


        }

        #region Queries

        private async Task<Question> GetQuestion(string id) => await _context.Questions.FirstOrDefaultAsync(ğ => ğ.Id == id);
        private async Task<AppUser> CurrentUser() => await _currentUser.GetCurrentUser();

        #endregion
    }
}
