﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Factory_inspection_api;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Serialization;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Factory_inspection_api.Factory_inspection_api_class Factory_inspection_api_dll = new Factory_inspection_api_class();

            textBox1.Text = Factory_inspection_api_dll.erification("0", "1");

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        public class HttpClientHelpClass
        {
            /// <summary>
            /// get请求
            /// </summary>
            /// <param name="url"></param>
            /// <returns></returns>
            public static string GetResponse(string url, out string statusCode)
            {
                if (url.StartsWith("https"))
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(
                  new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                statusCode = response.StatusCode.ToString();
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    return result;
                }
                return null;
            }

            public static string RestfulGet(string url)
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                // Get response
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Get the response stream
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    // Console application output
                    return reader.ReadToEnd();
                }
            }

            public static T GetResponse<T>(string url)
               where T : class, new()
            {
                if (url.StartsWith("https"))
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                T result = default(T);

                if (response.IsSuccessStatusCode)
                {
                    Task<string> t = response.Content.ReadAsStringAsync();
                    string s = t.Result;

                    //result = JsonConvert.DeserializeObject<T>(s);
                }
                return result;
            }

            /// <summary>
            /// post请求
            /// </summary>
            /// <param name="url"></param>
            /// <param name="postData">post数据</param>
            /// <returns></returns>
            public static string PostResponse(string url, string postData, out string statusCode)
            {
                if (url.StartsWith("https"))
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

                HttpContent httpContent = new StringContent(postData);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpContent.Headers.ContentType.CharSet = "utf-8";

                HttpClient httpClient = new HttpClient();
                //httpClient..setParameter(HttpMethodParams.HTTP_CONTENT_CHARSET, "utf-8");

                HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

                statusCode = response.StatusCode.ToString();
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    return result;
                }

                return null;
            }

            /// <summary>
            /// 发起post请求
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="url">url</param>
            /// <param name="postData">post数据</param>
            /// <returns></returns>
            public static T PostResponse<T>(string url, string postData)
                where T : class, new()
            {
                if (url.StartsWith("https"))
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

                HttpContent httpContent = new StringContent(postData);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpClient httpClient = new HttpClient();

                T result = default(T);

                HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    Task<string> t = response.Content.ReadAsStringAsync();
                    string s = t.Result;

                    //result = JsonConvert.DeserializeObject<T>(s);
                }
                return result;
            }


            /// <summary>
            /// 反序列化Xml
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="xmlString"></param>
            /// <returns></returns>
            public static T XmlDeserialize<T>(string xmlString)
                where T : class, new()
            {
                try
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    using (StringReader reader = new StringReader(xmlString))
                    {
                        return (T)ser.Deserialize(reader);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("XmlDeserialize发生异常：xmlString:" + xmlString + "异常信息：" + ex.Message);
                }

            }

            public static string PostResponse(string url, string postData, string token, string appId, string serviceURL, out string statusCode)
            {
                if (url.StartsWith("https"))
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

                HttpContent httpContent = new StringContent(postData);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpContent.Headers.ContentType.CharSet = "utf-8";

                httpContent.Headers.Add("token", token);
                httpContent.Headers.Add("appId", appId);
                httpContent.Headers.Add("serviceURL", serviceURL);


                HttpClient httpClient = new HttpClient();
                //httpClient..setParameter(HttpMethodParams.HTTP_CONTENT_CHARSET, "utf-8");

                HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

                statusCode = response.StatusCode.ToString();
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    return result;
                }

                return null;
            }

            /// <summary>
            /// 修改API
            /// </summary>
            /// <param name="url"></param>
            /// <param name="postData"></param>
            /// <returns></returns>
            public static string KongPatchResponse(string url, string postData)
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.Method = "PATCH";

                byte[] btBodys = Encoding.UTF8.GetBytes(postData);
                httpWebRequest.ContentLength = btBodys.Length;
                httpWebRequest.GetRequestStream().Write(btBodys, 0, btBodys.Length);

                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var streamReader = new StreamReader(httpWebResponse.GetResponseStream());
                string responseContent = streamReader.ReadToEnd();

                httpWebResponse.Close();
                streamReader.Close();
                httpWebRequest.Abort();
                httpWebResponse.Close();

                return responseContent;
            }

            /// <summary>
            /// 创建API
            /// </summary>
            /// <param name="url"></param>
            /// <param name="postData"></param>
            /// <returns></returns>
            public static string KongAddResponse(string url, string postData)
            {
                if (url.StartsWith("https"))
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                HttpContent httpContent = new StringContent(postData);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded") { CharSet = "utf-8" };
                var httpClient = new HttpClient();
                HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    return result;
                }
                return null;
            }

            /// <summary>
            /// 删除API
            /// </summary>
            /// <param name="url"></param>
            /// <returns></returns>
            public static bool KongDeleteResponse(string url)
            {
                if (url.StartsWith("https"))
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

                var httpClient = new HttpClient();
                HttpResponseMessage response = httpClient.DeleteAsync(url).Result;
                return response.IsSuccessStatusCode;
            }

            /// <summary>
            /// 修改或者更改API        
            /// </summary>
            /// <param name="url"></param>
            /// <param name="postData"></param>
            /// <returns></returns>
            public static string KongPutResponse(string url, string postData)
            {
                if (url.StartsWith("https"))
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

                HttpContent httpContent = new StringContent(postData);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded") { CharSet = "utf-8" };

                var httpClient = new HttpClient();
                HttpResponseMessage response = httpClient.PutAsync(url, httpContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    return result;
                }
                return null;
            }

            /// <summary>
            /// 检索API
            /// </summary>
            /// <param name="url"></param>
            /// <returns></returns>
            public static string KongSerchResponse(string url)
            {
                if (url.StartsWith("https"))
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

                var httpClient = new HttpClient();
                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    return result;
                }
                return null;
            }
        }

        /// <summary>
        /// 发起一个HTTP请求（以GET方式）
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string HttpGet(string url)
        {
            WebRequest myWebRequest = WebRequest.Create(url);
            WebResponse myWebResponse = myWebRequest.GetResponse();
            Stream ReceiveStream = myWebResponse.GetResponseStream();
            string responseStr = "";
            if (ReceiveStream != null)
            {
                StreamReader reader = new StreamReader(ReceiveStream, Encoding.UTF8);
                responseStr = reader.ReadToEnd();
                reader.Close();
            }
            myWebResponse.Close();
            return responseStr;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str ;

            //str = HttpGet("http://localhost:1190/api/Default");
            //str = HttpGet("http://172.16.1.72:8580/api/Default");
            str = HttpGet("http://localhost:1190/api/Default");

            textBox1.Text = str;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //    string str;

            //    //str = HttpGet("http://localhost:1190/api/Default");
            //    //str = HttpGet("http://172.16.1.72:8580/api/Default");
            //    //str = HttpClientHelpClass.PostResponse("http://localhost:1190/api/testapi","11",);

            //    textBox1.Text = str;

        }
}
}
