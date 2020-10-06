using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySearchService.Core.Cqs.Data;

namespace LibrarySearchService.Core.Cqs
{
    public class QueryDispatcher : IQueryDispatcher
    {
        protected readonly IEnumerable<IQueryHandler> queryHandlers;

        public QueryDispatcher(IEnumerable<IQueryHandler> queryHandlers)
        {
            this.queryHandlers = queryHandlers;
        }

        public TResult Dispatch<TParameter, TResult>(TParameter query)
            where TParameter : IQuery
            where TResult : IResult
        {
            var handler = queryHandlers.Single(qh => qh.QueryType == query.QueryType);
            return (TResult) handler.Retrieve(query);
        }

        public async Task<TResult> DispatchAsync<TParameter, TResult>(TParameter query)
            where TParameter : IQuery
            where TResult : IResult
        {
            var handler = queryHandlers.Single(qh => qh.QueryType == query.QueryType);
            return (TResult) await handler.RetrieveAsync(query);
        }
    }
}
