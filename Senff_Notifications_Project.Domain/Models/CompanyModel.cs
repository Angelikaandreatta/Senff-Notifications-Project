using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senff_Notifications_Project.Domain.Models
{
    public class CompanyModel
    {
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Cnpj { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        public Guid PlanId { get; set; }

        [ForeignKey("PlanId")]
        public SubscriptionPlanModel SubscriptionPlan { get; set; }
    }
}
