using Senff_Notifications_Project.Application.DTOs;

namespace Senff_Notifications_Project.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResultService<UserDto>> Create(UserDto user);
        Task<ResultService<UserDto>> GetById(Guid id);
        Task<ResultService> Update(UserDto user);
        Task<ResultService> Delete(Guid id);
    }
}
