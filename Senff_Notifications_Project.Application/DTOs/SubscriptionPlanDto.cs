using Senff_Notifications_Project.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Senff_Notifications_Project.Application.DTOs
{
    public class SubscriptionPlanDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Plan type is required.")]
        public SubscriptionPlanType PlanType { get; set; }

        [Required(ErrorMessage = "Number of requests is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of requests must be a positive integer.")]
        public int NumberRequests { get; set; }
    }
}
