using BegaAir.TicketsManagementMicroservice.Domain.Validators;
using FluentValidation;

namespace BegaAir.TicketsManagementMicroservice.Domain.Entities;

public class Flight
{
    public static FlightValidator Validator => new();
    public int Id { get; set; }
    public string FlightNumber { get; set; }
    public DateTime ServiceStartDate { get; set; }
    public DateTime ServiceEndDate { get; set; }
    public string DepartureLocation { get; set; }
    public string ArrivalLocation { get; set; }
    public int Seats { get; set; }
    public int Price { get; set; }
    public string DepartureTime { get; set; }
    public string ArrivalTime { get; set; }
    public async Task ValidateAndThrow()
    {
        await Validator.ValidateAndThrowAsync(this);
    }
}