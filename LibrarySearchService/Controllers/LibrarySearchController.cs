using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LibrarySearchService.Core.Cqs;
using LibrarySearchService.Core.Queries;
using LibrarySearchService.Core.Services.Contracts;
using LibrarySearchService.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySearchService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrarySearchController : ControllerBase
    {
        protected readonly IQueryDispatcher queryDispatcher;

        public LibrarySearchController(IQueryDispatcher queryDispatcher)
        {
            this.queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public async Task<IEnumerable<BookViewModel>> Get([FromQuery] SearchBookModel model)
        {
            var result = await queryDispatcher.DispatchAsync<FindBooksQuery, FindBooksQueryResult>(new FindBooksQuery
                {Filter = model.Filter, SortOption = model.SortOption});
            return result.Books;
        }
    }
}
