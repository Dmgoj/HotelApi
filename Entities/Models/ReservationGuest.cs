using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ReservationGuest
    {
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        public int GuestId { get; set; }
        public Guest Guest { get; set; }
    }
}
