using Senff_Notifications_Project.Domain.Models;

namespace Senff_Notifications_Project.Application.Services.Interfaces
{
    public interface ISubscriptionPlan
    {
        Task<ResultService<SubscriptionPlanModel>> Create(SubscriptionPlanModel subscriptionPlan);
        Task<ResultService<SubscriptionPlanModel>> GetByLogin(string email, string senha);
        Task<ResultService<SubscriptionPlanModel>> GetByIdAsync(string id);
        Task<ResultService> UpdateAsync(SubscriptionPlanModel subscriptionPlan);
        Task<ResultService> DeleteAsync(string id);
    }
}
