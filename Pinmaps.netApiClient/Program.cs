//Copyright (c) 2011-2013 Pinmaps.net (Sergio Tobon)
//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation 
//files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, 
//modify the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
//OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE 
//LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR 
//IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pinmaps.netApiClient.ApiResponse;
using Pinmaps.netApiClient.ApiRequest;

namespace Pinmaps.netApiClient
{
    class Program
    {
        ///<remarks>
        /// PINMAPS.NET API DOCUMENTATION
        /// http://api.pinmaps.net/Documentation/
        /// PINMAPS.NET API HOME
        /// http://api.pinmaps.net/
        /// PINMAPS.NET MAPPING SERVICE
        /// http://www.pinmaps.net/
        ///</remarks>
        
        private static string API_BASE_URL = "http://api.pinmaps.net/v1/";
        private static string DEVELOPER_API_LOGIN = "[ApiLogin Here]";
        private static string DEVELOPER_API_KEY = "[DeveloperApiKey Here]";
        private static string USER_NAME = "[UserName Here]";
        private static string USER_API_KEY = "[UserApyKey Here]";        
        
        static void Main(string[] args)
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
        ///<example>
        ///Request URL
        ///http://api.pinmaps.net/v1/credentials/validate?apiLogin={apiLogin}&developerKey={developerKey}&userName={userName}&userKey={userKey}
        /// </example>
        public static void ValidateApiCredentials()
        {
            try
            {
                System.Console.Clear();
                RestFactory<ApiCredentialsResponse> RestRepository = new RestFactory<ApiCredentialsResponse>();
                string formattedUrl = API_BASE_URL + "credentials/validate?apiLogin={0}&developerKey={1}&userName={2}&userKey={3}";
                formattedUrl = string.Format(formattedUrl, DEVELOPER_API_LOGIN, DEVELOPER_API_KEY, USER_NAME, USER_API_KEY);

                var item = RestRepository.GetEntity(formattedUrl);

                System.Console.Write("\nPlease enter any key...");
                System.Console.ReadKey();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("{0}", ex.Message);
                System.Console.WriteLine("");
            }
        }

        ///<summary>
        ///GET v1/credentials/developer/validate
        ///This method validate the Developer's API Credentials.
        ///</summary>
        ///<example>
        ///Request URL
        ///http://api.pinmaps.net/v1/credentials/developer/validate?apiLogin={apiLogin}&developerKey={developerKey}
        /// </example>
        public static void ValidateDeveloperApiCredentials()
        {
            try
            {
                System.Console.Clear();
                RestFactory<DeveloperApiCredentialsResponse> RestRepository = new RestFactory<DeveloperApiCredentialsResponse>();
                string formattedUrl = API_BASE_URL + "credentials/developer/validate?apiLogin={0}&developerKey={1}";
                formattedUrl = string.Format(formattedUrl, DEVELOPER_API_LOGIN, DEVELOPER_API_KEY);

                var item = RestRepository.GetEntity(formattedUrl);

                System.Console.Write("\nPlease enter any key...");
                System.Console.ReadKey();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("{0}", ex.ToString());
                System.Console.WriteLine("");
            }
        }

        ///<summary>
        ///GET v1/credentials/user/validate
        ///This method validate the User's API Credentials.
        ///</summary>
        ///<example>
        ///Request URL
        ///http://api.pinmaps.net/v1/credentials/user/validate?userName={userName}&userKey={userKey}
        /// </example>
        public static void ValidateUserApiCredentials()
        {
            try
            {
                System.Console.Clear();
                RestFactory<UserApiCredentialsResponse> RestRepository = new RestFactory<UserApiCredentialsResponse>();
                string formattedUrl = API_BASE_URL + "credentials/user/validate?userName={0}&userKey={1}";
                formattedUrl = string.Format(formattedUrl, USER_NAME, USER_API_KEY);

                var item = RestRepository.GetEntity(formattedUrl);

                System.Console.Write("\nPlease enter any key...");
                System.Console.ReadKey();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("{0}", ex.Message);
                System.Console.WriteLine("");
            }
        }
#endregion

#region Map API Methods
        ///<summary>
        ///GET v1/map
        ///This method returns a single map object by map ID. The result does not include the map points.
        ///</summary>
        /// <example>
        ///Request URL
        ///http://api.pinmaps.net/v1/map?id={id}&apiLogin={apiLogin}&developerKey={developerKey}&userName={userName}&userKey={userKey}
        /// </example>
        public static void GetMap()
        {
            try
            {
                System.Console.Clear();
                RestFactory<MapResponse> RestRepository = new RestFactory<MapResponse>();
                int MapID = 0;   // Enter your map ID here

                string formattedUrl = API_BASE_URL + "map?id={0}&apiLogin={1}&developerKey={2}&userName={3}&userKey={4}";
                formattedUrl = string.Format(formattedUrl, MapID, DEVELOPER_API_LOGIN, DEVELOPER_API_KEY, USER_NAME, USER_API_KEY);

                var item = RestRepository.GetEntity(formattedUrl);

                System.Console.Write("\n{0} - {1} - {2} - {3}", item.MapID, item.MapName, item.MapOwner, item.Icon.IconName + "\n");

                System.Console.Write("\nPlease enter any key...");
                System.Console.ReadKey();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("{0}", ex.Message);
                System.Console.WriteLine("");
            }
        }

