using Domain.Entities;
using Domain.Repositories;
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
    private readonly IHotelRepository _hotelRepository;

    // DI-контейнер
    public HotelsController( IHotelRepository hotelRepository )
    {
        _hotelRepository = hotelRepository;
    }

    // Http-метод GET
    // GET подразумевает что мы запрашиваем данные с сервера, не меняем состояние на нем
    // может содержать query-параметре в качестве метода фильтра/уточнения запроса данных
    [HttpGet( "" )]
    public IActionResult GetHotels()
    {
        IReadOnlyList<Hotel> hotels = _hotelRepository.GetAllHotels();

        return Ok( hotels );
    }

    // Http-метод POST
    // POST метод подразумевает изменение состояния на сервере, например, создание нового отеля
    // Также содержит body - тело запроса, в нем передаются данные
    [HttpPost( "" )]
    public IActionResult CreateHotel( /*Говорим что данные имеют формат CreateHotelRequest и лежат в теле http-запроса*/ [FromBody] CreateHotelRequest request )
    {
        Hotel hotel = new( request.Name, request.Address, request.OpenSince );
        _hotelRepository.Save( hotel );

        // возвращает http-ответ со статусом 200-ОК
        return Ok();
    }

    // Http-метод PUT
    // PUT означает изменение состояние на сервере для сущ-их данных
    [HttpPut( "{id:int}" )]
    public IActionResult ModifyHotel( [FromRoute] int id, [FromBody] ModifyHotelRequest request )
    {
        // нет валидации
        // создаем отель, когда на самом деле надо модифицировать
        // отделение методов по изменению - например изменить только адресс

        Hotel hotel = new( id, request.Name, request.Address );
        _hotelRepository.Update( hotel );
        return Ok();
    }

    [HttpDelete( "{id:int}" )]
    public IActionResult DeleteHotel( [FromRoute] int id )
    {
        _hotelRepository.Delete( id );

        return Ok();
    }
}


