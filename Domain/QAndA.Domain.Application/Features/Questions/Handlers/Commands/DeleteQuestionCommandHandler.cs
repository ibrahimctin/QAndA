using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QAndA.Domain.Application.Features.Questions.Requests.Commands;
using QAndA.Domain.Application.Helpers.Results;
using QAndA.Domain.Entities;
using QAndA.Infrastructure;

namespace QAndA.Domain.Application.Features.Questions.Handlers.Commands
{
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, Result>
    {
       
        private readonly AppDbContext _context;

        public DeleteQuestionCommandHandler( AppDbContext context)
        {
           
            _context = context;
        }

        public async Task<Result> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {

            var questionFromDb = await GetQuestion(request.Id);
            if (questionFromDb is null)
            {
                return Result.Failed("There is no question whit this Id");
            }

           
            _context.Questions.Remove(questionFromDb);
            await _context.SaveChangesAsync();

            return questionFromDb is null ? Result.Failed("Failed to delete") : Result.SuccessFul();


        }


        #region Queries

        async Task<Question> GetQuestion(string id) => await _context.Questions.SingleOrDefaultAsync(ğ => ğ.Id == id);


        #endregion
    }
}
