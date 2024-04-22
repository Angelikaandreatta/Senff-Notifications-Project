using Senff_Notifications_Project.Application.DTOs;

namespace Senff_Notifications_Project.Application.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<ResultService<CompanyDto>> Create(CompanyDto company);
        Task<ResultService<CompanyDto>> GetById(Guid id);
        Task<ResultService> Update(CompanyDto subscriptionPlan);
        Task<ResultService> Delete(Guid id);
    }
}
