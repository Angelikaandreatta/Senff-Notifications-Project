using Senff_Notifications_Project.Domain.Models;

namespace Senff_Notifications_Project.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResultService<UserModel>> GetUserById(Guid userId);
        Task<ResultService<UserModel>> Authenticate(string email, string password);
    }
}
