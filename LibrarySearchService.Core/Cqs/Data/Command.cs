using System;

namespace LibrarySearchService.Core.Cqs.Data
{
    public class Command : Request, ICommand
    {
        public string CommandType { get; }
    }
}
