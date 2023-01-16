using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QAndA.Domain.Application.DTOs.Answers.ResponseDtos;
using QAndA.Domain.Application.Features.Answers.Requests.Queries;
using QAndA.Domain.Application.Helpers.Results;
using QAndA.Domain.Entities;
using QAndA.Infrastructure;
using QAndA.Infrastructure.Extensions;

namespace QAndA.Domain.Application.Features.Answers.Handlers.Queries
{
    public class GetAnswerDetailByIdQueryRequestHandler : IRequestHandler<GetAnswerDetailByIdQueryRequest, Result<AnswerDetailResponse>>
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
       

        public GetAnswerDetailByIdQueryRequestHandler(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
           
        }

        public async Task<Result<AnswerDetailResponse>> Handle(GetAnswerDetailByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var answerFromDb = await _context.Answers.Where(ğ=>ğ.Id == request.Id).FirstOrDefaultAsync();  

            if (answerFromDb is null)
            {
                return Result<AnswerDetailResponse>.Failed("There is no Answer Whit this id");
            }

            var answerPayload = _mapper.Map<AnswerDetailResponse>(answerFromDb);

            return Result<AnswerDetailResponse>.SuccessFul(answerPayload);


        }

        
    }
}
