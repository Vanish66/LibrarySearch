using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using LibrarySearchService.Constants;
using LibrarySearchService.Models;
using LibrarySearchService.Services.Contracts;
using LibrarySearchService.ViewModels;
using Microsoft.Extensions.Configuration;

namespace LibrarySearchService.Services
{
    public class FindBookService : IFindBookService
    {
        protected readonly IMapper mapper;
        protected readonly IConfiguration configuration;

        public FindBookService(IMapper mapper, IConfiguration configuration)
        {
            this.mapper = mapper;
            this.configuration = configuration;
        }

        public async Task<List<BookViewModel>> SearchBooksByTitle(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return new List<BookViewModel>();
            }
            List<BookModel> books;
            try
            {
                await using (var fs = File.OpenRead(configuration[LibrarySearchConstants.LibraryFileLocation]))
                {
                    books = await JsonSerializer.DeserializeAsync<List<BookModel>>(fs);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<BookViewModel>();
            }

            return books.Where(book => book.Title.Contains(filter.Trim(), StringComparison.OrdinalIgnoreCase))
                .Select(book => mapper.Map<BookViewModel>(book)).ToList();
        }
    }
}
