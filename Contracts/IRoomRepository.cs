using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Shared.Helpers;

namespace Contracts
{
    public interface IRoomRepository
    {
        public Task<PaginatedList<Room>> GetAllRoomsAsync(int pageIndex, int pageSize, bool trackChanges);
        public Task<Room> GetRoomAsync(int roomId, bool trackChanges);

        public Task CreateRoomAsync(Room room);
        public Task UpdateRoomAsync(Room room);
        public Task DeleteRoomAsync(Room room);
    }
}
