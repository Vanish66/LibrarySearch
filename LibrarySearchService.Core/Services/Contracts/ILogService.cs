using System;

namespace LibrarySearchService.Core.Services.Contracts
{
    public interface ILogService
    {
        Guid CorrelationId { get; }

        void LogInfo(string message);

        void LogError(Exception e);

        void LogError(string message, Exception e);
    }
}
