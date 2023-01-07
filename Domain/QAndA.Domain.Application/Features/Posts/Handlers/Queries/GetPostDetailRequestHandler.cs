using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QAndA.Domain.Application.DTOs.Posts.ResponseDtos;
using QAndA.Domain.Application.Features.Posts.Requests.Queries;
using QAndA.Domain.Application.Helpers.Results;
using QAndA.Domain.Entities;
using QAndA.Infrastructure;

namespace QAndA.Domain.Application.Features.Posts.Handlers.Queries
{
    public class GetPostDetailRequestHandler : IRequestHandler<GetPostDetailRequest, Result<PostDetailResponse>>
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public GetPostDetailRequestHandler(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<PostDetailResponse>> Handle(GetPostDetailRequest request, CancellationToken cancellationToken)
        {
            if (request.postId is not null)
            {
                var postPayloadFromDb = await GetPostDetail(request.postId);

                var postPayload = _mapper.Map<PostDetailResponse>(postPayloadFromDb);


                return postPayload is not null ? Result<PostDetailResponse>.SuccessFul(postPayload) : Result<PostDetailResponse>.Failed("There is no post whit this id");

            }


            return Result<PostDetailResponse>.Failed("Failed to get post");


        }

        #region My private method(Queries)
        private async Task<Post> GetPostDetail(string id) =>  _context.Posts
            .Include(ğ => ğ.Questions)
            .ThenInclude(ğ => ğ.Answers)
            .FirstOrDefault(ğ => ğ.Id == id);
        #endregion

    }
}
