using BegaAir.TicketsManagementMicroservice.DataAccess;
using BegaAir.TicketsManagementMicroservice.Domain.Entities;
using BegaAir.TicketsManagementMicroservice.Repository.Contracts;
using BegaAir.TicketsManagementMicroservice.Repository.Mappers;
using Microsoft.EntityFrameworkCore;

namespace BegaAir.TicketsManagementMicroservice.Repository;

public class BookingRepository : IBookingRepository
{
    private readonly DataContext dataContext;

    public BookingRepository(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public async Task<Booking> AddBooking(User user, int flightId, int noOfPassengers)
    {
        var userFromDb = await dataContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
        var flightFromDb = await dataContext.Flights.FirstOrDefaultAsync(f => f.Id == flightId);
        if (flightFromDb == null)
        {
            throw new Exception("Flight does not exist");
        }

        if (userFromDb == null)
        {
            await dataContext.Users.AddAsync(UserMapper.DomainToDataAccessUserMapper(user));
            await dataContext.SaveChangesAsync();
        }

        var bookingFromDb =
            await dataContext.Bookings.FirstOrDefaultAsync(b => b.User.Id == user.Id && b.Flight.Id == flightId);
        if (bookingFromDb != null)
        {
            throw new Exception("Booking already exists for this flight");
        }

        userFromDb = await dataContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
        var newBooking = new DataAccess.Entities.Booking
        {
            InProgress = true,
            CreateTime = DateTime.UtcNow,
            NoOfPassengers = noOfPassengers,
            User = userFromDb,
            Flight = flightFromDb
        };
        await dataContext.Bookings.AddAsync(newBooking);
        await dataContext.SaveChangesAsync();
        return BookingMapper.DataAccessToDomainBookingMapper(newBooking);
    }

    public async Task DeleteBooking(int bookingId)
    {
        var deletedBooking = await dataContext.Bookings.FirstOrDefaultAsync(b => b.Id == bookingId);
        if (deletedBooking == null)
        {
            throw new Exception("Booking not found!");
        }

        dataContext.Bookings.Remove(deletedBooking);
        await dataContext.SaveChangesAsync();
    }

    public async Task CompleteBooking(int bookingId)
    {
        var completedBooking = await dataContext.Bookings.FirstOrDefaultAsync(b => b.Id == bookingId);
        if (completedBooking == null)
        {
            throw new Exception("Booking not found!");
        }

        completedBooking.InProgress = false;
        dataContext.Bookings.Update(completedBooking);
        await dataContext.SaveChangesAsync();
    }

    public async Task<List<Flight>> GetBookedFlights(User user)
    {
        var bookedFlights =
            await dataContext.Bookings.Where(b => b.User.Id == user.Id).Select(b => b.Flight).ToListAsync();
        List<Flight> domainFlights = new List<Flight>();
        bookedFlights.ForEach(f => domainFlights.Add(FlightMapper.DataAccessToDomainFlightMapper(f)));
        return domainFlights;
    }

    public async Task<List<Booking>> GetBookings(User user)
    {
        var bookingsFromDb = await dataContext.Bookings.Include(b=>b.User).Include(b=>b.Flight).Where(b => b.User.Id == user.Id).ToListAsync();
        List<Booking> domainBookings = new List<Booking>();
        bookingsFromDb.ForEach(b=>domainBookings.Add(BookingMapper.DataAccessToDomainBookingMapper(b)));
        return domainBookings;
    }
}