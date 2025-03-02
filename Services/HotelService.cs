using Contracts;
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

            if (string.IsNullOrWhiteSpace(hotelDto.Name))
                throw new ArgumentException("Hotel name is required"); 

            var hotel = new Hotel
            {
                Name = hotelDto.Name,
                StreetAddress = hotelDto.StreetAddress,
                City = hotelDto.City,
                Country = hotelDto.Country,
                PostalCode = hotelDto.PostalCode
            };

            
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

            var hotelDtos = hotels.Select(hotel => new HotelReadDto
            {
                Name = hotel.Name,
                StreetAddress = hotel.StreetAddress,
                City = hotel.City,
                Country = hotel.Country,
                PostalCode = hotel.PostalCode
            }).ToList();
          
            return new PaginatedList<HotelReadDto>(hotelDtos, hotels.Count, pageIndex, pageSize);
        }

        public async Task<Hotel> GetHotelAsync(int hotelId, bool trackChanges)
        {
            if (hotelId <= 0)
                throw new ArgumentException("Hotel ID must be greater than zero.", nameof(hotelId));

            
            var hotel = await _hotelRepository.GetHotelAsync(hotelId, trackChanges);

            return hotel ?? throw new KeyNotFoundException($"Hotel with ID {hotelId} not found.");
        }

        public async Task<Hotel> UpdateHotelAsync(int id, HotelUpdateDto hotelDto)
        {
            var hotel = await _hotelRepository.GetHotelAsync(id,true);

            if (hotel is null)
            {
                throw new KeyNotFoundException($"Hotel with ID {id} not found.");
            }

            foreach (var prop in typeof(HotelUpdateDto).GetProperties())
            {
                var newValue = prop.GetValue(hotelDto);
                if (newValue is not null) 
                {
                    var hotelProp = typeof(Hotel).GetProperty(prop.Name);
                    if (hotelProp is not null && hotelProp.CanWrite)
                    {
                        hotelProp.SetValue(hotel, newValue);
                    }
                }
            }

            await _hotelRepository.UpdateHotelAsync(hotel);

            return hotel;
        }
    }
}
