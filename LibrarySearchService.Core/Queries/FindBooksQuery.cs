using System.Collections.Generic;
using LibrarySearchService.Core.Constants;
using LibrarySearchService.Core.Cqs.Data;
using LibrarySearchService.Core.Models;
using LibrarySearchService.Core.Models.Enums;
using LibrarySearchService.Core.ViewModels;

namespace LibrarySearchService.Core.Queries
{
    public class FindBooksQuery : Query
    {
        public override string QueryType => QueryTypeKeys.FindBooksQueryType;

        public string Filter { get; set; }

        public SortOption SortOption { get; set; }
    }

    public class FindBooksQueryResult : IResult
    {
        public IEnumerable<BookViewModel> Books { get; set; }
    }
}
