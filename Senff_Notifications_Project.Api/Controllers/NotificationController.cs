using Microsoft.AspNetCore.Mvc;
using Senff_Notifications_Project.Application.DTOs;
using Senff_Notifications_Project.Application.Services.Interfaces;

namespace Senff_Notifications_Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notification;

        public NotificationController(INotificationService notification)
        {
            _notification = notification;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] NotificationDto notification)
        {
            var result = await _notification.Create(notification);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}/GetById")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var result = await _notification.GetById(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] NotificationDto notification)
        {
            var result = await _notification.Update(notification);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _notification.Delete(id);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
