using AutoMapper;
using Senff_Notifications_Project.Application.DTOs;
using Senff_Notifications_Project.Application.Services.Interfaces;
using Senff_Notifications_Project.Domain.Models;
using Senff_Notifications_Project.Domain.Repositories;

namespace Senff_Notifications_Project.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IRepository<NotificationModel> _repository;
        private readonly IMapper _mapper;

        public NotificationService(IRepository<NotificationModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ResultService<NotificationDto>> Create(NotificationDto notificationDto)
        {
            if (notificationDto == null)
                return ResultService.Fail<NotificationDto>("Object must be provided.");

            var notificationModel = _mapper.Map<NotificationDto, NotificationModel>(notificationDto);
            var createdNotification = await _repository.Create(notificationModel);
            var createdNotificationDto = _mapper.Map<NotificationModel, NotificationDto>(createdNotification);

            return ResultService.Ok(createdNotificationDto);
        }

        public async Task<ResultService<NotificationDto>> GetById(Guid id)
        {
            var notification = await _repository.GetById(id);

            if (notification == null)
                return ResultService.Fail<NotificationDto>("Notification not found.");

            var notificationDto = _mapper.Map<NotificationModel, NotificationDto>(notification);
            return ResultService.Ok(notificationDto);
        }

        public async Task<ResultService> Update(NotificationDto notificationDto)
        {
            if (notificationDto == null)
                return ResultService.Fail("Object must be provided.");

            var notificationModel = _mapper.Map<NotificationDto, NotificationModel>(notificationDto);
            await _repository.Update(notificationModel);

            return ResultService.Ok("Notification updated successfully.");
        }

        public async Task<ResultService> Delete(Guid id)
        {
            var notification = await _repository.GetById(id);

            if (notification == null)
                return ResultService.Fail("Notification not found.");

            await _repository.Delete(notification);
            return ResultService.Ok("Notification deleted successfully.");
        }
    }
}
