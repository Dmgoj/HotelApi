using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Shared.Helpers;

namespace Contracts
{
    public interface IReservationRepository
    {
        Task<PaginatedList<Reservation>> GetAllReservationsAsync(int hotelId, int pageIndex, int pageSize, bool trackChanges);
        Task<Reservation> GetReservationAsync(int hotelId, int reservationId, bool trackChanges);
        Task CreateReservationAsync(Reservation reservation, List<int> guestIds);
        Task DeleteReservationAsync(Reservation reservation);
        Task UpdateReservationAsync(Reservation reservation);
    }
}
