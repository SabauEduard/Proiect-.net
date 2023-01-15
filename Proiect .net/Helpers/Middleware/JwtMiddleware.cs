using Proiect_.net.Helpers.Jwt;
using Proiect_.net.Services.UserService;

namespace Proiect_.net.Helpers.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _nextRequestDelegate;

        public JwtMiddleware(RequestDelegate requestDelegate)
        {
            _nextRequestDelegate = requestDelegate;
        }
        
        public async Task Invoke(HttpContext httpContext, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var userId = jwtUtils.ValidateJwtToken(token);

            if (userId != Guid.Empty)
            {
                httpContext.Items["User"] = await userService.GetUserById(userId);
            }

            await _nextRequestDelegate(httpContext);
        }
        
    }
}
