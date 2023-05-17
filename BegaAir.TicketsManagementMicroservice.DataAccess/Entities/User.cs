using System.ComponentModel.DataAnnotations;

namespace BegaAir.TicketsManagementMicroservice.DataAccess.Entities;

public class User
{
    [Key] public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
}