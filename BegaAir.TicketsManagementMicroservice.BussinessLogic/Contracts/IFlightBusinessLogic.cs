using BegaAir.TicketsManagementMicroservice.Domain.Entities;

namespace BegaAir.TicketsManagementMicroservice.BussinessLogic.Contracts;

public interface IFlightBusinessLogic
{
    public Task<List<Flight>> GetAllFlights();

    Task<Flight> AddFlight(Flight newFlight);
    Task<Flight> EditFlight(Flight editedFlight);
    Task DeleteFlight(int id);
    Task<object> GetFlightLocations();
    Task<List<Flight>> GetFilteredFlights(string arrivalLocation, string departureLocation, DateTime serviceStartDate, DateTime serviceEndDate);
}