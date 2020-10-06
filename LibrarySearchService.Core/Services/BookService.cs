using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using LibrarySearchService.Core.Constants;
using LibrarySearchService.Core.Models;
using LibrarySearchService.Core.Services.Contracts;

namespace LibrarySearchService.Core.Services
{
    public class BookService : IBookService
    {
        protected readonly ILogService logService;

        public BookService(ILogService logService)
        {
            this.logService = logService;
        }

        public List<BookModel> GetAllBooks()
        {
            List<BookModel> books;
            try
            {
                var json = File.ReadAllText(LibrarySearchConstants.LibraryFileLocation);
                books = JsonSerializer.Deserialize<List<BookModel>>(json);
            }
            catch (Exception e)
            {
                logService.LogError(e);
                throw;
            }
            return books;
        }

        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            List<BookModel> books;
            try
            {
                await using var fs = File.OpenRead(LibrarySearchConstants.LibraryFileLocation);
                books = await JsonSerializer.DeserializeAsync<List<BookModel>>(fs);
            }
            catch (Exception e)
            {
                logService.LogError(e);
                throw;
            }
            return books;
        }
    }
}
