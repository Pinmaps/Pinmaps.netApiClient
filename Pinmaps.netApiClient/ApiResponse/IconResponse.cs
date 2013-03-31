using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinmaps.netApiClient.ApiResponse
{
    public class IconResponse
    {
        public IconResponse() { }

        public int IconID { get; set; }
        public string IconName { get; set; }
        public string IconShadow { get; set; }
        public string IconWidth { get; set; }
        public string IconHeight { get; set; }
        public string ShadowWidth { get; set; }
        public string ShadowHeight { get; set; }
    }
}
