using Domain.Entities;
using Domain.Repositories;
using HotelManagement.Dto;
using HotelManagement.Lifetimes.Scoped;
using HotelManagement.Lifetimes.Singletone;
using HotelManagement.Lifetimes.Transient;
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
    private readonly ITransientService _transientService;
    private readonly ISingletonService _singletonService;
    private readonly IScopedService _scopedService;
    private readonly IContainer _container;

    // DI-контейнер
    public HotelsController( IContainer scopedContainer, IHotelRepository hotelRepository, ITransientService transientService, ISingletonService singletonService, IScopedService scopedService )
    {
        _hotelRepository = hotelRepository;
        _transientService = transientService;
        _singletonService = singletonService;
        _scopedService = scopedService;
        _container = scopedContainer;
    }

    [HttpGet( "guids" )]
    public IActionResult GetGuids()
    {
        return Ok( new
        {
            fromSingleton = _singletonService.Guid,
            fromScoped = _scopedService.Guid,
            scopedFromContainer = _container.ScopedGuid,
            transient = _transientService.Guid,
            transientGuidFromContainer = _container.TransientGuid
        } );
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


