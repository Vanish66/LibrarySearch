using System.Collections.Generic;
using System.Threading.Tasks;
using LibrarySearchService.ViewModels;

namespace LibrarySearchService.Services.Contracts
{
    public interface IFindBookService
    {
        Task<List<BookViewModel>> SearchBooksByTitle(string filter);
    }
}
