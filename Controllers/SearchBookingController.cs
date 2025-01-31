using ClubManagementAPI.DTO;
using ClubManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClubManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchBookingController : ControllerBase
    {
        private readonly ISearchBookingService _searchBookingService;

        public SearchBookingController(ISearchBookingService searchBookingService)
        {
            _searchBookingService = searchBookingService;
        }

        [HttpPost("search-bookings-by-member-or-date-range")]
        public async Task<IActionResult> SearchBookings([FromBody] SearchBookingDTO criteria)
        {
            var result = await _searchBookingService.SearchBookingsAsync(criteria);
            return StatusCode(result.StatusCode, result);
        }
    }
}
