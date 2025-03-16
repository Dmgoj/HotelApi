using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Shared.DTO;
using Shared.Helpers;

namespace Services.Contracts
{
    public interface IRoomService
    {
        Task<RoomReadDto> GetRoomAsync(int roomId, bool trackChanges);
        Task<PaginatedList<RoomReadDto>> GetAllRoomsAsync(int hotelId, int pageIndex, int pageSize, bool trackChanges);
        Task<Room> CreateRoomAsync(int hotelId, RoomCreateDto room);
        Task UpdateRoomAsync(int roomId, RoomUpdateDto room);
        Task DeleteRoom(int roomId);

    }
}
