namespace LibrarySearchService.Core.Cqs.Data
{
    public interface ICommand : IRequest
    {
        string CommandType { get; }
    }
}
