using Senff_Notifications_Project.Domain.Repositories;
using Senff_Notifications_Project.Infra.Data.Context;

namespace Senff_Notifications_Project.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _dataContext;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            _dataContext.Add(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _dataContext.Set<TEntity>().FindAsync(id);
        }

        public async Task Delete(TEntity entity)
        {
            _dataContext.Set<TEntity>().Remove(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            _dataContext.Update(entity);
            await _dataContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dataContext.Set<TEntity>();
        }
    }
}
