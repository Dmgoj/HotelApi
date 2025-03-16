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
        public async Task CreateRoomAsync(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoomAsync(Room room)
        {
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }

        public Task<PaginatedList<Room>> GetAllRoomsAsync(int hotelId, int pageIndex, int pageSize, bool trackChanges)
        {
            var query = trackChanges ? _context.Rooms : _context.Rooms.AsNoTracking();
            query = query.Where(r => r.HotelId == hotelId).Include(r=>r.Hotel);
            return  PaginatedList<Room>.CreateAsync(query, pageIndex, pageSize);
        }

        public async Task<Room> GetRoomAsync(int roomId, bool trackChanges)
        {
            IQueryable<Room> query = _context.Rooms.Include(r => r.Hotel);

            if (!trackChanges)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(r => r.Id == roomId);
        }

        public Task UpdateRoomAsync(Room room)
        {
            _context.Update(room);
            return _context.SaveChangesAsync();
        }
    }
}
