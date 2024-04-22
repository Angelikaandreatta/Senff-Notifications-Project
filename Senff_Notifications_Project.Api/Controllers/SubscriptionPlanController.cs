using Microsoft.AspNetCore.Mvc;
using Senff_Notifications_Project.Application.DTOs;
using Senff_Notifications_Project.Application.Services.Interfaces;

namespace Senff_Notifications_Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionPlanController : ControllerBase
    {
        private readonly ISubscriptionPlanService _subscriptionPlan;

        public SubscriptionPlanController(ISubscriptionPlanService subscriptionPlan)
        {
            _subscriptionPlan = subscriptionPlan;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] SubscriptionPlanDto subscriptionPlan)
        {
            var result = await _subscriptionPlan.Create(subscriptionPlan);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}/GetById")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var result = await _subscriptionPlan.GetById(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] SubscriptionPlanDto subscriptionPlan)
        {
            var result = await _subscriptionPlan.Update(subscriptionPlan);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _subscriptionPlan.Delete(id);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
