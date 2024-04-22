using Microsoft.AspNetCore.Mvc;
using Senff_Notifications_Project.Application.DTOs;
using Senff_Notifications_Project.Application.Services.Interfaces;

namespace Senff_Notifications_Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _company;

        public CompanyController(ICompanyService company)
        {
            _company = company;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CompanyDto company)
        {
            var result = await _company.Create(company);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}/GetById")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var result = await _company.GetById(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] CompanyDto company)
        {
            var result = await _company.Update(company);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _company.Delete(id);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
