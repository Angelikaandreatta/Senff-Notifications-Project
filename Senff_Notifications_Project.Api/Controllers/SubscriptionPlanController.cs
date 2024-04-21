using Microsoft.AspNetCore.Mvc;
using Senff_Notifications_Project.Application.Services.Interfaces;
using Senff_Notifications_Project.Domain.Models;

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
        public async Task<ActionResult> CreateAsync([FromBody] SubscriptionPlanModel subscriptionPlan)
        {
            var result = await _subscriptionPlan.Create(subscriptionPlan);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(string id)
        {
            var result = await _subscriptionPlan.GetByIdAsync(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] SubscriptionPlanModel subscriptionPlan)
        {
            var result = await _subscriptionPlan.UpdateAsync(subscriptionPlan);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            var result = await _subscriptionPlan.DeleteAsync(id);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

