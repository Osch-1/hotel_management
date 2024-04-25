using Domain.Repositories;
using HotelManagement.Lifetimes.Scoped;
using HotelManagement.Lifetimes.Singletone;
using HotelManagement.Lifetimes.Transient;
using Infrastructure.Foundation.Repositories;

var builder = WebApplication.CreateBuilder( args );

// Add services to the DI-container.
// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-8.0
// https://www.youtube.com/watch?v=NkTF_6IQPiY&ab_channel=RawCoding - lifetime
// добавляем в DI-конейтнер реализацию IHotelRepository
builder.Services.AddScoped<IHotelRepository, ListHotelRepository>();

// Transient
// Каждый раз, когда будет запрошена зависимость - будет создан новый экземпляр
builder.Services.AddTransient<ITransientService, TransientService>();

// Scoped
// Время жизни привязано к какому-то объекту
// Например - HttpRequestScope обозначал бы время жизни/обработки Http-запроса
builder.Services.AddScoped<IScopedService, ScopedService>();
builder.Services.AddScoped<IContainer, ScopedContainer>();

// Singleton
// За все время жизни приложения создается только один экзмепляр
builder.Services.AddSingleton<ISingletonService, SingletonService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
