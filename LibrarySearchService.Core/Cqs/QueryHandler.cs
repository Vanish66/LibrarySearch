using System;
using System.Diagnostics;
using System.Threading.Tasks;
using LibrarySearchService.Core.Cqs.Data;
using LibrarySearchService.Core.Services.Contracts;

namespace LibrarySearchService.Core.Cqs
{
    public abstract class QueryHandler : IQueryHandler
    {
        protected readonly ILogService logService;

        protected QueryHandler(ILogService logService)
        {
            this.logService = logService;
        }

        public virtual string QueryType { get; }

        public IResult Retrieve(IQuery query)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            IResult queryResult;

            try
            {
                queryResult = Handle(query);

            }
            catch (Exception exc)
            {
                logService.LogError($"Error in {nameof(IQuery)} queryHandler. Message: {exc.Message} \n Stacktrace: {exc.StackTrace}", exc);
                throw;
            }
            finally
            {
                stopWatch.Stop();
                logService.LogInfo($"Response for query {nameof(IQuery)} served (elapsed time: {stopWatch.ElapsedMilliseconds} msec)");
            }

            return queryResult;
        }

        public async Task<IResult> RetrieveAsync(IQuery query)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            Task<IResult> queryResult;

            try
            {
                queryResult = HandleAsync(query);

            }
            catch (Exception exc)
            {
                logService.LogError($"Error in {nameof(IQuery)} queryHandler. Message: {exc.Message} \n Stacktrace: {exc.StackTrace}", exc);
                throw;
            }
            finally
            {
                stopWatch.Stop();
                logService.LogInfo($"Response for query {nameof(IQuery)} served (elapsed time: {stopWatch.ElapsedMilliseconds} msec)");
            }

            return await queryResult;
        }

        protected abstract IResult Handle(IQuery request);

        protected abstract Task<IResult> HandleAsync(IQuery request);
    }
}
