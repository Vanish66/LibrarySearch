using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySearchService.Core.Cqs.Data;

namespace LibrarySearchService.Core.Cqs
{
    public class CommandDispatcher : ICommandDispatcher
    {
        protected readonly IEnumerable<ICommandHandler> commandHandlers;

        public CommandDispatcher(IEnumerable<ICommandHandler> commandHandlers)
        {
            this.commandHandlers = commandHandlers;
        }

        public TResult Dispatch<TParameter, TResult>(TParameter command)
            where TParameter : ICommand
            where TResult : IResult
        {
            var handler = commandHandlers.Single(ch => ch.CommandType == command.CommandType);
            return (TResult) handler.Handle(command);
        }

        public async Task<TResult> DispatchAsync<TParameter, TResult>(TParameter command)
            where TParameter : ICommand
            where TResult : IResult
        {
            var handler = commandHandlers.Single(ch => ch.CommandType == command.CommandType);
            return (TResult) await handler.HandleAsync(command);
        }
    }
}
