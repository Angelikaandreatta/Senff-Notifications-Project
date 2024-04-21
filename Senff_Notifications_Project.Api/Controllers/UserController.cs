using Microsoft.AspNetCore.Mvc;
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
    }
}
