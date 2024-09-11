using ContosoPizza.Models.DTO;
using System.Security.Claims;

namespace ContosoPizza.Shared.Extensions
{
    public static class AuthorizationExtensions
    {
        public static UserCredentialsDTO? GetUserCredential(this HttpContext httpContext)
        {
            var principal = httpContext.User;
            if(httpContext.User?.Identity?.IsAuthenticated ?? false)
            {
                return new UserCredentialsDTO
                {
                    Name = principal.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty,
                    Id = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0",
                    Email = principal.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty,
                    PhoneNumber = principal.FindFirst(ClaimTypes.MobilePhone)?.Value ?? string.Empty,
                    RoleId = int.TryParse(principal.FindFirst(ClaimTypes.Role)?.Value, out int roleId) ? roleId : 0

                };
                
            }
            return null;
        } 
    }
}
