using LibrarySearchService.Core.Models.Enums;

namespace LibrarySearchService.Core.ViewModels
{
    public class SearchBookModel
    {
        public string Filter { get; set; }

        public SortOption SortOption { get; set; }
    }
}
