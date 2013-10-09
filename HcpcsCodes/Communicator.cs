using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using SoaHubCore.BaseClasses;
using SoaHubCore.Interfaces;

namespace HcpcsCodes
{
    public class Communicator : ICommunicator
    {
        private TransactionBase _transaction;
        const string SOAPENVELOP = "xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ns=\"http://www.restfulwebservices.net/ServiceContracts/2008/01\"";

        public Communicator(TransactionBase transaction)
        {
            _transaction = transaction;
        }

        #region ICommunicator Members

        public TransactionBase Send()
        {
            string message = BuildSoapMessage(_transaction.DestinationMethod, _transaction.RequestParameters).ToString();
            HttpWebRequest request = BuildHttpRequest(_transaction.DestinationMethod, _transaction.DestinationEndpoint);
            string response = WebServiceCall(request, message);
            _transaction.ResponseParameters["object"] = response;
            return _transaction;
        }

        private static string WebServiceCall(HttpWebRequest httpRequest, string soapRequest)
        {
            Stream requestStream = httpRequest.GetRequestStream();
            //Create Stream and Complete Request             
            StreamWriter streamWriter = new StreamWriter(requestStream, Encoding.ASCII);

            streamWriter.Write(soapRequest);
            streamWriter.Close();
            //Get the Response    
            HttpWebResponse wr = (HttpWebResponse)httpRequest.GetResponse();
            StreamReader srd = new StreamReader(wr.GetResponseStream());
            string resulXmlFromWebService = srd.ReadToEnd();
            return resulXmlFromWebService;
        }

        private static HttpWebRequest BuildHttpRequest(string methodName, string url)
        {
            WebRequest webRequest = WebRequest.Create(url);
            HttpWebRequest httpRequest = (HttpWebRequest)webRequest;
            httpRequest.Method = "POST";
            httpRequest.ContentType = "text/xml; charset=utf-8";
            httpRequest.Headers.Add("SOAPAction:" + methodName);
            httpRequest.ProtocolVersion = HttpVersion.Version11;
            httpRequest.Credentials = CredentialCache.DefaultCredentials;
            return httpRequest;
        }

        private static StringBuilder BuildSoapMessage(string methodName, Dictionary<string, string> methodParameters)
        {
            StringBuilder soapRequest = new StringBuilder();
            soapRequest.Append("<soapenv:Envelope " + SOAPENVELOP + ">");
            soapRequest.Append("<soapenv:Header/>");
            soapRequest.Append("<soapenv:Body>");
            soapRequest.Append("<ns:" + methodName + ">");
            foreach (KeyValuePair<string, string> item in methodParameters)
            {
                soapRequest.Append("<ns:request>" + item.Value + "</ns:request>");
            }
            soapRequest.Append("</ns:" + methodName + ">");
            soapRequest.Append("</soapenv:Body>");
            soapRequest.Append("</soapenv:Envelope>");
            return soapRequest;
        }

        #endregion
    }
}
