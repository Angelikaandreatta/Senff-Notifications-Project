using AutoMapper;
using Senff_Notifications_Project.Application.DTOs;
using Senff_Notifications_Project.Application.Services.Interfaces;
using Senff_Notifications_Project.Domain.Models;
using Senff_Notifications_Project.Domain.Repositories;

namespace Senff_Notifications_Project.Application.Services
{
    public class SubscriptionPlanService : ISubscriptionPlanService
    {
        private readonly IRepository<SubscriptionPlanModel> _repository;
        private readonly IMapper _mapper;

        public SubscriptionPlanService(IRepository<SubscriptionPlanModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ResultService<SubscriptionPlanDto>> Create(SubscriptionPlanDto subscriptionPlanDto)
        {
            if (subscriptionPlanDto == null)
                return ResultService.Fail<SubscriptionPlanDto>("Object must be provided.");

            var subscriptionPlanModel = _mapper.Map<SubscriptionPlanDto, SubscriptionPlanModel>(subscriptionPlanDto);
            var createdSubscriptionPlan = await _repository.Create(subscriptionPlanModel);
            var createdSubscriptionPlanDto = _mapper.Map<SubscriptionPlanModel, SubscriptionPlanDto>(createdSubscriptionPlan);

            return ResultService.Ok(createdSubscriptionPlanDto);
        }

        public async Task<ResultService<SubscriptionPlanDto>> GetById(Guid id)
        {
            var subscriptionPlan = await _repository.GetById(id);

            if (subscriptionPlan == null)
                return ResultService.Fail<SubscriptionPlanDto>("Subscription plan not found.");

            var subscriptionPlanDto = _mapper.Map<SubscriptionPlanModel, SubscriptionPlanDto>(subscriptionPlan);
            return ResultService.Ok(subscriptionPlanDto);
        }

        public async Task<ResultService> Update(SubscriptionPlanDto subscriptionPlanDto)
        {
            if (subscriptionPlanDto == null)
                return ResultService.Fail("Object must be provided.");

            var subscriptionPlanModel = _mapper.Map<SubscriptionPlanDto, SubscriptionPlanModel>(subscriptionPlanDto);
            await _repository.Update(subscriptionPlanModel);

            return ResultService.Ok("Subscription plan updated successfully.");
        }

        public async Task<ResultService> Delete(Guid id)
        {
            var subscriptionPlan = await _repository.GetById(id);

            if (subscriptionPlan == null)
                return ResultService.Fail("Subscription plan not found.");

            await _repository.Delete(subscriptionPlan);
            return ResultService.Ok("Subscription plan deleted successfully.");
        }
    }
}
