using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Foundation.Configurations;

internal class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure( EntityTypeBuilder<Hotel> builder )
    {
        builder.ToTable( nameof( Hotel ) );
        builder.HasKey( h => h.Id );

        builder.Property( h => h.Name )
               .HasMaxLength( 300 )
               .IsRequired();

        builder.Property( h => h.Address )
               .HasMaxLength( 500 )
               .IsRequired();

        builder.Property( h => h.OpenSince )
               .IsRequired();
    }
}
