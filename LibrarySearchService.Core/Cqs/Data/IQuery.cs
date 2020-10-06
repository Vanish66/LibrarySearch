namespace LibrarySearchService.Core.Cqs.Data
{
    public interface IQuery : IRequest
    {
        string QueryType { get; }
    }
}
