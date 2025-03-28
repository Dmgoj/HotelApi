﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string PIN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<ReservationGuest> ReservationGuests { get; set; } = new List<ReservationGuest>();
    }
}
