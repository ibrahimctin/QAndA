using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QAndA.Domain.Application.Contracts.Identity;
using QAndA.Domain.Application.DTOs.Answers.ResponseDtos;
using QAndA.Domain.Application.DTOs.AppUsers.ResponseDtos;
using QAndA.Domain.Application.DTOs.Questions.ResponseDtos;
using QAndA.Domain.Application.Features.Posts.Requests.Commands;
using QAndA.Domain.Application.Helpers.Results;
using QAndA.Domain.Entities;
using QAndA.Domain.Entities.IdentityEntities;
using QAndA.Infrastructure;
using System.Collections.Generic;

namespace QAndA.Domain.Application.Features.Posts.Handlers.Commands
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Result>
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUser;

        public CreatePostCommandHandler(IMapper mapper, AppDbContext context, ICurrentUserService currentUser)
        {
            _mapper = mapper;
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<Result> Handle(CreatePostCommand request, CancellationToken cancellationToken)
            {
            var postPayload = _mapper.Map<Post>(request.CreatePostRequest);
            var postQuestionsPayload = await GetQuestionForPost(request.QuestionId);
          
            postPayload.Questions = postQuestionsPayload;


            if (postQuestionsPayload is null)
            {
                return Result.Failed("This question is gone");
            }
            var postDto =  _mapper.Map<IEnumerable<QuestionDetailResponse>>(postPayload.Questions);

            foreach (var item in postDto)
            {
                item.Answers = _mapper.Map<IEnumerable<AnswerDetailResponse>>(postPayload.Answers);
            };


            if (postPayload is not null)
            {
                await _context.AddAsync(postPayload);
                await _context.SaveChangesAsync();
            }

            return postPayload is null ? Result.Failed(message: "Failed To Create") : Result.SuccessFul();
        }
        /// <summary>
        /// 638cfe53-a90d-420a-b30a-9da02f029e19 POST ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        #region My private Methods (Queries)

        private async Task<IEnumerable<Question>> GetQuestionForPost(string id) => await _context.Questions
            .Where(ğ=>ğ.Id==ğ.Id).
            Include(ğ=>ğ.Answers)
            .ToListAsync();

 
        #endregion
    }
}
