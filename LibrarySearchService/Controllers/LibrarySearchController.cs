using System.Collections.Generic;
using System.Threading.Tasks;
using LibrarySearchService.Services.Contracts;
using LibrarySearchService.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySearchService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrarySearchController : ControllerBase
    {
        protected readonly IFindBookService findBookService;

        public LibrarySearchController(IFindBookService findBookService)
        {
            this.findBookService = findBookService;
        }

        [HttpGet]
        public async Task<IEnumerable<BookViewModel>> Get([FromQuery] string filter)
        {
            return await findBookService.SearchBooksByTitle(filter);
        }
    }
}
