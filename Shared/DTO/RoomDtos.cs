using Entities.Models;

public record RoomCreateDto
{
    public int HotelId { get; set; }
    public RoomType RoomType { get; set; }
    public decimal PricePerNight { get; set; }
    public bool IsAvailable { get; set; }
}

public record RoomReadDto
{
    public string HotelName { get; set; }
    public RoomType RoomType { get; set; }
    public decimal PricePerNight { get; set; }
    public bool IsAvailable { get; set; }
}

public class RoomUpdateDto
{
    public RoomType RoomType { get; set; }
    public decimal PricePerNight { get; set; }
    public bool IsAvailable { get; set; }
}