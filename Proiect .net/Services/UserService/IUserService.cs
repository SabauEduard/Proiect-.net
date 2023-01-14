using Proiect_.net.Models;
using Proiect_.net.Models.Enums;

namespace Proiect_.net.Services.UserService
{
    public interface IUserService
    {
        public Task CreateUser(string FirstName, string LastName, string Email, string Username, string PasswordHash, Role Role);
        public Task DeleteUser(Guid UserId);
        public Task<User> GetUser(Guid UserId);
        public Task<IEnumerable<User>> GetAllUsers();
    }
}
