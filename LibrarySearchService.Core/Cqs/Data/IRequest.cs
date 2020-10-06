using System;

namespace LibrarySearchService.Core.Cqs.Data
{
    public interface IRequest
    {
        Guid CorrelationId { get; set; }
    }
}
