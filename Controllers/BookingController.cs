using ClubManagementAPI.DTO;
using ClubManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClubManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("createBooking")]
        public async Task<IActionResult> CreateBooking([FromBody] BookingDTO bookingDto)
        {
            var response = await _bookingService.CreateBookingAsync(bookingDto);
            return StatusCode(response.StatusCode, response);
        }
    }
}
