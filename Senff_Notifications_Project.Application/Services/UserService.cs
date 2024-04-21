using Senff_Notifications_Project.Application.Services.Interfaces;
using Senff_Notifications_Project.Domain.Models;
using Senff_Notifications_Project.Domain.Repositories;

namespace Senff_Notifications_Project.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultService<UserModel>> GetUserById(Guid userId)
        {
            var user = _userRepository.GetUserById(userId);

            return ResultService.Ok<UserModel>(user);
        }

        public async Task<ResultService<UserModel>> Authenticate(string email, string password)
        {
            var user = await _userRepository.Authenticate(email, password);

            if (user == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return ResultService.Ok<UserModel>(user);
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            return false;
        }
    }
}
