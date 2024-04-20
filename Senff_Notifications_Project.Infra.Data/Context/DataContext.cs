using Microsoft.EntityFrameworkCore;
using Senff_Notifications_Project.Domain.Models;

namespace Senff_Notifications_Project.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<SubscriptionPlanModel> SubscriptionPlan { get; set; }
        public DbSet<CompanyModel> Company { get; set; }
        public DbSet<UserModel> User { get; set; }
        public DbSet<NotificationModel> Notification { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SubscriptionPlanModel>();
            modelBuilder.Entity<CompanyModel>();
            modelBuilder.Entity<UserModel>();
            modelBuilder.Entity<NotificationModel>();
        }
    }
}
