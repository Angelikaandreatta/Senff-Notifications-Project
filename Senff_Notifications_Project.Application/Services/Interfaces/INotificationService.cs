using Senff_Notifications_Project.Application.DTOs;

namespace Senff_Notifications_Project.Application.Services.Interfaces
{
    public interface INotificationService
    {
        Task<ResultService<NotificationDto>> Create(NotificationDto notification);
        Task<ResultService<NotificationDto>> GetById(Guid id);
        Task<ResultService> Update(NotificationDto notification);
        Task<ResultService> Delete(Guid id);
    }
}
