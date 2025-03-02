using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Shared.Helpers;

namespace Contracts
{
    public interface IHotelRepository
    {
        Task<PaginatedList<Hotel>> GetAllHotelsAsync(int pageIndex, int pageSize, bool trackChanges); 
        Task<Hotel> GetHotelAsync(int hotelId, bool trackChanges);
        Task CreateHotelAsync(Hotel hotel);
        Task UpdateHotelAsync(Hotel hotel);
        Task DeleteHotelAsync(Hotel hotel);
    }
}
