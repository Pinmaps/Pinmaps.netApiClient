using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinmaps.netApiClient.ApiResponse
{
    public class MapPointResponse
    {
        public MapPointResponse()
        {
            Icon = new IconResponse();
        }

        public int MapPointID { get; set; }
        public Nullable<int> MapID { get; set; }
        public string UserName { get; set; }
        public string PointName { get; set; }
        public string GeocodeAddress { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ZoomLevel { get; set; }
        public string MapType { get; set; }
        public string PointInfo { get; set; }
        public Nullable<System.DateTime> DatePosted { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string LinkToBingMaps { get; set; }
        public string LinkToYahooMaps { get; set; }
        public string LinkToGoogleMaps { get; set; }

        public virtual IconResponse Icon { get; set; }
    }

    public class MapPointCountResponse
    {
        public int MapID { get; set; }
        public int Count { get; set; }
    }
}
