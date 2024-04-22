using Microsoft.AspNetCore.Mvc;
using Senff_Notifications_Project.Application.DTOs;
using Senff_Notifications_Project.Application.Services.Interfaces;

namespace Senff_Notifications_Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _user;

        public UserController(IUserService user)
        {
            _user = user;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserDto user)
        {
            var result = await _user.Create(user);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}/GetById")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var result = await _user.GetById(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UserDto user)
        {
            var result = await _user.Update(user);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _user.Delete(id);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
