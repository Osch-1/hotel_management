using Domain.Entities;

namespace Domain.Repositories;

public interface IHotelRepository
{
    IReadOnlyList<Hotel> GetAllHotels();

    void Save( Hotel hotel );

    void Update( Hotel hotel );

    void Delete( int id );
}
