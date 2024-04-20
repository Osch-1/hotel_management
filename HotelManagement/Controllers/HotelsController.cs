using Domain.Entities;
using HotelManagement.Dto;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers;

// Описание работы с web api https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio
[ApiController]
[Route( "hotels" )]
// http-протокол https://developer.mozilla.org/ru/docs/Web/HTTP
// методы http - https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods
public class HotelsController : ControllerBase
{
    private static List<Hotel> _hotels;

    // статический конструктор запускается один раз для класса
    static HotelsController()
    {
        _hotels = new();
    }

    // Http-метод GET
    // GET подразумевает что мы запрашиваем данные с сервера, не меняем состояние на нем
    // может содержать query-параметре в качестве метода фильтра/уточнения запроса данных
    [HttpGet( "" )]
    public IActionResult GetHotels()
    {
        return Ok( _hotels );
    }

    // Http-метод POST
    // POST метод подразумевает изменение состояния на сервере, например, создание нового отеля
    // Также содержит body - тело запроса, в нем передаются данные
    [HttpPost( "" )]
    public IActionResult CreateHotel( /*Говорим что данные имеют формат CreateHotelRequest и лежат в теле http-запроса*/ [FromBody] CreateHotelRequest request )
    {
        int id = _hotels.Count + 1;
        Hotel newHotel = new( id, request.Name, request.Address, request.OpenSince );

        _hotels.Add( newHotel );

        // возвращает http-ответ со статусом 200-ОК
        return Ok();
    }

    // Http-метод PUT
    // PUT означает изменение состояние на сервере для сущ-их данных
    [HttpPut( "{id:int}" )]
    public IActionResult ModifyHotel( [FromRoute] int id, [FromBody] ModifyHotelRequest request )
    {
        // находим отель который пользователь хочет изменить
        Hotel hotel = _hotels.FirstOrDefault( h => h.Id == id );

        // если отеля нет - говорим об этом пользователю
        if ( hotel is null )
        {
            return NotFound();
        }

        hotel.SetName( request.Name );
        hotel.SetAddress( request.Address );

        return Ok();
    }

    [HttpDelete( "{id:int}" )]
    public IActionResult DeleteHotel( [FromRoute] int id )
    {
        // todo: implement
        throw new NotImplementedException();
    }
}


