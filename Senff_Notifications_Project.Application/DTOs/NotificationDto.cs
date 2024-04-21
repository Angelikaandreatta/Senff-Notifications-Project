using Senff_Notifications_Project.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Senff_Notifications_Project.Application.DTOs
{
    public class NotificationDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Notification type is required.")]
        public NotificationType NotificationType { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime Data { get; set; }

        [MaxLength(20, ErrorMessage = "IP address must be at most 20 characters.")]
        public string Ip { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public Guid UserId { get; set; }

        public UserDto User { get; set; }
    }
}
