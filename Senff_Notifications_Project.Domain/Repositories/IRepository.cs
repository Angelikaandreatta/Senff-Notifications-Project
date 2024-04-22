namespace Senff_Notifications_Project.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> GetById(Guid id);
        Task Delete(TEntity entity);
        Task Update(TEntity entity);
        IQueryable<TEntity> GetAll();
    }
}
