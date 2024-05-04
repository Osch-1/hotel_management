namespace Domain.Entities;

public class Hotel
{
    public int Id { get; private init; }
    public string Name { get; private set; }
    public string Address { get; private set; }
    public DateTime OpenSince { get; private init; }

    public Hotel( string name, string address, DateTime openSince )
    {
        Name = name;
        Address = address;
        OpenSince = openSince;
    }

    public Hotel( int id, string name, string address )
    {
        Id = id;
        Name = name;
        Address = address;
    }

    /// <summary>
    /// for ef
    /// </summary>
    private Hotel()
    {
    }

    public void SetName( string name )
    {
        if ( string.IsNullOrWhiteSpace( name ) )
        {
            throw new ArgumentException( $"'{nameof( name )}' cannot be null or whitespace.", nameof( name ) );
        }

        Name = name;
    }

    public void SetAddress( string address )
    {
        if ( string.IsNullOrWhiteSpace( address ) )
        {
            throw new ArgumentException( $"'{nameof( address )}' cannot be null or whitespace.", nameof( address ) );
        }

        Address = address;
    }

    public void CopyFrom( Hotel other )
    {
        SetName( other.Name );
        SetAddress( other.Address );
    }
}
