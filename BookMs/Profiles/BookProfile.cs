using AutoMapper;
namespace BookMs.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            //CreateMap<Entities.Book, Models.BookReadDto>();
            //CreateMap<Models.BookReadDto, Entities.Book>();
           CreateMap<Entities.Book, Models.BookReadDto>().ReverseMap();

            //CreateMap<Models.BookWriteDto, Entities.Book>();
            //CreateMap<Entities.Book, Models.BookWriteDto>();

            CreateMap<Models.BookWriteDto, Entities.Book>().ReverseMap();
        }
    }
}
