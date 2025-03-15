using System.ComponentModel;
using System.Text.Json.Serialization;
using Entities.Models;

public record RoomCreateDto
{
    public RoomType RoomType { get; set; }
    public decimal PricePerNight { get; set; }
    public bool IsAvailable { get; set; }
}

public record RoomReadDto
{
    [JsonPropertyName("roomNumber")]
    public int Id { get; set; }
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