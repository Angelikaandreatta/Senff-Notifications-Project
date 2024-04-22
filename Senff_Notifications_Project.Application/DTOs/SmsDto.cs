using System.ComponentModel.DataAnnotations;

namespace Senff_Notifications_Project.Application.DTOs
{
    public class SmsDto
    {
        [MaxLength(300, ErrorMessage = "Message must be at most 300 characters.")]
        public string Message { get; set; }
    }
}
