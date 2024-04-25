namespace HotelManagement.Lifetimes.Singletone;

public interface ISingletonService
{
    Guid Guid { get; }
}

public class SingletonService : ISingletonService
{
    private Guid _guid;

    public SingletonService()
    {
        _guid = Guid.NewGuid();
    }

    public Guid Guid => _guid;
}
