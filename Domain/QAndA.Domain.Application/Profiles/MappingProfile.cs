using AutoMapper;
using QAndA.Domain.Application.DTOs.Answers.RequestDtos;
using QAndA.Domain.Application.DTOs.Answers.ResponseDtos;
using QAndA.Domain.Application.DTOs.AppUsers.ResponseDtos;
using QAndA.Domain.Application.DTOs.Authentications.RequestDtos;
using QAndA.Domain.Application.DTOs.Posts.RequestDtos;
using QAndA.Domain.Application.DTOs.Posts.ResponseDtos;
using QAndA.Domain.Application.DTOs.Questions.RequestDtos;
using QAndA.Domain.Application.DTOs.Questions.ResponseDtos;
using QAndA.Domain.Entities;
using QAndA.Domain.Entities.IdentityEntities;

namespace QAndA.Domain.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Question,CreateQuestionRequest>().ReverseMap();
            CreateMap<Question, UpdateQuestionRequest>().ReverseMap();
            CreateMap<Question, QuestionDetailResponse>().ReverseMap();
            CreateMap<Answer, CreateAnswerRequest>().ReverseMap();
            CreateMap<Answer, AnswerDetailResponse>().ReverseMap();
            CreateMap<Question, QuestionDetailResponse>().ReverseMap();
            CreateMap<AppUser,RegisterRequest>().ReverseMap();  
            CreateMap<AppUser,AppUserDetailResponse>().ReverseMap();
            CreateMap<Post, CreatePostRequest>().ReverseMap();
            CreateMap<Post, PostDetailResponse>().ReverseMap();
        }
    }
}
