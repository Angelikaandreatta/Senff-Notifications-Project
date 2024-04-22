using System.ComponentModel.DataAnnotations;

namespace Senff_Notifications_Project.Application.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name must be at most 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email is not in a valid format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 8 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [RegularExpression(@"^\(?([0-9]{2})\)?[-. ]?([0-9]{4})[-. ]?([0-9]{4})$", ErrorMessage = "Phone is not in a valid format.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Company ID is required.")]
        public Guid CompanyId { get; set; }
    }
}
