using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pinmaps.netApiClient
{

    public class RestFactory<TEntity> where TEntity : class
    {
        // Talk to the API using the .NET WebRequest (Methods: POST, PUT, DELETE)
        public void ApiRequest(TEntity entity, string apiUrl, string method)
        {
            try
            {
                string ApiUrl = apiUrl;
                // Seralize the object
                string JsonString = JsonConvert.SerializeObject(entity);
                // Create a request using a URL that can receive a post. 
                WebRequest Request = WebRequest.Create(ApiUrl);
                // Set the Method property of the request to POST.
                Request.Method = method;
                // Set the time out property of the request
                Request.Timeout = 15000;
                // Create POST data and convert it to a byte array.
                string PostData = JsonString;
                byte[] ByteArray = Encoding.UTF8.GetBytes(PostData);
                // Set the ContentType property of the WebRequest.
                Request.ContentType = "application/json";
                // Set the ContentLength property of the WebRequest.
                Request.ContentLength = ByteArray.Length;
                // Get the request stream.
                Stream DataStream = Request.GetRequestStream();
                // Write the data to the request stream.
                DataStream.Write(ByteArray, 0, ByteArray.Length);
                // Close the Stream object.
                DataStream.Close();
                // Get the response.
                WebResponse response = Request.GetResponse();

                // Display the status.
                System.Console.WriteLine("STATUS:   {0}", ((HttpWebResponse)response).StatusDescription);
                System.Console.WriteLine("API-URL:  {0}", ((HttpWebResponse)response).ResponseUri);
                System.Console.WriteLine("TYPE:     {0}", ((HttpWebResponse)response).ContentType);
                System.Console.WriteLine("LENGHT:   {0}", ((HttpWebResponse)response).ContentLength);
                System.Console.Write("\n");

                // Get the stream containing content returned by the server.
                DataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader Reader = new StreamReader(DataStream);
                // Read the content.
                string ServerResponse = Reader.ReadToEnd();
                // Display the content.
                System.Console.WriteLine("SERVER JSON RESPONSE:\n{0}", ServerResponse);
                // Clean up the streams.
                Reader.Close();
                DataStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Talk to the API using the .NET WebRequest (Method: GET - Entity)
        public TEntity GetEntity(string apiUrl)
        {
            try
            {
                // Create a request using a URL that can receive a post. 
                WebRequest Request = WebRequest.Create(apiUrl);
                Request.Method = "GET";

                // Get the response.
                WebResponse response = Request.GetResponse();

                // Display the status.
                System.Console.WriteLine("STATUS:   {0}", ((HttpWebResponse)response).StatusDescription);
                System.Console.WriteLine("API-URL:  {0}", ((HttpWebResponse)response).ResponseUri);
                System.Console.WriteLine("TYPE:     {0}", ((HttpWebResponse)response).ContentType);
                System.Console.WriteLine("LENGHT:   {0}", ((HttpWebResponse)response).ContentLength);
                System.Console.Write("\n");

                // Get the stream containing content returned by the server.
                Stream stream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader Reader = new StreamReader(stream);
                // Read the content.
                string ServerResponse = Reader.ReadToEnd();
                // Display the content.
                System.Console.WriteLine("SERVER JSON RESPONSE:\n{0}", ServerResponse);
                // Clean up the streams.
                stream.Close();
                Reader.Close();
                response.Close();

                JObject obj = JObject.Parse(ServerResponse);
                var resp = JsonConvert.DeserializeObject<TEntity>(obj.ToString());
                return resp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Talk to the API using the .NET WebRequest (Method: GET - Collection)
        public IEnumerable<TEntity> GetCollection(string apiUrl)
        {
            try
            {
                // Create a request using a URL that can receive a post. 
                WebRequest Request = WebRequest.Create(apiUrl);
                Request.Method = "GET";

                // Get the response.
                WebResponse response = Request.GetResponse();

                // Display the status.
                System.Console.WriteLine("STATUS:   {0}", ((HttpWebResponse)response).StatusDescription);
                System.Console.WriteLine("API-URL:  {0}", ((HttpWebResponse)response).ResponseUri);
                System.Console.WriteLine("TYPE:     {0}", ((HttpWebResponse)response).ContentType);
                System.Console.WriteLine("LENGHT:   {0}", ((HttpWebResponse)response).ContentLength);
                System.Console.Write("\n");

                // Get the stream containing content returned by the server.
                Stream stream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader Reader = new StreamReader(stream);
                // Read the content.
                string ServerResponse = Reader.ReadToEnd();
                // Display the content.
                System.Console.WriteLine("SERVER JSON RESPONSE:\n{0}", ServerResponse);
                // Clean up the streams.
                stream.Close();
                Reader.Close();
                response.Close();

                var jArray = JArray.Parse(ServerResponse);
                var resp = JsonConvert.DeserializeObject<List<TEntity>>(jArray.ToString());
                return resp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
