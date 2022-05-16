using Microsoft.EntityFrameworkCore;
using VesselRemoteServerAPI.Data.Entities;

namespace VesselRemoteServerAPI.Data.Repositories
{
    public class VesselDataRepository : Repository<VesselDataEntity, VesselDbContext>, IVesselDataRepository
    {
        public VesselDataRepository(VesselDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<VesselDataEntity?> GetByIdAsync(Guid id)
        {
            return await DbSet.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<VesselDataEntity>> GetPagedVesselsDataAsync(int page, int take)
        {
            return await DbSet.OrderByDescending(d => d.DateTime)
                .ThenBy(d => d.Id)
                .Skip(take * (page - 1))
                .Take(take)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
