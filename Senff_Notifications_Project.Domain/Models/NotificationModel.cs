using Senff_Notifications_Project.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senff_Notifications_Project.Domain.Models
{
    public class NotificationModel
    {
        [Key]
        public Guid Id { get; set; }

        public NotificationType NotificationType { get; set; }

        public DateTime Data { get; set; }

        [MaxLength(20)]
        public string Ip { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public UserModel User { get; set; }
    }
}
