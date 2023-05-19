using BegaAir.TicketsManagementMicroservice.DataAccess;
using BegaAir.TicketsManagementMicroservice.Domain.Entities;
using BegaAir.TicketsManagementMicroservice.Repository.Contracts;
using BegaAir.TicketsManagementMicroservice.Repository.Mappers;
using Microsoft.EntityFrameworkCore;

namespace BegaAir.TicketsManagementMicroservice.Repository;

public class FlightRepository:IFlightRepository
{
    private readonly DataContext dataContext;

    public FlightRepository(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }
    public async Task<List<Flight>> GetAllFlights()
    {
        var flightsFromDb = await dataContext.Flights.ToListAsync();
        var domainFlights = new List<Flight>();
        
        flightsFromDb.ForEach(flight => domainFlights.Add(FlightMapper.DataAccessToDomainFlightMapper(flight)));
        
        return domainFlights;
    }

    public async Task<Flight> AddFlight(Flight newFlight)
    {
        var addToDbFlight = FlightMapper.DomainToDataAccessFlightMapper(newFlight);

        await dataContext.Flights.AddAsync(addToDbFlight);
        await dataContext.SaveChangesAsync();
        return FlightMapper.DataAccessToDomainFlightMapper(addToDbFlight);
    }

    public async Task<Flight> EditFlight(Flight editedFlight)
    {
        var flightFromDb = await dataContext.Flights.FirstOrDefaultAsync(flight => flight.Id == editedFlight.Id);
        if (flightFromDb == null)
        {
            throw new Exception("Flight was not found!");
        }

        flightFromDb.ArrivalLocation = editedFlight.ArrivalLocation;
        flightFromDb.ArrivalTime = editedFlight.ArrivalTime;
        flightFromDb.FlightNumber = editedFlight.FlightNumber;
        flightFromDb.DepartureLocation =editedFlight.DepartureLocation;
        flightFromDb.DepartureTime = editedFlight.DepartureTime;
        flightFromDb.Price = editedFlight.Price;
        flightFromDb.Seats = editedFlight.Seats;
        flightFromDb.ServiceEndDate =editedFlight.ServiceEndDate;
        flightFromDb.ServiceStartDate = editedFlight.ServiceStartDate;
        
        await dataContext.SaveChangesAsync();
        return FlightMapper.DataAccessToDomainFlightMapper(flightFromDb);
    }

    public async Task DeleteFlight(int id)
    {
        var flightToBeDeleted = await dataContext.Flights.FirstOrDefaultAsync(flight => flight.Id == id);
        if (flightToBeDeleted == null)
        {
            throw new Exception("Flight was not found!");
        }
        dataContext.Flights.Remove(flightToBeDeleted);
        await dataContext.SaveChangesAsync();
    }

    public async Task<object> GetFlightLocations()
    {
        var arrivalLocations =await dataContext.Flights.Select(x=>x.ArrivalLocation).Distinct().ToListAsync();
        var departureLocations = await dataContext.Flights.Select(x => x.DepartureLocation).Distinct().ToListAsync();
        return new { departureLocations, arrivalLocations };
    }

    public async Task<List<Flight>> GetFilteredFlights(string arrivalLocation, string departureLocation, DateTime departureTime)
    {
        var flightsFromDb = await dataContext.Flights.Where(x=>x.DepartureLocation == departureLocation && x.ArrivalLocation == arrivalLocation && x.ServiceStartDate <= departureTime && x.ServiceEndDate >= departureTime).ToListAsync();
        var domainFlights = new List<Flight>();

        flightsFromDb.ForEach(flight => domainFlights.Add(FlightMapper.DataAccessToDomainFlightMapper(flight)));

        return domainFlights;
    }
}