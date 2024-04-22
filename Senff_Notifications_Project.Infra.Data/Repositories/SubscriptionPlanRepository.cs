using Microsoft.EntityFrameworkCore;
using Senff_Notifications_Project.Domain.Models;
using Senff_Notifications_Project.Domain.Repositories;
using Senff_Notifications_Project.Infra.Data.Context;

namespace Senff_Notifications_Project.Infra.Data.Repositories
{
    public class SubscriptionPlanRepository : ISubscriptionPlanRepository
    {
        private readonly DataContext _dataContext;

        public SubscriptionPlanRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<SubscriptionPlanModel> Create(SubscriptionPlanModel subscriptionPlan)
        {
            _dataContext.Add(subscriptionPlan);
            await _dataContext.SaveChangesAsync();
            return subscriptionPlan;
        }

        public async Task<SubscriptionPlanModel> GetById(Guid id)
        {
            return await _dataContext.SubscriptionPlan.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Delete(Guid id)
        {
            var subscriptionPlan = await _dataContext.SubscriptionPlan.FindAsync(id);
            if (subscriptionPlan != null)
            {
                _dataContext.SubscriptionPlan.Remove(subscriptionPlan);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task Update(SubscriptionPlanModel subscriptionPlan)
        {
            _dataContext.Update(subscriptionPlan);
            await _dataContext.SaveChangesAsync();
        }
    }
}
