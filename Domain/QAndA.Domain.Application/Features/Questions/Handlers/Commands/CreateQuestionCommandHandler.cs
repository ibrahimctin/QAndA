using AutoMapper;
using MediatR;
using QAndA.Domain.Application.Features.Questions.Requests.Commands;
using QAndA.Infrastructure;

namespace QAndA.Domain.Application.Features.Questions.Handlers.Commands
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext 
        public Task<bool> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
