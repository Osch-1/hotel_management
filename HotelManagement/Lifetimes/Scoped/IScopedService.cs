namespace HotelManagement.Lifetimes.Scoped;

public interface IScopedService
{
    Guid Guid { get; }
}

public class ScopedService : IScopedService
{
    private Guid _guid;

    public ScopedService()
    {
        _guid = Guid.NewGuid();
    }
    public Guid Guid => _guid;
}

