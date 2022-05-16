using Microsoft.EntityFrameworkCore;
using VesselRemoteServerAPI.Data.Entities;

namespace VesselRemoteServerAPI.Data
{
    public class VesselDbContext : DbContext
    {
        public VesselDbContext(DbContextOptions<VesselDbContext> options) : base(options)
        {
        }

        public DbSet<VesselDataEntity> VesselData { get; set; } = null!;
    }
}
