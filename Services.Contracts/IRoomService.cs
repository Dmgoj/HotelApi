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
        Task<Room> GetRoomAsync(int roomId, bool trackChanges);
        Task<PaginatedList<RoomReadDto>> GetAllRooms();
        Task CreateRoom(RoomCreateDto room);
        Task UpdateRoom(int roomId, RoomUpdateDto room);
        Task DeleteRoom(int roomId);

    }
}
