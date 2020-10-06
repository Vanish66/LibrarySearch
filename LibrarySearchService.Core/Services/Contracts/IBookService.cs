using System.Collections.Generic;
using System.Threading.Tasks;
using LibrarySearchService.Core.Models;

namespace LibrarySearchService.Core.Services.Contracts
{
    public interface IBookService
    {
        List<BookModel> GetAllBooks();

        Task<List<BookModel>> GetAllBooksAsync();
    }
}
