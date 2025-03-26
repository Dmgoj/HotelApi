using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
   public interface IGuestRepository
{
    Task<Guest?> GetGuestByUniqueIdentifiersAsync(string email, string phoneNumber, string pin);
    Task AddGuestAsync(Guest guest);
}
}
