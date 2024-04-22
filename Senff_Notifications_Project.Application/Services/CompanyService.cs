using AutoMapper;
using Senff_Notifications_Project.Application.DTOs;
using Senff_Notifications_Project.Application.Services.Interfaces;
using Senff_Notifications_Project.Domain.Models;
using Senff_Notifications_Project.Domain.Repositories;

namespace Senff_Notifications_Project.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<CompanyModel> _repository;
        private readonly IMapper _mapper;

        public CompanyService(IRepository<CompanyModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ResultService<CompanyDto>> Create(CompanyDto companyDto)
        {
            if (companyDto == null)
                return ResultService.Fail<CompanyDto>("Object must be provided.");

            var companyModel = _mapper.Map<CompanyDto, CompanyModel>(companyDto);
            var createdCompany = await _repository.Create(companyModel);
            var createdCompanyDto = _mapper.Map<CompanyModel, CompanyDto>(createdCompany);

            return ResultService.Ok(createdCompanyDto);
        }

        public async Task<ResultService<CompanyDto>> GetById(Guid id)
        {
            var company = await _repository.GetById(id);

            if (company == null)
                return ResultService.Fail<CompanyDto>("Company not found.");

            var companyDto = _mapper.Map<CompanyModel, CompanyDto>(company);
            return ResultService.Ok(companyDto);
        }

        public async Task<ResultService> Update(CompanyDto companyDto)
        {
            if (companyDto == null)
                return ResultService.Fail("Object must be provided.");

            var companyModel = _mapper.Map<CompanyDto, CompanyModel>(companyDto);
            await _repository.Update(companyModel);

            return ResultService.Ok("Company updated successfully.");
        }

        public async Task<ResultService> Delete(Guid id)
        {
            var company = await _repository.GetById(id);

            if (company == null)
                return ResultService.Fail("Company not found.");

            await _repository.Delete(company);
            return ResultService.Ok("Company deleted successfully.");
        }
    }
}
