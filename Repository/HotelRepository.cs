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
    public class HotelRepository : IHotelRepository
    {
        private readonly RepositoryContext _context;
        public HotelRepository(RepositoryContext repositoryContext) 
        {
            _context = repositoryContext;
        }
        public async Task CreateHotelAsync(Hotel hotel)
        { 
            await _context.Hotels.AddAsync(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHotelAsync(Hotel hotel)
        {
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task<PaginatedList<Hotel>> GetAllHotelsAsync(int pageIndex, int pageSize, bool trackChanges)
        {
            var query = trackChanges ? _context.Hotels : _context.Hotels.AsNoTracking();
            return await PaginatedList<Hotel>.CreateAsync(_context.Hotels.AsQueryable(), pageIndex, pageSize);
        }

       

        public async Task<Hotel> GetHotelAsync(int hotelId, bool trackChanges)
        {
            return await _context.Hotels
        .AsTracking(trackChanges ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking)
        .FirstOrDefaultAsync(h => h.Id == hotelId);
        }

        public Task UpdateHotelAsync(Hotel hotel)
        {
            _context.Update(hotel);
           return _context.SaveChangesAsync();
        }
    }
}
