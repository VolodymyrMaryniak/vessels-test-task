namespace VesselRemoteServerAPI.Models.Response
{
    public class VesselData
    {
        public Guid Id { get; set; }
        public string ImoNumber { get; set; } = null!;
        public string VesselName { get; set; } = null!;
        public DateTimeOffset DateTime { get; set; }
        public string Position { get; set; } = null!;
    }
}
