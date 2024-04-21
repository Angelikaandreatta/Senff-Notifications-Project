using Senff_Notifications_Project.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Senff_Notifications_Project.Application.DTOs
{
    public class CompanyDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name must be at most 100 characters.")]
        public string Name { get; set; }

        [MaxLength(20, ErrorMessage = "CNPJ must be at most 20 characters.")]
        public string Cnpj { get; set; }

        [MaxLength(100, ErrorMessage = "Email must be at most 100 characters.")]
        [EmailAddress(ErrorMessage = "Email is not in a valid format.")]
        public string Email { get; set; }

        [MaxLength(20, ErrorMessage = "Phone must be at most 20 characters.")]
        [RegularExpression(@"^\(?([0-9]{2})\)?[-. ]?([0-9]{4})[-. ]?([0-9]{4})$", ErrorMessage = "Phone is not in a valid format.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Plan ID is required.")]
        public Guid PlanId { get; set; }

        public SubscriptionPlanModel SubscriptionPlan { get; set; }
    }
}
