using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Foundation.Repositories;

public class ListHotelRepository : IHotelRepository
{
    // создается один раз за время жизни программы(до перезапуска)
    private readonly static List<Hotel> _hotels = new();

    public IReadOnlyList<Hotel> GetAllHotels()
    {
        return _hotels;
    }

    public void Save( Hotel hotel )
    {
        _hotels.Add( hotel );
    }

    public void Update( Hotel modifiedHotel )
    {
        Hotel hotel = _hotels.FirstOrDefault( h => h.Id == modifiedHotel.Id );
        if ( hotel is null )
        {
            Save( modifiedHotel );
            return;
        }

        hotel.CopyFrom( modifiedHotel );
    }

    public void Delete( int id )
    {
        int index = _hotels.FindIndex( h => h.Id == id );
        if ( index >= 0 )
        {
            _hotels.RemoveAt( index );
        }
    }
}
