using Microsoft.AspNetCore.Mvc;
using Senff_Notifications_Project.Application.DTOs;
using Senff_Notifications_Project.Application.Services.Interfaces;

namespace Senff_Notifications_Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationController : ControllerBase
    {
        private readonly ICommunicationService _communication;

        public CommunicationController(ICommunicationService communication)
        {
            _communication = communication;
        }

        [HttpPost]
        public ActionResult SendSms([FromBody] SmsDto sms)
        {
            var result = _communication.SendSms(sms);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
