using AutoMapper;
using QAndA.Domain.Application.DTOs.Answers.RequestDtos;
using QAndA.Domain.Application.DTOs.AppUsers.ResponseDtos;
using QAndA.Domain.Application.DTOs.Authentications.RequestDtos;
using QAndA.Domain.Application.DTOs.Questions.RequestDtos;
using QAndA.Domain.Entities;
using QAndA.Domain.Entities.IdentityEntities;

namespace QAndA.Domain.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Question,CreateQuestionRequest>().ReverseMap();
            CreateMap<Answer, CreateAnswerRequest>().ReverseMap();
            CreateMap<AppUser,RegisterRequest>().ReverseMap();  
            CreateMap<AppUser,AppUserDetailResponse>().ReverseMap();
        }
    }
}
