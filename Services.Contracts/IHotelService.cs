using Entities.Models;
using Shared.DTO;
using Shared.Helpers;

namespace Services.Contracts
{
    public interface IHotelService
    {
        Task<Hotel> CreateHotelAsync(HotelCreateDto hotel);
        Task<Hotel> GetHotelAsync(int hotelId, bool trackChanges);
        Task<PaginatedList<HotelReadDto>> GetAllHotelsAsync(int pageIndex, int pageSize, bool trackChanges); 
        Task <Hotel> UpdateHotelAsync(int id, HotelUpdateDto hotelDto);
        Task DeleteHotelAsync(int hotelId);
    }
}
