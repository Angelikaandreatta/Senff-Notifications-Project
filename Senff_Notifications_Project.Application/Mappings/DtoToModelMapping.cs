using AutoMapper;
using Senff_Notifications_Project.Application.DTOs;
using Senff_Notifications_Project.Domain.Models;

namespace Senff_Notifications_Project.Application.Mappings
{
    public class DtoToModelMapping : Profile
    {
        public DtoToModelMapping()
        {
            CreateMap<SubscriptionPlanDto, SubscriptionPlanModel>();
        }
    }
}
