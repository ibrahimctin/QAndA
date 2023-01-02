using AutoMapper;
using MediatR;
using QAndA.Domain.Application.Contracts.Identity;
using QAndA.Domain.Application.Features.Questions.Requests.Commands;
using QAndA.Domain.Entities;
using QAndA.Infrastructure;

namespace QAndA.Domain.Application.Features.Questions.Handlers.Commands
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUser;

        public CreateQuestionCommandHandler(IMapper mapper, AppDbContext context, ICurrentUserService currentUser)
        {
            _mapper = mapper;
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var questionPayload = _mapper.Map<Question>(request.CreateQuestionRequest);

            request.UserId = await GetCurrentUser(questionPayload.UserId);

            if (questionPayload is not null)
            {
                await _context.Questions.AddAsync(questionPayload);
                await _context.SaveChangesAsync();
            }

            return questionPayload is null ? throw new Exception() : true;


        }


        #region CurentUser

       private async Task<string> GetCurrentUser(string userId) => await _currentUser.GetCurrentUserIdAsync();
        


        #endregion
    }
}
