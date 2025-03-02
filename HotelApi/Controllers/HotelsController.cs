using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repository;
using Shared.DTO;
using Services;
using Services.Contracts;
using Shared.Helpers;

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _service;

        public HotelsController(IHotelService service)
        {
            _service = service;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<PaginatedList<HotelReadDto>>> GetHotels([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
        {
            var hotels = await _service.GetAllHotelsAsync(pageIndex, pageSize, false);

            return Ok(hotels);
        }


        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            try
            {
                var hotel = await _service.GetHotelAsync(id, false);
                return Ok(hotel);
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

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, HotelUpdateDto hotelDto)
        {
           

           await _service.UpdateHotelAsync(id, hotelDto);

            return NoContent();
        }

        //// POST: api/Hotels
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(HotelCreateDto hotelDto)
        {
            if (hotelDto == null)
                return BadRequest("Hotel data is required.");

            var createdHotel = await _service.CreateHotelAsync(hotelDto);

            return CreatedAtAction(nameof(GetHotel), new { id = createdHotel.Id }, createdHotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            await _service.DeleteHotelAsync(id);
            
            return NoContent();
        }

      
    }
}
