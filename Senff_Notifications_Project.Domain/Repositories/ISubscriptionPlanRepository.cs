using Senff_Notifications_Project.Domain.Models;

namespace Senff_Notifications_Project.Domain.Repositories
{
    public interface ISubscriptionPlanRepository
    {
        Task<SubscriptionPlanModel> Create(SubscriptionPlanModel subscriptionPlan);
        Task<SubscriptionPlanModel> GetById(Guid id);
        Task Update(SubscriptionPlanModel subscriptionPlan);
        Task Delete(Guid id);
    }
}
