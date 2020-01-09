using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using API调用第二版.entity;
using API调用第二版.utils;
using Newtonsoft.Json;

namespace API调用第二版.service
{
  public class WebApiClient
    {
        private List<Param> parmList;
        private string strUrl;
        private Dictionary<string, object> Headers;
        public WebApiClient(List<Param> parmList, string strUrl, Dictionary<string, object> Headers) {
            this.parmList = parmList;
            this.strUrl = strUrl;
            this.Headers = Headers;
        }

        /// <summary>
        /// 给header赋值
        /// </summary>
        /// <param name="request"></param>
        private void SetHeaders(ref HttpWebRequest request) {
            foreach (var v in Headers) {
                if (request.GetType().GetProperty(v.Key) != null) {
                    request.GetType().GetProperty(v.Key).SetValue(request,v.Value);
                }
            }
        }

        /// <summary>
        /// Get请求调用API
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string GetHttpValues(string url) {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            SetHeaders(ref request);
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex) {
                response = ex.Response as HttpWebResponse;
            }
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Post请求调用API
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private string PostHttpValues(object obj) {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUrl);
            SetHeaders(ref request);
            byte[] buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));
            request.ContentLength = buffer.Length;
            Stream writer;
            try
            {
                writer = request.GetRequestStream();
            }
            catch (Exception ex) { writer = null; }
            writer.Write(buffer, 0, buffer.Length);writer.Close();
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex) {
                response = ex.Response as HttpWebResponse;
            }
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// API调用入口
        /// </summary>
        /// <returns></returns>
        public string Call() {
            string method = Headers["Method"].ToString();
            if (method.ToLower().Equals("get"))
            {
                string url = strUrl + ParamUtils.ParaListConversionToGet(parmList);
                return GetHttpValues(url);
            }
            else if (method.ToLower().Equals("post"))
            {
                object obj = ParamUtils.ParaListConversion(parmList);
                return PostHttpValues(obj);
            }
            else {
                return "提交方式输入错误";
            }
        }
    }
}
