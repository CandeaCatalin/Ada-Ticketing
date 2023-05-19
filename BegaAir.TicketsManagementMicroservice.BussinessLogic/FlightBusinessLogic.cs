using BegaAir.TicketsManagementMicroservice.BussinessLogic.Contracts;
using BegaAir.TicketsManagementMicroservice.Domain.Entities;
using BegaAir.TicketsManagementMicroservice.Repository.Contracts;

namespace BegaAir.TicketsManagementMicroservice.BussinessLogic;

public class FlightBusinessLogic:IFlightBusinessLogic
{
    private readonly IFlightRepository flightRepository;

    public FlightBusinessLogic(IFlightRepository flightRepository)
    {
        this.flightRepository = flightRepository;
    }
    public async Task<List<Flight>> GetAllFlights()
    {
        return await flightRepository.GetAllFlights();
    }

    public async Task<Flight> AddFlight(Flight newFlight)
    {
        await newFlight.ValidateAndThrow();

        return await flightRepository.AddFlight(newFlight);
    }

    public async Task<Flight> EditFlight(Flight editedFlight)
    {
        await editedFlight.ValidateAndThrow();
        return await flightRepository.EditFlight(editedFlight);
    }

    public async Task DeleteFlight(int id)
    {
        await flightRepository.DeleteFlight(id);
    }

    public Task<object> GetFlightLocations()
    {
        return flightRepository.GetFlightLocations();
    }

    public Task<List<Flight>> GetFilteredFlights(string arrivalLocation, string departureLocation, DateTime departureTime)
    {
        return flightRepository.GetFilteredFlights(arrivalLocation, departureLocation,
             departureTime);
    }
}