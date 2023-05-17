using BegaAir.TicketsManagementMicroservice.Domain.Entities;
using FluentValidation;

namespace BegaAir.TicketsManagementMicroservice.Domain.Validators;
public class FlightValidator : AbstractValidator<Flight>
{
    public FlightValidator()
    {
        RuleFor(x => x.DepartureLocation).NotEmpty().WithMessage("Please provide a value for departure location!");
        RuleFor(x => x.ArrivalLocation).NotEmpty().WithMessage("Please provide a value for arrival location!");
        RuleFor(x => x.Price).Must(BeAPositiveNumber).WithMessage("Price should be great or equal to 0!");
        RuleFor(x => x.ArrivalTime).NotEmpty().GreaterThan(x => x.DepartureTime)
            .WithMessage("Arrival time should be in the future of departure time");
        RuleFor(x => x.ServiceEndDate).NotEmpty().GreaterThan(x => x.ServiceStartDate)
            .WithMessage("Service end date should be in the future of service start date");
        RuleFor(x => x.DepartureTime).NotEmpty().WithMessage("Departure time must be populated!");
        RuleFor(x => x.ServiceStartDate).NotEmpty().WithMessage("Service start date must be populated!");
        RuleFor(x => x.Seats).Must(BeAPositiveNumber).WithMessage("Seats number must be greater or equal  than 0!");
    }
    private bool BeAPositiveNumber(int price)
    {
        return price is >= 0;
    }
}