using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BegaAir.TicketsManagementMicroservice.DataAccess.Entities;

public class Flight
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key] public int Id { get; set; }
    public DateTime ServiceStartDate { get; set; }
    public DateTime ServiceEndDate { get; set; }
    public string DepartureLocation { get; set; }
    public string ArrivalLocation { get; set; }
    public int Seats { get; set; }
    public int Price { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
}