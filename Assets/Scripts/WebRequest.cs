using System.Net;
using System.IO;
using UnityEngine;

public class Request : MonoBehaviour
{
    public static string GET(string url)
    {
        try
        {
            //Instantiate a new request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //Declaring a response variable
            string jsonResponse;

            //Setting request headers
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";

            //Making the request
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                //Reading the response into our response variable
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    jsonResponse = reader.ReadToEnd();
                }
            }

            //Returning our JSON string
            return jsonResponse;
        }
        catch(WebException ex)
        {
            //If something goes wrong during the webrequest an exception will be thrown and the following will be printed to console.
            Debug.Log("Something went wrong with your request. Please ensure the URL is correct and includes the zumo-api-version. Exception message: " + ex.Message);
            return string.Empty;
        }
    }

    public static string POST(string url)
    {
        try
        {
            //Instantiate a new request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //Declaring a response variable
            string jsonPostResponse;

            //Setting request headers
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            //Making the request
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                //Reading the response into our response variable
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    jsonPostResponse = reader.ReadToEnd();
                }
            }

            //Returning our JSON string
            return jsonPostResponse;
        }
        catch (WebException ex)
        {
            //If something goes wrong during the webrequest an exception will be thrown and the following will be printed to console.
            Debug.Log("Something went wrong with your request. Please ensure the URL is correct and includes the zumo-api-version. Exception message: " + ex.Message);
            return string.Empty;
        }
    }
}
