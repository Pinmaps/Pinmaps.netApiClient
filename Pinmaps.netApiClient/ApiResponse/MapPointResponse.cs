using System;

namespace Pinmaps.netApiClient.ApiResponse
{
    public sealed class MapPointResponse
    {
        public MapPointResponse()
        {
            Icon = new IconResponse();
        }

        public int MapPointId { get; set; }
        public int? MapId { get; set; }
        public string UserName { get; set; }
        public string PointName { get; set; }
        public string GeocodeAddress { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ZoomLevel { get; set; }
        public string MapType { get; set; }
        public string PointInfo { get; set; }
        public DateTime? DatePosted { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string LinkToBingMaps { get; set; }
        public string LinkToYahooMaps { get; set; }
        public string LinkToGoogleMaps { get; set; }

        public IconResponse Icon { get; set; }
    }

    public class MapPointCountResponse
    {
        public int MapId { get; set; }
        public int Count { get; set; }
    }
}
