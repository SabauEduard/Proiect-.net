using Proiect_.net.Models;
using Proiect_.net.Models.Enums;
using Proiect_.net.Repositories.UnitOfWork;

namespace Proiect_.net.Services.UserService
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreateUser(string FirstName, string LastName, string Email, string Username, string PasswordHash, Role Role)
        {
            var user = new User()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Username = Username,
                PasswordHash = PasswordHash,
                Role = Role
            };
            await _unitOfWork.userRepository.CreateAsync(user);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteUser(Guid UserId)
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

        public async Task<User> GetUser(Guid UserId)
        {
            return await _unitOfWork.userRepository.FindByIdAsync(UserId);
        }
    }
}
