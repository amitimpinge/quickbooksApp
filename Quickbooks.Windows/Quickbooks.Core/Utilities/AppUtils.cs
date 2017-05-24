using Interop.QBXMLRP2;
using Quickbooks.Core.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace Quickbooks.Core.Utilities
{
    public class AppUtils
    {
        /// <summary>
        /// Post json data to 3rd party web apis.
        /// </summary>
        /// <param name="destinationUrl"></param>
        /// <param name="requestJSON"></param>
        /// <returns></returns>
        public static string PostJSONData(string destinationUrl, string requestJSON)
        {
            try
            {
                //requestXml = GetTextFromXMLFile();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(destinationUrl);
                byte[] bytes;
                bytes = System.Text.Encoding.ASCII.GetBytes(requestJSON);
                request.ContentType = "application/json";
                request.ContentLength = bytes.Length;
                request.Method = "POST";
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                HttpWebResponse response;
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(responseStream);
                    // Read the content.
                    string responseFromServer = reader.ReadToEnd();

                    return responseFromServer;
                }
                return null;
            }
            catch (WebException webEx)
            {
                return webEx.Message;
            }
        }

        /// <summary>
        /// Calling 3rd party web apis. 
        /// </summary>
        /// <param name="destinationUrl"></param>
        /// <param name="methodName"></param>
        /// <param name="requestJSON"></param>
        /// <returns></returns>
        public static string MakeWebRequest(string destinationUrl, EnumUtils.RequestMethod methodName, string requestJSON = "")
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(destinationUrl);
                request.Method = methodName.ToString();
                if (methodName == EnumUtils.RequestMethod.POST)
                {
                    byte[] bytes = System.Text.Encoding.ASCII.GetBytes(requestJSON);
                    request.ContentType = "application/json";
                    request.ContentLength = bytes.Length;

                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(bytes, 0, bytes.Length);
                    }
                }
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }

                return null;
            }
            catch (WebException webEx)
            {
                return webEx.Message;
            }
        }

        /// <summary>
        /// Connect with quickbooks and read/write data.
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="qbFilePath"></param>
        /// <returns></returns>
        public static ResponseModel ProcessQuickBookRequest(string xml, string qbFilePath)
        {
            bool sessionBegun = false;
            bool connectionOpen = false;
            RequestProcessor2 rp = null;
            string ticket = string.Empty;
            ResponseModel response = null;
            try
            {
                //Create the Request Processor object
                rp = new RequestProcessor2();

                //Connect to QuickBooks and begin a session
                rp.OpenConnection("12345", "Testing");//id of your .net project and name of your .net project.
                connectionOpen = true;
                //ticket = rp.BeginSession(ConfigurationManager.AppSettings["QuickBookFile"], QBFileMode.qbFileOpenDoNotCare);
                ticket = rp.BeginSession(qbFilePath, QBFileMode.qbFileOpenDoNotCare);
                sessionBegun = true;

                //Send the request and get the response from QuickBooks
                response = new ResponseModel
                {
                    ResponseString = rp.ProcessRequest(ticket, xml),
                    Succeeded = true
                };
                //End the session and close the connection to QuickBooks
                rp.EndSession(ticket);
                sessionBegun = false;
                rp.CloseConnection();
                connectionOpen = false;

                //WalkCustomerAddRs(responseStr);

            }
            catch (Exception e)
            {
                if (sessionBegun) { rp.EndSession(ticket); }
                if (connectionOpen) { rp.CloseConnection(); }
                response = new ResponseModel
                {
                    Message = e.Message,
                    Succeeded = false
                };
            }

            return response;
        }

        /// <summary>
        /// Getting data from quickbooks desktop software.
        /// </summary>
        /// <param name="quickBookRequest"></param>
        /// <returns></returns>
        public static RequestNode GetRequestData(EnumUtils.QuickBooksRequests quickBookRequest)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\QBRequestsInputData.xml");
            //XDocument.Load(@"..\service\AppValues.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(QBRequestModel));
            QBRequestModel data = null;
            using (StringReader reader = new StringReader(doc.InnerXml))
            {
                data = (QBRequestModel)(serializer.Deserialize(reader));
            }
            var result = data != null ? data.RequestNode.SingleOrDefault(x => x.Id == (int)quickBookRequest) : null;

            return result;
        }

        /// <summary>
        /// Parse the xml in c# class.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T ParseXML<T>(string xml)
        {
            Type type = typeof(T);
            var obj = Activator.CreateInstance(type);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (StringReader reader = new StringReader(doc.InnerXml))
            {
                obj = (T)(serializer.Deserialize(reader));
            }

            return (T)obj;
        }
    }
}