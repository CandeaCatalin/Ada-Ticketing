using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BegaAir.TicketsManagementMicroservice.DataAccess.Entities;

public class Booking
{

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key] public int Id { get; set; }
    public Flight Flight { get; set; }
    public User User { get; set; }
    public int NoOfPassengers { get; set; }
    public bool InProgress { get; set; }
    public DateTime CreateTime { get; set; }
}