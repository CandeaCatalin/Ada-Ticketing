using BegaAir.TicketsManagementMicroservice.BussinessLogic.Contracts;
using BegaAir.TicketsManagementMicroservice.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BegaAir.TicketsManagementMicroservice.REST.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingBusinessLogic bookingBusinessLogic;
       
        public BookingController(IBookingBusinessLogic bookingBusinessLogic)
        {
            this.bookingBusinessLogic = bookingBusinessLogic;
        }

        [HttpPost("addBooking")]
        public async Task<IActionResult> AddBooking(int flightId, int noOfPassengers)
        {
            var jwtToken = await HttpContext.GetTokenAsync("access_token");
            var user = JwtService.getUserFromJwt(jwtToken);
            return Ok(await bookingBusinessLogic.AddBooking(user,flightId, noOfPassengers));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBooking(int bookingId)
        {
            await bookingBusinessLogic.DeleteBooking(bookingId);
            return Ok();
        }

        [HttpPut("completeBooking")]
        public async Task<IActionResult> CompleteBooking(int bookingId)
        {
            await bookingBusinessLogic.CompleteBooking(bookingId);
            return Ok();
        }

        [HttpGet("getBookedFlights")]
        public async Task<IActionResult> GetBookedFlights()
        {
            var jwtToken = await HttpContext.GetTokenAsync("access_token");
            var user = JwtService.getUserFromJwt(jwtToken);
            var result = await bookingBusinessLogic.GetBookedFlights(user);
            return Ok(result);
        }        
        [HttpGet("getBookings")]
        public async Task<IActionResult> GetBookings()
        {
            var jwtToken = await HttpContext.GetTokenAsync("access_token");
            var user = JwtService.getUserFromJwt(jwtToken);
            var result = await bookingBusinessLogic.GetBookings(user);
            return Ok(result);
        }
    }
}
