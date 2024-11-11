using System.Security.Claims;

namespace PointOfSale.Middlewares;

public class RoleAuthorizationMiddleware
{
    private readonly RequestDelegate _next;

    public RoleAuthorizationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        // Periksa apakah pengguna sudah diautentikasi
        if (context.User.Identity!.IsAuthenticated)
        {
            // Ambil role pengguna dari klaim
            var userRoles = context.User.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList();

            // Cek apakah role 'Admin' atau 'User' ada
            if (userRoles.Contains("Admin") || userRoles.Contains("User"))
            {
                await _next(context); // Lanjutkan ke request berikutnya
                return;
            }
        }

        // Jika tidak memenuhi syarat, kembalikan Forbidden
        context.Response.StatusCode = StatusCodes.Status403Forbidden;
        await context.Response.WriteAsync("Forbidden: You do not have permission to access this resource.");
    }
}
