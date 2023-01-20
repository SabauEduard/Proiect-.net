using Proiect_.net.Models;
using Proiect_.net.Models.DTOs.Users;
using Proiect_.net.Models.Enums;

namespace Proiect_.net.Services.UserService
{
    public interface IUserService
    {
        public Task<UserResponseDTO?> CreateUser(string FirstName, string LastName, string Email, string Username, string Password);
        public Task<UserResponseDTO?> CreateAdmin(string FirstName, string LastName, string Email, string Username, string Password);
        public Task<UserResponseDTO?> Authenticate(string Username, string Password);
        public Task<UserResponseDTO?> RefreshToken(string OldToken);
        public Task DeleteUserById(Guid UserId);
        public Task<User?> GetUserById(Guid UserId);
        public User GetUserByUsername(string Username);
        public Task<IEnumerable<User>> GetAllUsers();
        public IEnumerable<Book?> GetBooksBorrowedByUser(string Username);

    }
}
