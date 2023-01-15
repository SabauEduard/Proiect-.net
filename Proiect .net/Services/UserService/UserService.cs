using Proiect_.net.Helpers.Jwt;
using Proiect_.net.Models;
using Proiect_.net.Models.DTOs.Users;
using Proiect_.net.Models.Enums;
using Proiect_.net.Repositories.UnitOfWork;

namespace Proiect_.net.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtUtils _jwtUtils;

        public UserService(IUnitOfWork unitOfWork, IJwtUtils jwtUtils)
        {
            _unitOfWork = unitOfWork;
            _jwtUtils = jwtUtils;
        }
        public async Task<UserResponseDTO> CreateUser(string FirstName, string LastName, string Email, string Username, string Password)
        {
            var user = new User()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Username = Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(Password),
                Role = Role.User
            };
            await _unitOfWork.userRepository.CreateAsync(user);
            await _unitOfWork.SaveAsync();

            var token = _jwtUtils.GenerateJwtToken(user);

            return new UserResponseDTO(user, token);
        }
        public async Task<UserResponseDTO?> Authenticate(string Username, string Password)
        {
            var user = _unitOfWork.userRepository.FindByUsername(Username);
            if(user is null)
                user = _unitOfWork.userRepository.FindByEmail(Username);

            if(user is null)
                return null;

            if (!BCrypt.Net.BCrypt.Verify(Password, user.PasswordHash))
                return null;

            var token = _jwtUtils.GenerateJwtToken(user);

            return new UserResponseDTO(user, token);
        }
        public async Task DeleteUserById(Guid UserId)
        {
            var user = await _unitOfWork.userRepository.FindByIdAsync(UserId);
            if(user == null)
                return;
            _unitOfWork.userRepository.Delete(user);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _unitOfWork.userRepository.GetAllAsync();
        }

        public async Task<User> GetUserById(Guid UserId)
        {
            return await _unitOfWork.userRepository.FindByIdAsync(UserId);
        }
        public User GetUserByUsername(string Username)
        {
            return _unitOfWork.userRepository.FindByUsername(Username);
        }
    }
}
