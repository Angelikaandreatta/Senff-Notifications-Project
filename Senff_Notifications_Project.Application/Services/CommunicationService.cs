using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json.Linq;
using Senff_Notifications_Project.Application.DTOs;
using Senff_Notifications_Project.Application.Services.Interfaces;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Senff_Notifications_Project.Application.Services
{
    public class CommunicationService : ICommunicationService
    {
        public ResultService SendSms(SmsDto sms)
        {
            var acconuntSid = "AC2fc141e1cbf09a3310199a0d84ec0439";
            var authToken = "e7879f77699214dbe387c71fe1fe7c8c";

            TwilioClient.Init(acconuntSid, authToken);

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber("5541992765726"))
            {
                MessagingServiceSid = "MGa7dd2d6f97024f90fcf8733f45df87b3",
                Body = sms.Message
            };

            var messageSent = MessageResource.Create(messageOptions);

            if (messageSent.Status == MessageResource.StatusEnum.Accepted)
                return ResultService.Ok("SMS sent successfully.");
            else
                return ResultService.Fail("error when sending sms." + messageSent.ErrorMessage);
        }

        public async Task<ResultService> SendEmail(EmailDto email)
        {
            List<JObject> recipientList = new();
            foreach (string recipientEmail in email.Recipients)
            {
                recipientList.Add(new JObject { { "Email", recipientEmail } });
            };

            MailjetClient client = new("98cc9f8ff097af52b1770a8276c9369e", "ba2a02485ff8b5067251634b19a5b153");
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }

            .Property(Send.FromEmail, email.FromEmail)
            .Property(Send.FromName, email.FromName)
            .Property(Send.Subject, email.Subject)
            .Property(Send.TextPart, email.TextPart)
            .Property(Send.HtmlPart, email.HtmlPart)
            .Property(Send.Recipients, new JArray(recipientList));

            MailjetResponse response = await client.PostAsync(request);
            if (response.IsSuccessStatusCode)
                return ResultService.Ok("Email sent successfully.");
            else
                return ResultService.Fail("error when sending email." + response.GetErrorMessage());
        }
    }
}
