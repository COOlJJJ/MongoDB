using AutoMapper;
using MongoDB.DTO;
using MongoDB.Models;
using MongoDB.VO;

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

            CreateMap<Contact, ContactViewModel>();
            CreateMap<Group, GroupViewModel>();
        }
    }
}
