using Proiect_.net.Models;

namespace Proiect_.net.Helpers.Jwt
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public Guid ValidateJwtToken(string token);
    }
}
