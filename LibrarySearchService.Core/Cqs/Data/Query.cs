namespace LibrarySearchService.Core.Cqs.Data
{
    public abstract class Query : Request, IQuery
    {
        public virtual string QueryType { get; }
    }
}
