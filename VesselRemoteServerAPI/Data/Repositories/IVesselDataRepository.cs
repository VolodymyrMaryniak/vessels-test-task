using VesselRemoteServerAPI.Data.Entities;

namespace VesselRemoteServerAPI.Data.Repositories
{
    public interface IVesselDataRepository : IRepository<VesselDataEntity>
    {
        Task<VesselDataEntity?> GetByIdAsync(Guid id);
        Task<List<VesselDataEntity>> GetPagedVesselsDataAsync(int page, int take);
    }
}
