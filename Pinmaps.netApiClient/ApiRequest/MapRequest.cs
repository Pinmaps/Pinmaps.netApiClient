using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinmaps.netApiClient.ApiRequest
{
    public class MapRequest
    {
        public int MapID { get; set; }                // Output for POST and Required for PUT
        public string MapName { get; set; }           // Required
        public string MapZone { get; set; }           // Optional
        public string MapType { get; set; }           // Optional
        public string UserName { get; set; }          // Required
        public string DeveloperApiKey { get; set; }   // Required
        public string DeveloperApiLogin { get; set; } // Required
        public string UserApiKey { get; set; }        // Required
    }
}
