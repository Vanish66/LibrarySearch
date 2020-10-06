using System;
using System.Collections.Generic;
using LibrarySearchService.Core.Constants;
using LibrarySearchService.Core.Services.Contracts;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Core.Enrichers;

namespace LibrarySearchService.Core.Services
{
    public class LogService : ILogService
    {
        protected readonly Guid correlationId = Guid.NewGuid();

        public Guid CorrelationId => this.correlationId;

        public void LogInfo(string message)
        {
            using (LogContext.Push(this.GetProperties()))
                Log.Information(message);
        }

        public void LogError(Exception e) => this.LogError(e.Message, e);

        public void LogError(string message, Exception e)
        {
            using (LogContext.Push(this.GetProperties()))
                Log.Error(e, message);
        }

        protected virtual ILogEventEnricher[] GetProperties() => new List<ILogEventEnricher>()
        {
            (ILogEventEnricher) new PropertyEnricher(LogAttributeKeys.CorrelationIdName, (object) this.CorrelationId)
        }.ToArray();
    }
}
