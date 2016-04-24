//Copyright (c) 2011-2016 Pinmaps.net (Sergio Tobon)
//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation 
//files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, 
//modify the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
//OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE 
//LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR 
//IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.


using System;
using Pinmaps.netApiClient.ApiResponse;
using Pinmaps.netApiClient.ApiRequest;

namespace Pinmaps.netApiClient
{
    public class Program
    {
        ///<remarks>
        /// PINMAPS.NET API DOCUMENTATION
        /// http://api.pinmaps.net/Documentation/
        /// PINMAPS.NET MAPPING SERVICE
        /// https://www.pinmaps.net/
        ///</remarks>
        
        private const string ApiBaseUrl = "http://api.pinmaps.net/v1/";
        private const string DeveloperApiLogin = "[ApiLogin Here]";
        private const string DeveloperApiKey = "[DeveloperApiKey Here]";
        private const string UserName = "[UserName Here]";
        private const string UserApiKey = "[UserApyKey Here]";

        static void Main()
        {
            ValidateApiCredentials();
            ValidateDeveloperApiCredentials();
            ValidateUserApiCredentials();

            //GetMap();
            //GetMapsCollection();
            //CreateMap();
            //UpdateMap();
            //DeleteMap();
            //GetMapsCount();

            //GetMapPoint();
            //GetMapPointsCollection();
            //AddMapPointToMap();
            //UpdateMapPoint();
            //DeleteMapPoint();
            //GetMapPointsCount();
        }

#region Validation API Methods
        ///<summary>
        ///GET v1/credentials/validate
        ///This method validates both the Developer's and the User's API Credentials at the same time.
        ///</summary>
        public static void ValidateApiCredentials()
        {
            try
            {
                Console.Clear();
                RestFactory<ApiCredentialsResponse> restRepository = new RestFactory<ApiCredentialsResponse>();
                string formattedUrl = ApiBaseUrl + "credentials/validate?apiLogin={0}&developerKey={1}&userName={2}&userKey={3}";
                formattedUrl = string.Format(formattedUrl, DeveloperApiLogin, DeveloperApiKey, UserName, UserApiKey);

                var item = restRepository.GetEntity(formattedUrl);
                Console.Write("\n{0}", item.Valid);

                Console.Write("\nPlease enter any key...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
                Console.WriteLine("");
            }
        }

        ///<summary>
        ///GET v1/credentials/developer/validate
        ///This method validate the Developer's API Credentials.
        ///</summary>
        public static void ValidateDeveloperApiCredentials()
        {
            try
            {
                Console.Clear();
                RestFactory<DeveloperApiCredentialsResponse> restRepository = new RestFactory<DeveloperApiCredentialsResponse>();
                string formattedUrl = ApiBaseUrl + "credentials/developer/validate?apiLogin={0}&developerKey={1}";
                formattedUrl = string.Format(formattedUrl, DeveloperApiLogin, DeveloperApiKey);

                var item = restRepository.GetEntity(formattedUrl);
                Console.Write("\nAPI Key is active: {0}", item.IsActive);

                Console.Write("\nPlease enter any key...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
                Console.WriteLine("");
            }
        }

        ///<summary>
        ///GET v1/credentials/user/validate
        ///This method validate the User's API Credentials.
        ///</summary>
        public static void ValidateUserApiCredentials()
        {
            try
            {
                Console.Clear();
                RestFactory<UserApiCredentialsResponse> restRepository = new RestFactory<UserApiCredentialsResponse>();
                string formattedUrl = ApiBaseUrl + "credentials/user/validate?userName={0}&userKey={1}";
                formattedUrl = string.Format(formattedUrl, UserName, UserApiKey);

                var item = restRepository.GetEntity(formattedUrl);
                Console.Write("\nUsername: {0}, API Key: {1}, Date Created: {2}", item.UserName, item.UserApiKey, item.DateCreated);

                Console.Write("\nPlease enter any key...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
                Console.WriteLine("");
            }
        }
#endregion

#region Map API Methods
        ///<summary>
        ///GET v1/map
        ///This method returns a single map object by map ID. The result does not include the map points.
        ///</summary>
        public static void GetMap()
        {
            try
            {
                Console.Clear();
                RestFactory<MapResponse> restRepository = new RestFactory<MapResponse>();
                int mapId = 0;   // Enter your map ID here

                string formattedUrl = ApiBaseUrl + "map?id={0}&apiLogin={1}&developerKey={2}&userName={3}&userKey={4}";
                formattedUrl = string.Format(formattedUrl, mapId, DeveloperApiLogin, DeveloperApiKey, UserName, UserApiKey);

                var item = restRepository.GetEntity(formattedUrl);

                Console.Write("\n{0} - {1} - {2} - {3}", item.MapId, item.MapName, item.MapOwner, item.Icon.IconName + "\n");

                Console.Write("\nPlease enter any key...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
                Console.WriteLine("");
            }
        }

        ///<summary>
        ///GET v1/maps
        ///This method returns a collection of maps objects by username. The list does not include the map points.
        ///</summary>
        public static void GetMapsCollection()
        {
            try
            {
                Console.Clear();
                RestFactory<MapResponse> restRepository = new RestFactory<MapResponse>();

                string formattedUrl = ApiBaseUrl + "maps?apiLogin={0}&developerKey={1}&userName={2}&userKey={3}";
                formattedUrl = string.Format(formattedUrl, DeveloperApiLogin, DeveloperApiKey, UserName, UserApiKey);

                var maps = restRepository.GetCollection(formattedUrl);
                foreach (var item in maps)
                {
                    Console.Write("\n{0} - {1} - {2} - {3}", item.MapId, item.MapName, item.MapOwner, item.Icon.IconName);
                }

                Console.Write("\n\nPlease enter any key...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
                Console.WriteLine("");
            }
        }

        ///<summary>
        ///POST v1/map/create
        ///This method creates a single map on the selected MapZone and returns the created map object
        ///</summary>
        public static void CreateMap()
        {
            try
            {
                Console.Clear();
                MapRequest map = new MapRequest
                {
                    MapName = "Europe Airports",
                    MapType = "ROADMAP",       // ROADMAP,  SATELLITE,  HYBRID,  TERRAIN
                    UserName = UserName,
                    DeveloperApiLogin = DeveloperApiLogin,
                    DeveloperApiKey = DeveloperApiKey,
                    UserApiKey = UserApiKey
                };
                
                RestFactory<MapRequest> restRepository = new RestFactory<MapRequest>();
                restRepository.ApiRequest(map, ApiBaseUrl + "map/create", "POST");
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
                Console.WriteLine("");
            }
        }

        ///<summary>
        ///PUT v1/map/update
        ///This method updates a single map and returns the updated map object
        ///</summary>
        public static void UpdateMap()
        {
            try
            {
                Console.Clear();
                MapRequest map = new MapRequest
                {
                    MapId = 0,               // Enter your map ID here
                    MapName = "USA Airports",
                    MapType = "SATELLITE",   // ROADMAP  SATELLITE  HYBRID  TERRAIN
                    UserName = UserName,
                    DeveloperApiLogin = DeveloperApiLogin,
                    DeveloperApiKey = DeveloperApiKey,
                    UserApiKey = UserApiKey
                };

                RestFactory<MapRequest> restRepository = new RestFactory<MapRequest>();
                restRepository.ApiRequest(map, ApiBaseUrl + "map/update", "PUT");
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
                Console.WriteLine("");
            }
        }

        ///<summary>
        ///DELETE v1/map/destroy
        ///This method removes a single map object by map ID
        ///</summary>
        public static void DeleteMap()
        {
            try
            {
                Console.Clear();
                MapRequest point = new MapRequest
                {
                    MapId = 0,          // Enter your map ID here
                    UserName = UserName,
                    DeveloperApiLogin = DeveloperApiLogin,
                    DeveloperApiKey = DeveloperApiKey,
                    UserApiKey = UserApiKey
                };

                RestFactory<MapRequest> restRepository = new RestFactory<MapRequest>();
                restRepository.ApiRequest(point, ApiBaseUrl + "map/destroy", "DELETE");
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
                Console.WriteLine("");
            }
        }

        ///<summary>
        ///GET v1/maps/count
        ///This method returns the total maps count by username.
        ///</summary>
        public static void GetMapsCount()
        {
            try
            {
                Console.Clear();
                RestFactory<MapCountResponse> restRepository = new RestFactory<MapCountResponse>();

                string formattedUrl = ApiBaseUrl + "maps/count?apiLogin={0}&developerKey={1}&userName={2}&userKey={3}";
                formattedUrl = string.Format(formattedUrl, DeveloperApiLogin, DeveloperApiKey, UserName, UserApiKey);

                var item = restRepository.GetEntity(formattedUrl);
                Console.Write("\n{0} - {1}", item.UserName, item.Count + "\n");

                Console.Write("\nPlease enter any key...");
                Console.ReadKey();

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
                Console.WriteLine("");
            }
        }
#endregion

#region Map Point API Methods
        ///<summary>
        ///GET v1/pin
        ///This method returns a single map point object by map point ID.
        ///</summary>
        public static void GetMapPoint()
        {
            try
            {
                Console.Clear();
                RestFactory<MapPointResponse> restRepository = new RestFactory<MapPointResponse>();
                int mapPointId = 0;   // Enter your map pint ID here

                string formattedUrl = ApiBaseUrl + "pin?id={0}&apiLogin={1}&developerKey={2}&userName={3}&userKey={4}";
                formattedUrl = string.Format(formattedUrl, mapPointId, DeveloperApiLogin, DeveloperApiKey, UserName, UserApiKey);

                var item = restRepository.GetEntity(formattedUrl);

                Console.Write("\n{0} - {1} - {2} - {3}", item.MapPointId, item.PointName, item.UserName, item.Icon.IconName + "\n");

                Console.Write("\nPlease enter any key...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
                Console.WriteLine("");
            }
        }

        ///<summary>
        ///GET v1/pins
        ///This method returns a collection of map points objects by map ID.
        ///</summary>
        public static void GetMapPointsCollection()
        {
            try
            {
                Console.Clear();
                RestFactory<MapPointResponse> restRepository = new RestFactory<MapPointResponse>();
                int mapId = 0;    // Enter your map ID here

                string formattedUrl = ApiBaseUrl + "pins?id={0}&apiLogin={1}&developerKey={2}&userName={3}&userKey={4}";
                formattedUrl = string.Format(formattedUrl, mapId, DeveloperApiLogin, DeveloperApiKey, UserName, UserApiKey);

                var pins = restRepository.GetCollection(formattedUrl);
                foreach (var item in pins)
                {
                    Console.Write("\n{0} - {1} - {2} - {3}", item.MapPointId, item.PointName, item.UserName, item.Icon.IconName);
                }

                Console.Write("\n\nPlease enter any key...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
                Console.WriteLine("");
            }

        }

        ///<summary>
        ///POST v1/pin/create
        ///This method creates a single map point on a map and returns the created map point object
        ///</summary>
        ///<remarks>
        ///Post format: json
        ///</remarks>
        ///<example>
        ///Resource URL
        ///http://api.pinmaps.net/v1/pin/create.json
        /// </example>
        public static void AddMapPointToMap()
        {
            try
            {
                Console.Clear();
                MapPointRequest point = new MapPointRequest
                {
                    Address = "EWR",
                    PointName = "Newark Liberty International",
                    UserName = UserName,
                    MapId = 0,                 // Enter your map ID here
                    MapType = "SATELLITE",     // ROADMAP,  SATELLITE,  HYBRID,  TERRAIN
                    PointInformation = "This is my favorite Airport",
                    DeveloperApiLogin = DeveloperApiLogin,
                    DeveloperApiKey = DeveloperApiKey,
                    UserApiKey = UserApiKey
                };

                RestFactory<MapPointRequest> restRepository = new RestFactory<MapPointRequest>();
                restRepository.ApiRequest(point, ApiBaseUrl + "pin/create", "POST");
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
                Console.WriteLine("");
            }
        }

        ///<summary>
        ///PUT v1/pin/update
        ///This method updates a single map point and returns the updated map point object
        ///</summary>
        ///<remarks>
        ///Put format: json
        ///</remarks>
        ///<example>
        ///Resource URL
        ///http://api.pinmaps.net/v1/pin/update.json
        /// </example>
        public static void UpdateMapPoint()
        {
            try
            {
                Console.Clear();
                MapPointRequest point = new MapPointRequest
                {
                    Address = "EWR",
                    PointName = "Newark Liberty International",
                    UserName = UserName,
                    MapId = 0,           // Enter your map ID here
                    MapPointId = 0,      // Enter your map point ID here
                    MapType = "HYBRID",  // ROADMAP,  SATELLITE,  HYBRID,  TERRAIN
                    PointInformation = "",
                    DeveloperApiLogin = DeveloperApiLogin,
                    DeveloperApiKey = DeveloperApiKey,
                    UserApiKey = UserApiKey
                };
                
                RestFactory<MapPointRequest> restRepository = new RestFactory<MapPointRequest>();
                restRepository.ApiRequest(point, ApiBaseUrl + "pin/update", "PUT");
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
                Console.WriteLine("");
            }
        }

        ///<summary>
        ///DELETE v1/pin/destroy
        ///This method deletes a single map point object by map point ID
        ///</summary>
        ///<remarks>
        ///Delete format: json
        ///</remarks>
        ///<example>
        ///Resource URL
        ///http://api.pinmaps.net/v1/pin/destroy.json
        /// </example>
        public static void DeleteMapPoint()
        {
            try
            {
                Console.Clear();
                MapPointRequest point = new MapPointRequest
                {
                    MapPointId = 0,   // Enter your map point ID here
                    UserName = UserName,
                    DeveloperApiLogin = DeveloperApiLogin,
                    DeveloperApiKey = DeveloperApiKey,
                    UserApiKey = UserApiKey
                };

                RestFactory<MapPointRequest> restRepository = new RestFactory<MapPointRequest>();
                restRepository.ApiRequest(point, ApiBaseUrl + "pin/destroy", "DELETE");
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
                Console.WriteLine("");
            }
        }

        ///<summary>
        ///GET v1/pins/count
        ///This method returns the total map points count by map ID.
        ///</summary>
        public static void GetMapPointsCount()
        {
            try
            {
                Console.Clear();
                RestFactory<MapPointCountResponse> restRepository = new RestFactory<MapPointCountResponse>();
                int mapId = 0;    // Enter your map ID here

                string formattedUrl = ApiBaseUrl + "pins/count?id={0}&apiLogin={1}&developerKey={2}&userName={3}&userKey={4}";
                formattedUrl = string.Format(formattedUrl, mapId, DeveloperApiLogin, DeveloperApiKey, UserName, UserApiKey);

                var item = restRepository.GetEntity(formattedUrl);
                Console.Write("\n{0} - {1}", item.MapId, item.Count + "\n");

                Console.Write("\nPlease enter any key...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
                Console.WriteLine("");
            }
        }
#endregion
    }
}
