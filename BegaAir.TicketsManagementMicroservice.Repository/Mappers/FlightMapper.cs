
namespace BegaAir.TicketsManagementMicroservice.Repository.Mappers;

public static class FlightMapper
{
    public static Domain.Entities.Flight DataAccessToDomainFlightMapper(DataAccess.Entities.Flight dataAccessFlight)
    {
        return new Domain.Entities.Flight
        {
            ArrivalLocation = dataAccessFlight.ArrivalLocation,
            ArrivalTime = dataAccessFlight.ArrivalTime,
            FlightNumber = dataAccessFlight.FlightNumber,
            DepartureLocation = dataAccessFlight.DepartureLocation,
            DepartureTime = dataAccessFlight.DepartureTime,
            Price = dataAccessFlight.Price,
            Seats = dataAccessFlight.Seats,
            Id = dataAccessFlight.Id,
            ServiceStartDate = dataAccessFlight.ServiceStartDate,
            ServiceEndDate = dataAccessFlight.ServiceEndDate,
        };
    }
    public static DataAccess.Entities.Flight DomainToDataAccessFlightMapper(Domain.Entities.Flight domainModelFlight)
    {
        return new DataAccess.Entities.Flight
        {
            Id = domainModelFlight.Id,
            FlightNumber = domainModelFlight.FlightNumber,
            ArrivalLocation = domainModelFlight.ArrivalLocation,
            ArrivalTime = domainModelFlight.ArrivalTime,
            DepartureLocation = domainModelFlight.DepartureLocation,
            DepartureTime = domainModelFlight.DepartureTime,
            Price = domainModelFlight.Price,
            Seats = domainModelFlight.Seats,
            ServiceEndDate = domainModelFlight.ServiceEndDate,
            ServiceStartDate = domainModelFlight.ServiceStartDate,
        };
    }
}