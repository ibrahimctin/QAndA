using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using QAndA.Domain.Application.DTOs.Answers.ResponseDtos;
using QAndA.Domain.Application.DTOs.Questions.ResponseDtos;
using QAndA.Domain.Application.Features.Questions.Requests.Queries;
using QAndA.Domain.Application.Helpers.Results;
using QAndA.Infrastructure;

namespace QAndA.Domain.Application.Features.Questions.Handlers.Queries
{
    public class GetQuestionDetailByIdQueryRequestHandler : IRequestHandler<GetQuestionDetailByIdQueryRequest, Result<QuestionDetailResponse>>
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public GetQuestionDetailByIdQueryRequestHandler(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<QuestionDetailResponse>> Handle(GetQuestionDetailByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var questionFromDb = await _context.Questions.Where(ğ=>ğ.Id==request.Id).ToListAsync();

            if (questionFromDb is null)
            {
                return Result<QuestionDetailResponse>.Failed("There is no question Whit this id");
            }

            var questionPayload = _mapper.Map<QuestionDetailResponse>(questionFromDb);  

            return Result<QuestionDetailResponse>.SuccessFul(questionPayload);
        }
    }
}
