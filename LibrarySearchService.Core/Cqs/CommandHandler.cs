using System;
using System.Diagnostics;
using System.Threading.Tasks;
using LibrarySearchService.Core.Cqs.Data;
using LibrarySearchService.Core.Services.Contracts;

namespace LibrarySearchService.Core.Cqs
{
    public abstract class CommandHandler : ICommandHandler
    {
        protected readonly ILogService logService;

        protected CommandHandler(ILogService logService)
        {
            this.logService = logService;
        }

        public virtual string CommandType { get; }

        public IResult Handle(ICommand command)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            IResult response;
            try
            {
                response = DoHandle(command);
            }
            catch (Exception exc)
            {
                logService.LogError($"Error in {nameof(ICommand)} CommandHandler. Message: {exc.Message} \n Stacktrace: {exc.StackTrace}", exc);

                throw;
            }
            finally
            {
                stopWatch.Stop();
                logService.LogInfo($"Response for query {nameof(ICommand)} served (elapsed time: {stopWatch.ElapsedMilliseconds} msec)");
            }

            return response;
        }

        public async Task<IResult> HandleAsync(ICommand command)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Task<IResult> response;
            try
            {
                response = DoHandleAsync(command);
            }
            catch (Exception exc)
            {
                logService.LogError($"Error in {nameof(ICommand)} CommandHandler. Message: {exc.Message} \n Stacktrace: {exc.StackTrace}", exc);

                throw;
            }
            finally
            {
                stopWatch.Stop();
                logService.LogInfo($"Response for query {nameof(ICommand)} served (elapsed time: {stopWatch.ElapsedMilliseconds} msec)");
            }

            return await response;
        }

        protected abstract IResult DoHandle(ICommand request);

        protected abstract Task<IResult> DoHandleAsync(ICommand request);
    }
}
