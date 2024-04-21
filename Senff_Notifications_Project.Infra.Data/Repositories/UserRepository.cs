using Microsoft.EntityFrameworkCore;
using Senff_Notifications_Project.Domain.Models;
using Senff_Notifications_Project.Domain.Repositories;
using Senff_Notifications_Project.Infra.Data.Context;

namespace Senff_Notifications_Project.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dbContext;

        public UserRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserModel> GetUserById(Guid id)
        {
            return await _dbContext.User.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
