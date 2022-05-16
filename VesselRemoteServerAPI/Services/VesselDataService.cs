using VesselRemoteServerAPI.Data.Entities;
using VesselRemoteServerAPI.Data.Repositories;
using VesselRemoteServerAPI.Models.Request;
using VesselRemoteServerAPI.Models.Response;
using VesselRemoteServerAPI.Services.Interfaces;

namespace VesselRemoteServerAPI.Services
{
    public class VesselDataService : IVesselDataService
    {
        private readonly IVesselDataRepository _repository;

        public VesselDataService(IVesselDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<VesselData?> GetVesselDataAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity != null ? MapToModel(entity) : null;
        }

        public async Task<PagedVesselsData> GetPagedVesselsData(GetPagedVesselsData model)
        {
            var entities = await _repository.GetPagedVesselsDataAsync(model.Page, model.Take);
            var totalCount = await _repository.GetTotalCountAsync();

            return new PagedVesselsData(entities.Select(MapToModel).ToList(), totalCount);
        }

        public async Task<Guid> CreateVesselDataAsync(CreateVesselData model)
        {
            var entity = MapToEntity(model);

            await _repository.InsertAsync(entity);

            return entity.Id;
        }

        public async Task<EditVesselDataResult> EditVesselDataAsync(Guid id, EditVesselData model)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return EditVesselDataResult.NotFound;

            MapToEntity(entity, model);

            await _repository.SaveChangesAsync();
            return EditVesselDataResult.Success;
        }

        private static VesselData MapToModel(VesselDataEntity entity)
        {
            return new VesselData
            {
                Id = entity.Id,
                ImoNumber = entity.ImoNumber,
                VesselName = entity.VesselName,
                DateTime = entity.DateTime,
                Position = entity.Position
            };
        }

        private static VesselDataEntity MapToEntity(CreateVesselData model)
        {
            return new VesselDataEntity
            {
                ImoNumber = model.ImoNumber,
                VesselName = model.VesselName,
                DateTime = model.DateTime,
                Position = model.Position
            };
        }

        private static void MapToEntity(VesselDataEntity entity, EditVesselData model)
        {
            entity.ImoNumber = model.ImoNumber;
            entity.VesselName = model.VesselName;
            entity.DateTime = model.DateTime;
            entity.Position = model.Position;
        }
    }
}
