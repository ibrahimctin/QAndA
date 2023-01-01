using AutoMapper;
using QAndA.Domain.Application.DTOs.Questions.RequestDtos;
using QAndA.Domain.Entities;

namespace QAndA.Domain.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Question,CreateQuestionRequest>().ReverseMap();
        }
    }
}
