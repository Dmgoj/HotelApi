using Contracts;
using Entities;
using Entities.Models;
using Repository;
using Services.Contracts;
using Shared.DTO;
using Shared.Helpers;

namespace Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelService(IHotelRepository hotelRepository) 
        {
            _hotelRepository = hotelRepository;
        }
        public async Task<Hotel> CreateHotelAsync(HotelCreateDto hotelDto)
        {
            if (hotelDto == null)
                throw new ArgumentNullException(nameof(hotelDto)); 

            var hotel = new Hotel();

            hotelDto.Map(hotel);

            await _hotelRepository.CreateHotelAsync(hotel);

            return hotel;
        }

        public async Task DeleteHotelAsync(int hotelId)
        {
            var hotel = await _hotelRepository.GetHotelAsync(hotelId,false);
            
            if (hotel == null)
            {
                throw new Exception("Hotel not found.");
            }

            await _hotelRepository.DeleteHotelAsync(hotel);
        }

        public async Task<PaginatedList<HotelReadDto>> GetAllHotelsAsync(int pageIndex, int pageSize, bool trackChanges)
        {
            var hotels = await _hotelRepository.GetAllHotelsAsync(pageIndex, pageSize, trackChanges);
            var hotelDtos = hotels.Select(hotel =>
            {
                var hotelReadDto = new HotelReadDto();
                hotel.Map(hotelReadDto); 
                return hotelReadDto;
            }).ToList();

            return new PaginatedList<HotelReadDto>(hotelDtos, hotels.Count, pageIndex, pageSize);
        }

        public async Task<HotelReadDto> GetHotelAsync(int hotelId, bool trackChanges)
        {
            if (hotelId <= 0)
                throw new ArgumentException("Hotel ID must be greater than zero.", nameof(hotelId));

            
            var hotel = await _hotelRepository.GetHotelAsync(hotelId, trackChanges);

            if (hotel == null)
                throw new KeyNotFoundException($"Hotel with ID {hotelId} not found.");

            var hotelReadDto = new HotelReadDto();
            hotel.Map(hotelReadDto); 

            return hotelReadDto;
        }

        public async Task<Hotel> UpdateHotelAsync(int id, HotelUpdateDto hotelDto)
        {
            var hotel = await _hotelRepository.GetHotelAsync(id,true);

            if (hotel is null)
            {
                throw new KeyNotFoundException($"Hotel with ID {id} not found.");
            }

            hotelDto.Map(hotel);

            await _hotelRepository.UpdateHotelAsync(hotel);

            return hotel;
        }
    }
}
