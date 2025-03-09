﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Shared.DTO
{
    public record RoomReadDto
    {
        public string HotelName { get; set; }
        public RoomType RoomType { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
    }
}
