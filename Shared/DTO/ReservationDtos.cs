using System.Text.Json.Serialization;
using Entities.Models;
using Shared.DTO;

public record ReservationCreateDto
{
    public int RoomId { get; set; }
    public int HotelId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public decimal TotalPrice { get; set; }
    public ReservationStatus ReservationStatus { get; set; }
    public List<GuestCreateDto> Guests { get; set; } = new();
}

public record ReservationReadDto
{
    [JsonPropertyName("Room Number")]
    public int RoomId { get; init; }
    public string HotelName { get; init; }
    public DateTime CheckInDate { get; init; }
    public DateTime CheckOutDate { get; init; }
    public decimal TotalPrice { get; init; }
    public ReservationStatus ReservationStatus { get; init; }
    public List<GuestReadDto> Guests { get; init; } = new();
}

public record ReservationUpdateDto
{
    public int RoomId { get; set; }
    public int HotelId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public decimal TotalPrice { get; set; }
    public ReservationStatus ReservationStatus { get; set; }
}