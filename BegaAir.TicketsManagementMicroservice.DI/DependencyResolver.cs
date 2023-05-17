using BegaAir.TicketsManagementMicroservice.BussinessLogic;
using BegaAir.TicketsManagementMicroservice.BussinessLogic.Contracts;
using BegaAir.TicketsManagementMicroservice.Repository;
using BegaAir.TicketsManagementMicroservice.Repository.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace BegaAir.TicketsManagementMicroservice.DI;

public static class DependencyResolver
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IFlightRepository, FlightRepository>();

        services.AddScoped<IUserBusinessLogic, UserBusinessLogic>();
        services.AddScoped<IBookingBusinessLogic, BookingBusinessLogic>();
        services.AddScoped<IFlightBusinessLogic, FlightBusinessLogic>();

        return services;
    }
}