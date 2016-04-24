using System;

namespace Pinmaps.netApiClient.ApiResponse
{
    public sealed class MapResponse
    {
        public MapResponse()
        {
            Icon = new IconResponse();
        }

        public int MapId { get; set; }
        public string MapName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ZoomLevel { get; set; }
        public string MapType { get; set; }
        public string MapOwner { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsShared { get; set; }
        public string MapLogo { get; set; }

        public IconResponse Icon { get; set; }
    }

    public class MapCountResponse
    {
        public string UserName { get; set; }
        public int Count { get; set; }
    }
}
