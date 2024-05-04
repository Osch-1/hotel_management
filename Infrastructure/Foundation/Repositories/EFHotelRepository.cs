using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Foundation.Repositories;

public class EFHotelRepository : IHotelRepository
{
    private readonly HotelManagementDbContext _dbContext;

    public EFHotelRepository( HotelManagementDbContext dbContext )
    {
        _dbContext = dbContext;
    }

    public IReadOnlyList<Hotel> GetAllHotels()
    {
        return _dbContext.Set<Hotel>().ToList();
    }

    public void Save( Hotel hotel )
    {
        _dbContext.Set<Hotel>().Add( hotel );
        _dbContext.SaveChanges();
    }

    public void Update( Hotel hotel )
    {
        Hotel existingHotel = GetHotelById( hotel.Id );
        existingHotel.CopyFrom( hotel );
        _dbContext.SaveChanges();
    }

    public void Delete( int id )
    {
        Hotel existingHotel = GetHotelById( id );
        _dbContext.Set<Hotel>().Remove( existingHotel );
        _dbContext.SaveChanges();
    }

    private Hotel GetHotelById( int id )
    {
        return _dbContext.Set<Hotel>().FirstOrDefault( h => h.Id == id );
    }
}
