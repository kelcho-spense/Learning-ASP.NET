using AutoMapper;

namespace BookMs.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Entities.Author, Models.AuthorReadDto>().ReverseMap();
            CreateMap<Models.AuthorWriteDto, Entities.Author>().ReverseMap();
        }

    }
}
