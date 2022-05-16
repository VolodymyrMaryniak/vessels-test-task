using VesselRemoteServerAPI.Models.Request;
using VesselRemoteServerAPI.Models.Response;

namespace VesselRemoteServerAPI.Services.Interfaces
{
    public interface IVesselDataService
    {
        Task<VesselData?> GetVesselDataAsync(Guid id);
        Task<PagedVesselsData> GetPagedVesselsData(GetPagedVesselsData model);
        Task<Guid> CreateVesselDataAsync(CreateVesselData model);
        Task<EditVesselDataResult> EditVesselDataAsync(Guid id, EditVesselData model);
    }
}
