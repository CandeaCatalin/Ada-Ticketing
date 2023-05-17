
namespace BegaAir.TicketsManagementMicroservice.Repository.Mappers;

public static class UserMapper
{
    public static DataAccess.Entities.User DomainToDataAccessUserMapper(Domain.Entities.User domainUser)
    {
        return new DataAccess.Entities.User
        {
            Email = domainUser.Email,
            Id = domainUser.Id,
            Name = domainUser.Name,
            Role = domainUser.Role,
        };
    }
    public static Domain.Entities.User DataAccessToDomainUserMapper(DataAccess.Entities.User dataAccessUser)
    {
        return new Domain.Entities.User
        {
            Email = dataAccessUser.Email,
            Id = dataAccessUser.Id,
            Name = dataAccessUser.Name,
            Role = dataAccessUser.Role,
        };
    }
}