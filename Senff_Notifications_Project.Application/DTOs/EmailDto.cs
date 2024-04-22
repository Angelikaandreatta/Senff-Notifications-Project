namespace Senff_Notifications_Project.Application.DTOs
{
    public class EmailDto
    {
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string Subject { get; set; }
        public string TextPart { get; set; }
        public string HtmlPart { get; set; }
        public List<string> Recipients { get; set; }
    }
}
