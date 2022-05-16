namespace VesselRemoteServerAPI.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task InsertAsync(TEntity entity);
        Task SaveChangesAsync();
        Task<int> GetTotalCountAsync();
    }
}
