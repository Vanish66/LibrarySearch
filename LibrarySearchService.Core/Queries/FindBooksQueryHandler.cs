using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibrarySearchService.Core.Constants;
using LibrarySearchService.Core.Cqs;
using LibrarySearchService.Core.Cqs.Data;
using LibrarySearchService.Core.Models;
using LibrarySearchService.Core.Models.Enums;
using LibrarySearchService.Core.Services.Contracts;
using LibrarySearchService.Core.ViewModels;

namespace LibrarySearchService.Core.Queries
{
    public class FindBooksQueryHandler : QueryHandler
    {
        protected readonly IBookService bookService;
        protected readonly IMapper mapper;

        public FindBooksQueryHandler(ILogService logService, IBookService bookService, IMapper mapper) : base(logService)
        {
            this.bookService = bookService;
            this.mapper = mapper;
        }

        public override string QueryType => QueryTypeKeys.FindBooksQueryType;

        protected override IResult Handle(IQuery request)
        {
            var result = new FindBooksQueryResult();
            var findBookRequest = request as FindBooksQuery;
            var books = bookService.GetAllBooks();
            if (findBookRequest != null)
                result.Books = Sort(Filter(books, findBookRequest.Filter), findBookRequest.SortOption)
                    .Select(mapper.Map<BookViewModel>);
            return result;
        }

        protected override async Task<IResult> HandleAsync(IQuery request)
        {
            var result = new FindBooksQueryResult();
            var findBookRequest = request as FindBooksQuery;
            var books = await bookService.GetAllBooksAsync();
            if (findBookRequest != null)
                result.Books = Sort(Filter(books, findBookRequest.Filter), findBookRequest.SortOption)
                    .Select(mapper.Map<BookViewModel>);
            return result;
        }

        private List<BookModel> Filter(List<BookModel> books, string filter)
        {
            return string.IsNullOrEmpty(filter)
                ? new List<BookModel>()
                : books.Where(book => book.Title.Contains(filter.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<BookModel> Sort(List<BookModel> books, SortOption sortOption)
        {
            return sortOption switch
            {
                SortOption.Relevant => books.OrderByDescending(book => book.Relevance).ToList(),
                SortOption.Points => books.OrderByDescending(book => book.Points).ToList(),
                _ => throw new ArgumentOutOfRangeException(nameof(sortOption), sortOption, null)
            };
        }
    }
}
