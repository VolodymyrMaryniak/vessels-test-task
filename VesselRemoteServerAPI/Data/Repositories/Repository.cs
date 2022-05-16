using Microsoft.EntityFrameworkCore;

namespace VesselRemoteServerAPI.Data.Repositories
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        protected readonly TContext DbContext;

        public Repository(TContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task InsertAsync(TEntity entity)
        {
            DbSet.Add(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await DbSet.CountAsync();
        }

        protected DbSet<TEntity> DbSet => DbContext.Set<TEntity>();
    }
}
