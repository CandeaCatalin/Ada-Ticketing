using BegaAir.TicketsManagementMicroservice.BussinessLogic.Contracts;
using BegaAir.TicketsManagementMicroservice.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BegaAir.TicketsManagementMicroservice.REST.Controllers
{
    [ApiController]

    [Route("[controller]")]
    [Authorize]
    public class FlightController : ControllerBase
    {
        private readonly IFlightBusinessLogic flightBusinessLogic;

        public FlightController(IFlightBusinessLogic flightBusinessLogic)
        {
            this.flightBusinessLogic = flightBusinessLogic;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var flights = await flightBusinessLogic.GetAllFlights();
            return Ok(flights);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddFlight(Flight newFlight)
        {
            var addResult = await flightBusinessLogic.AddFlight(newFlight);
            return Ok(addResult);
        }

        [HttpPatch]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditFlight(Flight editedFlight)
        {
            var editedResult = await flightBusinessLogic.EditFlight(editedFlight);
            return Ok(editedResult);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            await flightBusinessLogic.DeleteFlight(id);
            return Ok();
        }

        [HttpGet("locations")]
        public async Task<IActionResult> GetFlightLocations()
        {
            var result = await flightBusinessLogic.GetFlightLocations();
            return Ok(result);
        }

        [HttpGet("filteredFlights")]
        public async Task<IActionResult> GetFilteredValued(string departureLocation, string arrivalLocation,
            DateTime serviceStartDate, DateTime serviceEndDate)
        {
            var flights = await flightBusinessLogic.GetFilteredFlights(arrivalLocation, departureLocation,
                serviceStartDate, serviceEndDate);
            return Ok(flights);
        }
    }
}
