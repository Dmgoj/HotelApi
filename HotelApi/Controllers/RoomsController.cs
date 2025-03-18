using Entities;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Contracts;
using Shared.Helpers;

namespace HotelApi.Controllers
{
    [Route("api/Hotels/{hotelId}/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomsController(IRoomService roomService) 
        {
            _roomService = roomService;
        }


        [HttpGet]
        public async Task<ActionResult<PaginatedList<RoomReadDto>>> GetRooms(int hotelId,[FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
        {
            var rooms = await _roomService.GetAllRoomsAsync(hotelId, pageIndex, pageSize, false);
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomReadDto>> GetRoom(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid room ID.");
            }

            try
            {
                var room = await _roomService.GetRoomAsync(id, false);
                return Ok(room);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<RoomReadDto>> PostRoom(int hotelId, RoomCreateDto roomDto)
        {
            if (hotelId <= 0)
            {
                return BadRequest("Invalid hotel ID.");
            }
            try
            {
                var room = await _roomService.CreateRoomAsync(hotelId, roomDto);
                return CreatedAtAction("GetRoom", new { hotelId = hotelId, id = room.Id }, room);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Hotel with ID {hotelId} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid room ID.");
            }

            try
            {
                await _roomService.DeleteRoom(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutRoom(int id, RoomUpdateDto roomDto)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            try
            {
                await _roomService.UpdateRoomAsync(id, roomDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

    }
}
