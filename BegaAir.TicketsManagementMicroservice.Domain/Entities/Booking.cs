namespace BegaAir.TicketsManagementMicroservice.Domain.Entities;

public class Booking
{
    public int Id { get; set; }
    public Flight Flight { get; set; }
    public User User { get; set; }
    public bool InProgress { get; set; }
}