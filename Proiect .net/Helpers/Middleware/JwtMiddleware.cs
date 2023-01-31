using Proiect_.net.Helpers.Jwt;
using Proiect_.net.Repositories;
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
        
        public async Task Invoke(HttpContext httpContext, IUserRepository userRepository, IJwtUtils jwtUtils)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var userId = jwtUtils.ValidateJwtToken(token);

            if (userId != Guid.Empty)
            {
                httpContext.Items["User"] = await userRepository.FindByIdAsync(userId);
            }

            await _nextRequestDelegate(httpContext);
        }
        
    }
}
