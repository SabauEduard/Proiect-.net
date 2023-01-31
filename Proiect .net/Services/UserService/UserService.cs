using Proiect_.net.Helpers.Jwt;
using Proiect_.net.Models;
using Proiect_.net.Models.DTOs.Books;
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
        public async Task<UserResponseDTO?> CreateUser(string FirstName, string LastName, string Email, string Username, string Password)
        {
            var check_user = _unitOfWork.userRepository.FindByUsername(Username);
            if (check_user is not null)
                return null;

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
            var refreshToken = _jwtUtils.GenerateRefreshToken(user);

            return new UserResponseDTO(user, token, refreshToken);
        }
        public async Task<UserResponseDTO?> CreateAdmin(string FirstName, string LastName, string Email, string Username, string Password)
        {
            var check_user = _unitOfWork.userRepository.FindByUsername(Username);
            if (check_user is not null)
                return null;

            var admin = new User()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Username = Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(Password),
                Role = Role.Admin
            };
            await _unitOfWork.userRepository.CreateAsync(admin);
            await _unitOfWork.SaveAsync();

            var token = _jwtUtils.GenerateJwtToken(admin);
            var refreshToken = _jwtUtils.GenerateRefreshToken(admin);

            return new UserResponseDTO(admin, token, refreshToken);
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
            var refreshToken = _jwtUtils.GenerateRefreshToken(user);

            return new UserResponseDTO(user, token, refreshToken);
        }

        public async Task<UserResponseDTO?> RefreshToken(string OldRefreshToken)
        {
            Guid userId = _jwtUtils.ValidateJwtToken(OldRefreshToken);
            if (userId == Guid.Empty)
                return null;

            var user = await _unitOfWork.userRepository.FindByIdAsync(userId);
            var newToken = _jwtUtils.GenerateJwtToken(user);
            var refreshToken = _jwtUtils.GenerateRefreshToken(user);

            return new UserResponseDTO(user, newToken, refreshToken);

        }
        public async Task DeleteUserById(Guid UserId)
        {
            var user = await _unitOfWork.userRepository.FindByIdAsync(UserId);
            if(user == null)
                return;
   
            _unitOfWork.userRepository.Delete(user);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<UserWithoutTokensResponseDTO>> GetAllUsers()
        {
            var users = await _unitOfWork.userRepository.GetAllAsync();
            return users.ConvertAll(u => new UserWithoutTokensResponseDTO(u));          
        }

        public async Task<UserWithoutTokensResponseDTO> GetUserById(Guid UserId)
        {
            var user = await _unitOfWork.userRepository.FindByIdAsync(UserId);
            return new UserWithoutTokensResponseDTO(user);
        }
        public UserWithoutTokensResponseDTO GetUserByUsername(string Username)
        {
            var user = _unitOfWork.userRepository.FindByUsername(Username);
            return new UserWithoutTokensResponseDTO(user);
        }

        public IEnumerable<BookResponseDTO?> GetBooksBorrowedByUser(string Username)
        {
            var user = _unitOfWork.userRepository.FindByUsername(Username);
            var books = _unitOfWork.userRepository.BoooksBorrowedByUser(user.Id).ToList();
            return books.ConvertAll(b => new BookResponseDTO(b));
        }

        public IEnumerable<UserWithPenaltiesResponseDTO?> GetPenaltiesOfUsers()
        {
            var users = _unitOfWork.userRepository.PenaltiesOfUsers().ToList();
            return users.ConvertAll(u => new UserWithPenaltiesResponseDTO(u));
        }
    }
}
