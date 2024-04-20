namespace HotelManagement.Dto;

// класс-dto
// data transfer object
// идея в том, что мы изолируем предметную область от внешнего мира
public class CreateHotelRequest
{
    public string Name { get; set; }
    public string Address { get; set; }
    public DateTime OpenSince { get; set; }
}
