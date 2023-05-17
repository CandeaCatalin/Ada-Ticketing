using System.IdentityModel.Tokens.Jwt;
using BegaAir.TicketsManagementMicroservice.Domain.Entities;

namespace BegaAir.TicketsManagementMicroservice.Services;

public static class JwtService
{
    public static User getUserFromJwt(string jwtToken)
    {
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(jwtToken);
        var token = jsonToken as JwtSecurityToken;
        var userId = token.Claims.First(claim => claim.Type == "sub").Value;
        var userEmail = token.Claims.First(claim => claim.Type == "email").Value;
        var name = token.Claims.First(claim => claim.Type == "unique_name").Value;
        var role = token.Claims.FirstOrDefault(claim => claim.Type == "role")!=null? token.Claims.First(claim => claim.Type == "role").Value:"User";
        var user = new User
            { Id = new Guid(userId), Email = userEmail, Name = name, Role = role};

        return user;
    }
}