        ///<summary>
        ///GET v1/maps
        ///This method returns a collection of maps objects by username. The list does not include the map points.
        ///</summary>
        ///<example>
        ///Request URL
        ///http://api.pinmaps.net/v1/maps?apiLogin={apiLogin}&developerKey={developerKey}&userName={userName}&userKey={userKey}
        /// </example>
        public static void GetMapsCollection()
        {
            try
            {
                System.Console.Clear();
                RestFactory<MapResponse> RestRepository = new RestFactory<MapResponse>();

                string formattedUrl = API_BASE_URL + "maps?apiLogin={0}&developerKey={1}&userName={2}&userKey={3}";
                formattedUrl = string.Format(formattedUrl, DEVELOPER_API_LOGIN, DEVELOPER_API_KEY, USER_NAME, USER_API_KEY);

                var Maps = RestRepository.GetCollection(formattedUrl);
                foreach (var item in Maps)
                {
                    System.Console.Write("\n{0} - {1} - {2} - {3}", item.MapID, item.MapName, item.MapOwner, item.Icon.IconName);
                }

                System.Console.Write("\n\nPlease enter any key...");
                System.Console.ReadKey();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("{0}", ex.Message);
                System.Console.WriteLine("");
            }
        }

        ///<summary>
        ///POST v1/map/create
        ///This method creates a single map on the selected MapZone and returns the created map object
        ///</summary>
        ///<example>
        ///Resource URL
        ///http://api.pinmaps.net/v1/map/create.json
        /// </example>
        public static void CreateMap()
        {
            try
            {
                System.Console.Clear();
                MapRequest Map = new MapRequest();
                Map.MapName = "Europe Airports";
                Map.MapZone = "EUROPE";       // WORLD,  USA,  EUROPE,  AUSTRALIA,  AFRICA,  NORTHAMERICA,  SOUTHAMERICA,  CANADA,  ASIA
                Map.MapType = "ROADMAP";      // ROADMAP,  SATELLITE,  HYBRID,  TERRAIN
                Map.UserName = USER_NAME;
                Map.DeveloperApiLogin = DEVELOPER_API_LOGIN;
                Map.DeveloperApiKey = DEVELOPER_API_KEY;
                Map.UserApiKey = USER_API_KEY;

                RestFactory<MapRequest> RestRepository = new RestFactory<MapRequest>();
                RestRepository.ApiRequest(Map, API_BASE_URL + "map/create", "POST");
                System.Console.WriteLine("");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("{0}", ex.Message);
                System.Console.WriteLine("");
            }
        }

        ///<summary>
        ///PUT v1/map/update
        ///This method updates a single map and returns the updated map object
        ///</summary>
        ///<example>
        ///Resource URL
        ///http://api.pinmaps.net/v1/map/update.json
        /// </example>
        public static void UpdateMap()
        {
            try
            {
                System.Console.Clear();
                MapRequest Map = new MapRequest();
                Map.MapID = 0;                    // Enter your map ID here
                Map.MapName = "USA Airports";
                Map.MapZone = "USA";             // WORLD,  USA,  EUROPE,  AUSTRALIA,  AFRICA,  NORTHAMERICA,  SOUTHAMERICA,  CANADA,  ASIA
                Map.MapType = "SATELLITE";       // ROADMAP  SATELLITE  HYBRID  TERRAIN
                Map.UserName = USER_NAME;
                Map.DeveloperApiLogin = DEVELOPER_API_LOGIN;
                Map.DeveloperApiKey = DEVELOPER_API_KEY;
                Map.UserApiKey = USER_API_KEY;

                RestFactory<MapRequest> RestRepository = new RestFactory<MapRequest>();
                RestRepository.ApiRequest(Map, API_BASE_URL + "map/update", "PUT");
                System.Console.WriteLine("");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("{0}", ex.Message);
                System.Console.WriteLine("");
            }
        }

