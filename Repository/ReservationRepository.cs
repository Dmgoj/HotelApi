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
    public class ReservationRepository : IReservationRepository
    {
        private readonly RepositoryContext _context;

        public ReservationRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }
        public async Task CreateReservationAsync(Reservation reservation, List<int> guestIds)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync(); 

            var reservationGuests = guestIds.Select(guestId => new ReservationGuest
            {
                ReservationId = reservation.Id,
                GuestId = guestId
            }).ToList();

            _context.ReservationGuests.AddRange(reservationGuests);
            await _context.SaveChangesAsync();
        }

       

        public async Task DeleteReservationAsync(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }

        public Task<PaginatedList<Reservation>> GetAllReservationsAsync(int hotelId, int pageIndex, int pageSize, bool trackChanges)
        {
            var query = trackChanges ? _context.Reservations : _context.Reservations.AsNoTracking();
            query = query.Where(r => r.HotelId == hotelId).Include(r => r.Hotel);
            return PaginatedList<Reservation>.CreateAsync(query, pageIndex, pageSize);
        }

        public async Task<Reservation> GetReservationAsync(int hotelId, int reservationId, bool trackChanges)
        {
            IQueryable<Reservation> query = _context.Reservations.Include(r => r.Hotel);

            if (!trackChanges)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(r => r.Id == reservationId);
        }

        public Task UpdateReservationAsync(Reservation reservation)
        {
            _context.Update(reservation);
            return _context.SaveChangesAsync();
        }
    }
}
