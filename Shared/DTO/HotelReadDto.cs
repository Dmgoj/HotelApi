using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class HotelReadDto
    {
        public string Name { get; init; }
        public string StreetAddress { get; init; }
        public string City { get; init; }
        public string Country { get; init; }
        public string PostalCode { get; init; }
    }
}
