using AutoMapper;
using LibrarySearchService.Models;
using LibrarySearchService.ViewModels;

namespace LibrarySearchService.Mappings
{
    public class BookModelProfile : Profile
    {
        public BookModelProfile()
        {
            CreateMap<BookModel, BookViewModel>()
                .ForMember(m => m.Title, config => config.MapFrom(c => c.Title))
                .ForMember(m => m.Points, config => config.MapFrom(c => c.Points))
                .ForMember(m => m.Relevance, config => config.MapFrom(c => c.Relevance))
                .ReverseMap();
        }
    }
}
