using HotelManagement.Lifetimes.Transient;

namespace HotelManagement.Lifetimes.Scoped;

public interface IContainer
{
    Guid ScopedGuid { get; }
    Guid TransientGuid { get; }
}

public class ScopedContainer : IContainer
{
    private readonly IScopedService _scopedService;
    private readonly ITransientService _transientService;

    public Guid ScopedGuid => _scopedService.Guid;

    public Guid TransientGuid => _transientService.Guid;

    public ScopedContainer( IScopedService scopedService, ITransientService transientService )
    {
        _scopedService = scopedService;
        _transientService = transientService;
    }
}
