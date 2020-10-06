using System.Threading.Tasks;
using LibrarySearchService.Core.Cqs.Data;

namespace LibrarySearchService.Core.Cqs
{
    public interface ICommandHandler
    {
        string CommandType { get; }

        IResult Handle(ICommand command);

        Task<IResult> HandleAsync(ICommand command);
    }
}
