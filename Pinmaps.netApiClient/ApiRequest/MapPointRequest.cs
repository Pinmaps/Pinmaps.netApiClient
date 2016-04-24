namespace Pinmaps.netApiClient.ApiRequest
{
    public class MapPointRequest
    {
        public int MapId { get; set; }                 // Required
        public int MapPointId { get; set; }            // Required for PUT not used for POST
        public string PointName { get; set; }          // Required
        public string UserName { get; set; }           // Required
        public string Address { get; set; }            // Required
        public string Latitude { get; set; }           // Optional
        public string Longitude { get; set; }          // Optional
        public string MapType { get; set; }            // Optional
        public string PointInformation { get; set; }   // Optional
        public string DeveloperApiKey { get; set; }    // Retuired
        public string DeveloperApiLogin { get; set; }  // Required
        public string UserApiKey { get; set; }         // Required
    }
}
