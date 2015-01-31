using System;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;


namespace Babel
{
    public delegate void AsyncPostCallback(string responseString);
    public static class Helper
    {

        public static void PostRequest(string requestUri, string parameters, AsyncPostCallback callback)
        {
            HttpWebRequest spAuthReq = HttpWebRequest.Create(requestUri) as HttpWebRequest;
            spAuthReq.ContentType = "application/x-www-form-urlencoded";
            spAuthReq.Method = "POST";
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
                        string responseString = "";
                        Stream streamResponse = response.GetResponseStream();
                        StreamReader reader = new StreamReader(streamResponse);
                        responseString = reader.ReadToEnd();
                        streamResponse.Close();
                        reader.Close();
                        response.Close();
                        callback(responseString);
                    }
                    catch (Exception e)
                    {
                        callback(null);
                    }
                }), myRequest);
            }), spAuthReq);
        }

        private void GetRequest(string requestUri, AsyncPostCallback callback)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUri);
            request.ContentType = "application/x-www-form-urlencoded";
            request.BeginGetResponse(new AsyncCallback((callbackResult) =>
            {
                try
                {
                    HttpWebRequest request2 = (HttpWebRequest)callbackResult.AsyncState;
                    HttpWebResponse response = (HttpWebResponse)request2.EndGetResponse(callbackResult);
                    string responseString = "";
                    Stream streamResponse = response.GetResponseStream();
                    StreamReader reader = new StreamReader(streamResponse);
                    responseString = reader.ReadToEnd();
                    streamResponse.Close();
                    reader.Close();
                    response.Close();
                    callback(responseString);
                }
                catch (Exception e)
                {
                    callback(null);
                }
            }), request);
        }

    }
}