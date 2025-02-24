using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public enum RoomType
    {
        Single,
        Double,
        Suite,
        Deluxe,
        Executive,
        Presidential
    }
    public class Room
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public RoomType RoomType { get; set; } 
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
    }
}
