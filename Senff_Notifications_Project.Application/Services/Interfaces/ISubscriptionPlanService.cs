using Senff_Notifications_Project.Application.DTOs;

namespace Senff_Notifications_Project.Application.Services.Interfaces
{
    public interface ISubscriptionPlanService
    {
        Task<ResultService<SubscriptionPlanDto>> Create(SubscriptionPlanDto subscriptionPlan);
        Task<ResultService<SubscriptionPlanDto>> GetById(Guid id);
        Task<ResultService> Update(SubscriptionPlanDto subscriptionPlan);
        Task<ResultService> Delete(Guid id);
    }
}
