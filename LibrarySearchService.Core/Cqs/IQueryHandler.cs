using System.Threading.Tasks;
using LibrarySearchService.Core.Cqs.Data;

namespace LibrarySearchService.Core.Cqs
{
    public interface IQueryHandler
    {
        string QueryType { get; }

        IResult Retrieve(IQuery query);

        Task<IResult> RetrieveAsync(IQuery query);
    }
}
