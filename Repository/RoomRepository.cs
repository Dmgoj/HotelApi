using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Helpers;

namespace Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly RepositoryContext _context;
        public RoomRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }
        public Task CreateRoomAsync(Room room)
        {
            _context.Rooms.Add(room);
            return _context.SaveChangesAsync();
        }

        public Task DeleteRoomAsync(Room room)
        {
            _context.Rooms.Remove(room);
            return _context.SaveChangesAsync();
        }

        public Task<PaginatedList<Room>> GetAllRoomsAsync(int pageIndex, int pageSize, bool trackChanges)
        {
            var query = trackChanges ? _context.Rooms : _context.Rooms.AsNoTracking();
            return  PaginatedList<Room>.CreateAsync(_context.Rooms.AsQueryable(), pageIndex, pageSize);

        }

        public  Task<Room> GetRoomAsync(int roomId, bool trackChanges)
        {
            return  _context.Rooms
           .AsTracking(trackChanges ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking)
           .FirstOrDefaultAsync(h => h.Id == roomId);
        }

        public Task UpdateRoomAsync(Room room)
        {
            _context.Update(room);
            return _context.SaveChangesAsync();
        }
    }
}
