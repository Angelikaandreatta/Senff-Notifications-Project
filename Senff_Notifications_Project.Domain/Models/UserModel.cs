using System.ComponentModel.DataAnnotations.Schema;

namespace Senff_Notifications_Project.Domain.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public Guid CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public CompanyModel Company { get; set; }
    }
}
