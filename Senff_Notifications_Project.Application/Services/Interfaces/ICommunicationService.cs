using Senff_Notifications_Project.Application.DTOs;

namespace Senff_Notifications_Project.Application.Services.Interfaces
{
    public interface ICommunicationService
    {
        ResultService SendSms(SmsDto sms);
    }
}
