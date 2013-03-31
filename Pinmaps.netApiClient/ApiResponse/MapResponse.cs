using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinmaps.netApiClient.ApiResponse
{
    public class MapResponse
    {
        public MapResponse()
        {
            Icon = new IconResponse();
        }

        public int MapID { get; set; }
        public string MapName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ZoomLevel { get; set; }
        public string MapType { get; set; }
        public string MapOwner { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<bool> IsShared { get; set; }
        public string MapLogo { get; set; }

        public virtual IconResponse Icon { get; set; }
    }

    public class MapCountResponse
    {
        public string UserName { get; set; }
        public int Count { get; set; }
    }
}
