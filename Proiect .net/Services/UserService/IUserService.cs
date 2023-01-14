using Proiect_.net.Models;
using Proiect_.net.Models.Enums;

namespace Proiect_.net.Services.UserService
{
    public interface IUserService
    {
        public Task CreateUser(string FirstName, string LastName, string Email, string Username, string PasswordHash, Role Role);
        public Task DeleteUserById(Guid UserId);
        public Task<User> GetUserById(Guid UserId);
        public User GetUserByUsername(string Username);
        public Task<IEnumerable<User>> GetAllUsers();
    }
}
