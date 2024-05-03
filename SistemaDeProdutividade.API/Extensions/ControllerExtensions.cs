using System.Security.Claims;

namespace SistemaDeProdutividade.API.Extensions;

public static class ControllerExtensions
{
    public static string CPF(this System.Security.Claims.ClaimsPrincipal user)
    {
        return user.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;
    }
}
