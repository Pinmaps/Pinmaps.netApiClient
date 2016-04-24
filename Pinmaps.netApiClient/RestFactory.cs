using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Pinmaps.netApiClient
{

    public class RestFactory<TEntity> where TEntity : class
    {
        // Talk to the API using the .NET WebRequest (Methods: POST, PUT, DELETE)
        public void ApiRequest(TEntity entity, string apiUrl, string method)
        {
            string url = apiUrl;
            // Seralize the object
            string jsonString = JsonConvert.SerializeObject(entity);
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create(url);
            // Set the Method property of the request to POST.
            request.Method = method;
            // Set the time out property of the request
            request.Timeout = 15000;
            // Create POST data and convert it to a byte array.
            string postData = jsonString;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/json";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();

            // Display the status.
            Console.WriteLine("STATUS:   {0}", ((HttpWebResponse)response).StatusDescription);
            Console.WriteLine("API-URL:  {0}", ((HttpWebResponse)response).ResponseUri);
            Console.WriteLine("TYPE:     {0}", ((HttpWebResponse)response).ContentType);
            Console.WriteLine("LENGHT:   {0}", ((HttpWebResponse)response).ContentLength);
            Console.Write("\n");

            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            if (dataStream != null)
            {
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string serverResponse = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine("SERVER JSON RESPONSE:\n{0}", serverResponse);
                // Clean up the streams.
                reader.Close();
                dataStream.Close();
            }
            response.Close();
        }

        // Talk to the API using the .NET WebRequest (Method: GET - Entity)
        public TEntity GetEntity(string apiUrl)
        {
            // Create a request using a URL that can receive a post. 
            var request = WebRequest.Create(apiUrl);
            request.Method = "GET";

            // Get the response.
            WebResponse response = request.GetResponse();
            // Return value
            TEntity resp = null;

            // Display the status.
            Console.WriteLine("STATUS:   {0}", ((HttpWebResponse)response).StatusDescription);
            Console.WriteLine("API-URL:  {0}", ((HttpWebResponse)response).ResponseUri);
            Console.WriteLine("TYPE:     {0}", ((HttpWebResponse)response).ContentType);
            Console.WriteLine("LENGHT:   {0}", ((HttpWebResponse)response).ContentLength);
            Console.Write("\n");

            // Get the stream containing content returned by the server.
            Stream stream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            if (stream != null)
            {
                StreamReader reader = new StreamReader(stream);
                // Read the content.
                string serverResponse = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine("SERVER JSON RESPONSE:\n{0}", serverResponse);
                // Clean up the streams.
                stream.Close();
                reader.Close();
                response.Close();

                JObject obj = JObject.Parse(serverResponse);
                resp = JsonConvert.DeserializeObject<TEntity>(obj.ToString());
            }

            return resp;
        }

        // Talk to the API using the .NET WebRequest (Method: GET - Collection)
        public IEnumerable<TEntity> GetCollection(string apiUrl)
        {
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create(apiUrl);
            request.Method = "GET";

            // Get the response.
            WebResponse response = request.GetResponse();
            // Return value
            List<TEntity> resp = null;

            // Display the status.
            Console.WriteLine("STATUS:   {0}", ((HttpWebResponse)response).StatusDescription);
            Console.WriteLine("API-URL:  {0}", ((HttpWebResponse)response).ResponseUri);
            Console.WriteLine("TYPE:     {0}", ((HttpWebResponse)response).ContentType);
            Console.WriteLine("LENGHT:   {0}", ((HttpWebResponse)response).ContentLength);
            Console.Write("\n");

            // Get the stream containing content returned by the server.
            Stream stream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            if (stream != null)
            {
                StreamReader reader = new StreamReader(stream);
                // Read the content.
                string serverResponse = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine("SERVER JSON RESPONSE:\n{0}", serverResponse);
                // Clean up the streams.
                stream.Close();
                reader.Close();
                response.Close();

                var jArray = JArray.Parse(serverResponse);
                resp = JsonConvert.DeserializeObject<List<TEntity>>(jArray.ToString());

            }

            return resp;
        }
    }
}
