namespace BegaAir.TicketsManagementMicroservice.Repository.Mappers;

public static class BookingMapper
{
    public static Domain.Entities.Booking DataAccessToDomainBookingMapper(DataAccess.Entities.Booking dataAccessBooking)
    {
        return new Domain.Entities.Booking
        {
            Id = dataAccessBooking.Id,
            InProgress = dataAccessBooking.InProgress,
            User = UserMapper.DataAccessToDomainUserMapper(dataAccessBooking.User),
            Flight = FlightMapper.DataAccessToDomainFlightMapper(dataAccessBooking.Flight),
        };
    }
}