using Domain.Repositories;
using Infrastructure.Foundation;
using Infrastructure.Foundation.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder( args );

// Add services to the DI-container.
// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-8.0
// https://www.youtube.com/watch?v=NkTF_6IQPiY&ab_channel=RawCoding - lifetime
// добавляем в DI-конейтнер реализацию IHotelRepository
builder.Services.AddScoped<IHotelRepository, EFHotelRepository>();

string connectionString = builder.Configuration.GetConnectionString( "HotelManagement" );
builder.Services.AddDbContext<HotelManagementDbContext>( o =>
{
    o.UseSqlServer( connectionString,
        ob => ob.MigrationsAssembly( typeof( HotelManagementDbContext ).Assembly.FullName ) );
} );

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
