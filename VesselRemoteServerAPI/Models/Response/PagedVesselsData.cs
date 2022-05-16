namespace VesselRemoteServerAPI.Models.Response
{
    public class PagedVesselsData
    {
        public PagedVesselsData(List<VesselData> vesselsData, int totalCount)
        {
            VesselsData = vesselsData;
            TotalCount = totalCount;
        }

        public List<VesselData> VesselsData { get; set; }
        public int TotalCount { get; set; }
    }
}
