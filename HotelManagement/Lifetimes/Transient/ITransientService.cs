namespace HotelManagement.Lifetimes.Transient;

public interface ITransientService
{
    Guid Guid { get; }
}

public class TransientService : ITransientService
{
    private Guid _guid = Guid.NewGuid();

    public Guid Guid => _guid;
}
