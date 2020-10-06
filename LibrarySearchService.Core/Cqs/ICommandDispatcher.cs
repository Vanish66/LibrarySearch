using System.Threading.Tasks;
using LibrarySearchService.Core.Cqs.Data;

namespace LibrarySearchService.Core.Cqs
{
    public interface ICommandDispatcher
    {
        TResult Dispatch<TParameter, TResult>(TParameter command)
            where TParameter : ICommand
            where TResult : IResult;

        Task<TResult> DispatchAsync<TParameter, TResult>(TParameter command)
            where TParameter : ICommand
            where TResult : IResult;
    }
}
