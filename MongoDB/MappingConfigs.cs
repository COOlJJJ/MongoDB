using AutoMapper;
using MongoDB.DTO;
using MongoDB.Models;

namespace MongoDB
{

    public class MappingConfigs : Profile
    {
        public MappingConfigs()
        {
            //ReverseMap 双向映射
            CreateMap<CreateBookDto, Book>().ReverseMap();
            CreateMap<UpdateBookDto, Book>()
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
