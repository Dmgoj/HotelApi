using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IReservationService
    {
        Task<RoomReadDto> CreateReservationAsync(ReservationCreateDto reservationDto);
        Task<RoomReadDto> GetReservationAsync(int reservationId, bool trackChanges);
        Task<IEnumerable<RoomReadDto>> GetReservationsByRoomAsync(int roomId, bool trackChanges);
        Task<bool> UpdateReservationAsync(int reservationId, ReservationUpdateDto reservationDto);
        Task<bool> DeleteReservationAsync(int reservationId);
    }
}
