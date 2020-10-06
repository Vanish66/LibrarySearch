using System;

namespace LibrarySearchService.Core.Cqs.Data
{
    public abstract class Request : IRequest
    {
        protected Request()
        {
            CorrelationId = Guid.NewGuid();
        }

        public Guid CorrelationId { get; set; }
    }
}
