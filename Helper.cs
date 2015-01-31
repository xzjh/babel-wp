using System;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;


namespace Babel
{
    public delegate void AsyncPostCallback(HttpWebResponse response);
    //public class MyHttpResponse
    //{
    //    public string responseString;
    //    public WebHeaderCollection headers;
    //}
    public static class Helper
    {

        public static string GetResponseString(HttpWebResponse response)
        {
            Stream streamResponse = response.GetResponseStream();
            StreamReader reader = new StreamReader(streamResponse);
            string responseString = reader.ReadToEnd();
            streamResponse.Close();
            reader.Close();
            response.Close();
            return responseString;
        }

        public static void PostRequest(string requestUri, string parameters, AsyncPostCallback callback)
        {
            HttpWebRequest spAuthReq = HttpWebRequest.Create(requestUri) as HttpWebRequest;
            spAuthReq.ContentType = "application/x-www-form-urlencoded";
            spAuthReq.Method = "POST";
            spAuthReq.CookieContainer = new CookieContainer();
            spAuthReq.BeginGetRequestStream(new AsyncCallback((callbackResult) =>
            {
                HttpWebRequest myRequest = (HttpWebRequest)callbackResult.AsyncState;
                Stream postStream = myRequest.EndGetRequestStream(callbackResult);
                byte[] byteArray = Encoding.UTF8.GetBytes(parameters);
                postStream.Write(byteArray, 0, byteArray.Length);
                postStream.Close();
                myRequest.BeginGetResponse(new AsyncCallback((callbackResult2) =>
                {
                    try
                    {
                        HttpWebRequest request = (HttpWebRequest)callbackResult2.AsyncState;
                        HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(callbackResult2);
                        callback(response);
                    }
                    catch (Exception e)
                    {
                        callback(null);
                    }
                }), myRequest);
            }), spAuthReq);
        }

        public static void GetRequest(string requestUri, AsyncPostCallback callback)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUri);
            request.CookieContainer = new CookieContainer();
            request.BeginGetResponse(new AsyncCallback((callbackResult) =>
            {
                try
                {
                    HttpWebRequest request2 = (HttpWebRequest)callbackResult.AsyncState;
                    HttpWebResponse response = (HttpWebResponse)request2.EndGetResponse(callbackResult);
                    callback(response);
                }
                catch (Exception e)
                {
                    callback(null);
                }
            }), request);
        }

    }
}