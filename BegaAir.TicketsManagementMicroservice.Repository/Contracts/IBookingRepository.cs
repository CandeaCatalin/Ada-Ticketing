using BegaAir.TicketsManagementMicroservice.Domain.Entities;

namespace BegaAir.TicketsManagementMicroservice.Repository.Contracts;

public interface IBookingRepository
{
    Task<Booking> AddBooking(User user, int flightId, int noOfPassengers);
    Task DeleteBooking(int bookingId);
    Task CompleteBooking(int bookingId);
    Task<List<Flight>> GetBookedFlights(User user);
    Task<List<Booking>> GetBookings(User user);
}