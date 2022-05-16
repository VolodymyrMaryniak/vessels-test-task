using System.ComponentModel.DataAnnotations;

namespace VesselRemoteServerAPI.Models.Request
{
    public class EditVesselData
    {
        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string ImoNumber { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string VesselName { get; set; } = null!;

        public DateTimeOffset DateTime { get; set; }

        [Required]
        public string Position { get; set; } = null!;
    }
}
