﻿using System.ComponentModel.DataAnnotations.Schema;

namespace VesselRemoteServerAPI.Data.Entities
{
    [Table("VesselData")]
    public class VesselDataEntity
    {
        public Guid Id { get; set; }
        public string ImoNumber { get; set; } = null!;
        public string VesselName { get; set; } = null!;
        public DateTimeOffset DateTime { get; set; }
        public string Position { get; set; } = null!;
    }
}
