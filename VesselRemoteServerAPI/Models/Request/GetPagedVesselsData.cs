using System.ComponentModel.DataAnnotations;

namespace VesselRemoteServerAPI.Models.Request
{
    public class GetPagedVesselsData
    {
        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 1;

        [Range(5, 100)]
        public int Take { get; set; } = 50;
    }
}
