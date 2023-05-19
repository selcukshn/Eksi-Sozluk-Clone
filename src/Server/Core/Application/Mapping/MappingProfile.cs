using AutoMapper;
using Common.Models.Command;
using Common.Models.View;
using Domain;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserLoginViewModel>().ReverseMap();
            CreateMap<User, UserCreateCommand>().ReverseMap();
            CreateMap<User, UserUpdateCommand>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();


            CreateMap<Entry, EntryCreateCommand>();
            CreateMap<Entry, MainPageViewModel>()
            .ForMember(e => e.Username, e => e.MapFrom(b => b.User.Username));
            CreateMap<Entry, SidebarViewModel>()
            .ForMember(e => e.CommentCount, a => a.MapFrom(b => b.EntryComments.Count));
            CreateMap<Entry, AllEntryViewModel>()
            .ForMember(e => e.Username, e => e.MapFrom(b => b.User.Username));
        }
    }
}