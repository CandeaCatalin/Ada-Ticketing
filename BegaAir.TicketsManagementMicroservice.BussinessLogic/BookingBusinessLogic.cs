using BegaAir.TicketsManagementMicroservice.BussinessLogic.Contracts;
using BegaAir.TicketsManagementMicroservice.Domain.Entities;
using BegaAir.TicketsManagementMicroservice.Repository.Contracts;

namespace BegaAir.TicketsManagementMicroservice.BussinessLogic;

public class BookingBusinessLogic : IBookingBusinessLogic
{
    private readonly IBookingRepository bookingRepository;

    public BookingBusinessLogic(IBookingRepository bookingRepository)
    {
        this.bookingRepository = bookingRepository;
    }

    public async Task<Booking> AddBooking(User user, int flightId)
    {
        return await bookingRepository.AddBooking(user, flightId);
    }

    public async Task DeleteBooking(int bookingId)
    {
        await bookingRepository.DeleteBooking(bookingId);
    }

    public async Task CompleteBooking(int bookingId)
    {

        await bookingRepository.CompleteBooking(bookingId);
    }

    public async Task<List<Flight>> GetBookedFlights(User user)
    {
        return await bookingRepository.GetBookedFlights(user);
    }

    public async Task<List<Booking>> GetBookings(User user)
    {
        return await bookingRepository.GetBookings(user);
    }
}