using Microsoft.AspNetCore.Mvc;
using VesselRemoteServerAPI.Models.Request;
using VesselRemoteServerAPI.Models.Response;
using VesselRemoteServerAPI.Services.Interfaces;

namespace VesselRemoteServerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VesselDataController : ControllerBase
    {
        private readonly IVesselDataService _vesselDataService;

        public VesselDataController(IVesselDataService vesselDataService)
        {
            _vesselDataService = vesselDataService;
        }

        [HttpGet("{id}", Name = "GetVesselDataById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VesselData))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var vesselData = await _vesselDataService.GetVesselDataAsync(id);
            if (vesselData == null)
                return NotFound();

            return Ok(vesselData);
        }

        [HttpGet(Name = "GetPagedVesselsData")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedVesselsData))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetList([FromQuery] GetPagedVesselsData model)
        {
            var pagedVesselsData = await _vesselDataService.GetPagedVesselsData(model);
            return Ok(pagedVesselsData);
        }

        [HttpPost(Name = "CreateVesselData")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateVesselData model)
        {
            var id = await _vesselDataService.CreateVesselDataAsync(model);

            return CreatedAtAction(nameof(GetById), new {id}, model);
        }

        [HttpPut("{id}", Name = "EditVesselData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(Guid id, EditVesselData model)
        {
            var result = await _vesselDataService.EditVesselDataAsync(id, model);
            return result switch
            {
                EditVesselDataResult.Success => Ok(),
                EditVesselDataResult.NotFound => NotFound(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
