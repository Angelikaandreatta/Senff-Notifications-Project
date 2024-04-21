using Senff_Notifications_Project.Domain.Models;

namespace Senff_Notifications_Project.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<UserModel> GetUserById(Guid id);
    }
}
