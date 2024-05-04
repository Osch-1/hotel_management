using Infrastructure.Foundation.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Foundation;

public class HotelManagementDbContext : DbContext
{
    public HotelManagementDbContext( DbContextOptions options )
        : base( options )
    {
    }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating( modelBuilder );

        modelBuilder.ApplyConfiguration( new HotelConfiguration() );
    }
}
