using Senff_Notifications_Project.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Senff_Notifications_Project.Domain.Models
{
    public class SubscriptionPlanModel
    {
        public Guid Id { get; set; }

        public SubscriptionPlanType PlanType { get; set; }

        [MaxLength(3)]
        public int NumberRequests { get; set; }
    }
}
