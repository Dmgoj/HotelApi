using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        Cancelled
    }

    public class Reservation
    {
        public int Id { get; set; }
        public int GuestId { get; set; }
        public Guest Guest { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public ReservationStatus ReservationStatus { get; set; } 
    }
}
