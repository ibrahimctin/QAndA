using MediatR;
using QAndA.Domain.Application.Contracts.Identity;
using QAndA.Domain.Application.Features.Answers.Requests;
using QAndA.Infrastructure;

namespace QAndA.Domain.Application.Features.Answers.Handlers
{
    public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommand, bool>
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUser;

        public CreateAnswerCommandHandler(AppDbContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public Task<bool> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