        ///<summary>
        ///DELETE v1/map/destroy
        ///This method removes a single map object by map ID
        ///</summary>
        ///<example>
        ///Resource URL
        ///http://api.pinmaps.net/v1/map/destroy.json
        /// </example>
        public static void DeleteMap()
        {
            try
            {
                System.Console.Clear();
                MapRequest Point = new MapRequest();
                Point.MapID = 0;         // Enter your map ID here
                Point.UserName = USER_NAME;
                Point.DeveloperApiLogin = DEVELOPER_API_LOGIN;
                Point.DeveloperApiKey = DEVELOPER_API_KEY;
                Point.UserApiKey = USER_API_KEY;

                RestFactory<MapRequest> RestRepository = new RestFactory<MapRequest>();
                RestRepository.ApiRequest(Point, API_BASE_URL + "map/destroy", "DELETE");
                System.Console.WriteLine("");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("{0}", ex.Message);
                System.Console.WriteLine("");
            }
        }

        ///<summary>
        ///GET v1/maps/count
        ///This method returns the total maps count by username.
        ///</summary>
        ///<example>
        ///Request URL
        ///http://api.pinmaps.net/v1/maps/count?apiLogin={apiLogin}&developerKey={developerKey}&userName={userName}&userKey={userKey}
        /// </example>
        public static void GetMapsCount()
        {
            try
            {
                System.Console.Clear();
                RestFactory<MapCountResponse> RestRepository = new RestFactory<MapCountResponse>();

                string formattedUrl = API_BASE_URL + "maps/count?apiLogin={0}&developerKey={1}&userName={2}&userKey={3}";
                formattedUrl = string.Format(formattedUrl, DEVELOPER_API_LOGIN, DEVELOPER_API_KEY, USER_NAME, USER_API_KEY);

                var item = RestRepository.GetEntity(formattedUrl);
                System.Console.Write("\n{0} - {1}", item.UserName, item.Count + "\n");

                System.Console.Write("\nPlease enter any key...");
                System.Console.ReadKey();

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("{0}", ex.Message);
                System.Console.WriteLine("");
            }
        }
#endregion

#region Map Point API Methods
        ///<summary>
        ///GET v1/pin
        ///This method returns a single map point object by map point ID.
        ///</summary>
        ///<example>
        ///Request URL
        ///http://api.pinmaps.net/v1/pin?id={id}&apiLogin={apiLogin}&developerKey={developerKey}&userName={userName}&userKey={userKey}n
        /// </example>
        public static void GetMapPoint()
        {
            try
            {
                System.Console.Clear();
                RestFactory<MapPointResponse> RestRepository = new RestFactory<MapPointResponse>();
                int MapPointID = 0;   // Enter your map pint ID here

                string formattedUrl = API_BASE_URL + "pin?id={0}&apiLogin={1}&developerKey={2}&userName={3}&userKey={4}";
                formattedUrl = string.Format(formattedUrl, MapPointID, DEVELOPER_API_LOGIN, DEVELOPER_API_KEY, USER_NAME, USER_API_KEY);

                var item = RestRepository.GetEntity(formattedUrl);

                System.Console.Write("\n{0} - {1} - {2} - {3}", item.MapPointID, item.PointName, item.UserName, item.Icon.IconName + "\n");

                System.Console.Write("\nPlease enter any key...");
                System.Console.ReadKey();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("{0}", ex.Message);
                System.Console.WriteLine("");
            }
        }

