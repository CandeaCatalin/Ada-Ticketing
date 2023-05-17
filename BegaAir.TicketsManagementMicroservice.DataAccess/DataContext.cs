using BegaAir.TicketsManagementMicroservice.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BegaAir.TicketsManagementMicroservice.DataAccess;

public class DataContext :DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Booking> Bookings { get; set; }
}