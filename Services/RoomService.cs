using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Models;
using Repository;
using Services.Contracts;
using Shared.Helpers;

namespace Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        public RoomService(IRoomRepository roomRepository) 
        {
            _roomRepository = roomRepository;
        }
        public async Task<Room> CreateRoomAsync(int hotelId, RoomCreateDto roomDto)
        {
           if (roomDto == null)
            {
                throw new ArgumentNullException(nameof(roomDto));
            }

            var room = new Room();
            roomDto.Map(room);
            room.HotelId = hotelId;

            await _roomRepository.CreateRoomAsync(room);

            return room;
        }

        public async Task DeleteRoom(int roomId)
        {
            var room = await _roomRepository.GetRoomAsync(roomId, true);

            if (room == null)
            {
                throw new KeyNotFoundException($"Room with ID {roomId} not found.");
            }

            await _roomRepository.DeleteRoomAsync(room);
        }

        public async Task<PaginatedList<RoomReadDto>> GetAllRoomsAsync(int hotelId,int pageIndex, int pageSize, bool trackChanges)
        {
            var rooms = await _roomRepository.GetAllRoomsAsync(hotelId, pageIndex, pageSize, trackChanges);
            var roomsDto = rooms.Select(room =>
            {
                var roomDto = new RoomReadDto();
                room.Map(roomDto);
                roomDto.HotelName = room.Hotel?.Name;
                return roomDto;
            }).ToList();

            return new PaginatedList<RoomReadDto>(roomsDto, rooms.Count, pageIndex, pageSize);
        }

        public async Task<RoomReadDto> GetRoomAsync(int roomId, bool trackChanges)
        {
            var room = await _roomRepository.GetRoomAsync(roomId, trackChanges);
            var roomDto = new RoomReadDto();
            room.Map(roomDto);
            roomDto.HotelName = room.Hotel?.Name;
            return roomDto;
        }

        public async Task UpdateRoomAsync(int roomId, RoomUpdateDto roomDto)
        {
            var room = await _roomRepository.GetRoomAsync(roomId, true);

            if (room == null)
            {
                throw new KeyNotFoundException($"Room with ID {roomId} not found.");
            }

            roomDto.Map(room);

            await _roomRepository.UpdateRoomAsync(room);

        }
    }
}