        ///<summary>
        ///GET v1/pins
        ///This method returns a collection of map points objects by map ID.
        ///</summary>
        ///<example>
        ///Request URL
        ///http://api.pinmaps.net/v1/pins?id={id}&apiLogin={apiLogin}&developerKey={developerKey}&userName={userName}&userKey={userKey}
        /// </example>
        public static void GetMapPointsCollection()
        {
            try
            {
                System.Console.Clear();
                RestFactory<MapPointResponse> RestRepository = new RestFactory<MapPointResponse>();
                int MapID = 0;    // Enter your map ID here

                string formattedUrl = API_BASE_URL + "pins?id={0}&apiLogin={1}&developerKey={2}&userName={3}&userKey={4}";
                formattedUrl = string.Format(formattedUrl, MapID, DEVELOPER_API_LOGIN, DEVELOPER_API_KEY, USER_NAME, USER_API_KEY);

                var Pins = RestRepository.GetCollection(formattedUrl);
                foreach (var item in Pins)
                {
                    System.Console.Write("\n{0} - {1} - {2} - {3}", item.MapPointID, item.PointName, item.UserName, item.Icon.IconName);
                }

                System.Console.Write("\n\nPlease enter any key...");
                System.Console.ReadKey();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("{0}", ex.Message);
                System.Console.WriteLine("");
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
                System.Console.Clear();
                MapPointRequest Point = new MapPointRequest();
                Point.Address = "EWR";
                Point.PointName = "Newark Liberty International";
                Point.UserName = USER_NAME;
                Point.MapID = 0;                 // Enter your map ID here
                Point.MapType = "SATELLITE";     // ROADMAP,  SATELLITE,  HYBRID,  TERRAIN
                Point.PointInformation = "This is my favorite Airport";
                Point.DeveloperApiLogin = DEVELOPER_API_LOGIN;
                Point.DeveloperApiKey = DEVELOPER_API_KEY;
                Point.UserApiKey = USER_API_KEY;

                RestFactory<MapPointRequest> RestRepository = new RestFactory<MapPointRequest>();
                RestRepository.ApiRequest(Point, API_BASE_URL + "pin/create", "POST");
                System.Console.WriteLine("");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("{0}", ex.Message);
                System.Console.WriteLine("");
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
                System.Console.Clear();
                MapPointRequest Point = new MapPointRequest();
                Point.Address = "EWR";
                Point.PointName = "Newark Liberty International";
                Point.UserName = USER_NAME;
                Point.MapID = 0;              // Enter your map ID here
                Point.MapPointID = 0;         // Enter your map point ID here
                Point.MapType = "HYBRID";     // ROADMAP,  SATELLITE,  HYBRID,  TERRAIN
                Point.PointInformation = "";
                Point.DeveloperApiLogin = DEVELOPER_API_LOGIN;
                Point.DeveloperApiKey = DEVELOPER_API_KEY;
                Point.UserApiKey = USER_API_KEY;

                RestFactory<MapPointRequest> RestRepository = new RestFactory<MapPointRequest>();
                RestRepository.ApiRequest(Point, API_BASE_URL + "pin/update", "PUT");
                System.Console.WriteLine("");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("{0}", ex.Message);
                System.Console.WriteLine("");
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
                System.Console.Clear();
                MapPointRequest Point = new MapPointRequest();
                Point.MapPointID = 0;    // Enter your map point ID here
                Point.UserName = USER_NAME;
                Point.DeveloperApiLogin = DEVELOPER_API_LOGIN;
                Point.DeveloperApiKey = DEVELOPER_API_KEY;
                Point.UserApiKey = USER_API_KEY;

                RestFactory<MapPointRequest> RestRepository = new RestFactory<MapPointRequest>();
                RestRepository.ApiRequest(Point, API_BASE_URL + "pin/destroy", "DELETE");
                System.Console.WriteLine("");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("{0}", ex.Message);
                System.Console.WriteLine("");
            }
        }

        ///<summary>
        ///GET v1/pins/count
        ///This method returns the total map points count by map ID.
        ///</summary>
        ///<example>
        ///Request URL
        ///http://api.pinmaps.net/v1/pins/count?id={id}&apiLogin={apiLogin}&developerKey={developerKey}&userName={userName}&userKey={userKey}
        /// </example>
        public static void GetMapPointsCount()
        {
            try
            {
                System.Console.Clear();
                RestFactory<MapPointCountResponse> RestRepository = new RestFactory<MapPointCountResponse>();
                int MapID = 0;    // Enter your map ID here

                string formattedUrl = API_BASE_URL + "pins/count?id={0}&apiLogin={1}&developerKey={2}&userName={3}&userKey={4}";
                formattedUrl = string.Format(formattedUrl, MapID, DEVELOPER_API_LOGIN, DEVELOPER_API_KEY, USER_NAME, USER_API_KEY);

                var item = RestRepository.GetEntity(formattedUrl);
                System.Console.Write("\n{0} - {1}", item.MapID, item.Count + "\n");

                System.Console.Write("\nPlease enter any key...");
                System.Console.ReadKey();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("{0}", ex.Message);
                System.Console.WriteLine("");
            }
        }
#endregion
    }
}
