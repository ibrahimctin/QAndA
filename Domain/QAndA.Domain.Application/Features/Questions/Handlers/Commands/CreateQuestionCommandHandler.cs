using AutoMapper;
using MediatR;
using QAndA.Domain.Application.Contracts.Identity;
using QAndA.Domain.Application.DTOs.AppUsers.ResponseDtos;
using QAndA.Domain.Application.Features.Questions.Requests.Commands;
using QAndA.Domain.Application.Helpers.Results;
using QAndA.Domain.Entities;
using QAndA.Domain.Entities.IdentityEntities;
using QAndA.Infrastructure;

namespace QAndA.Domain.Application.Features.Questions.Handlers.Commands
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, Result>
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUser;
        private readonly IMapper _mapper;

        public CreateQuestionCommandHandler(AppDbContext context, ICurrentUserService currentUser, IMapper mapper)
        {
            _context = context;
            _currentUser = currentUser;
            _mapper = mapper;
        }

        public async Task<Result> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            
             _mapper.Map<AppUser>(await CurrentUser());
            var questionPayload = _mapper.Map<Question>(request.CreateQuestionRequest);
            questionPayload.UserId = await _currentUser.GetCurrentUserIdAsync();
         

            if (questionPayload is not null)
            {
                await _context.AddAsync(questionPayload);
                await _context.SaveChangesAsync();
            }

            return questionPayload is null ? Result.Failed(message: "Failed To Create") : Result.SuccessFul();

        }


        #region CurrentUser
        private async Task<AppUser> CurrentUser() => await _currentUser.GetCurrentUser();



        #endregion
    }
}
