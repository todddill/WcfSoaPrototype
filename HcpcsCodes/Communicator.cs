using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using SoaHubCore.BaseClasses;
using SoaHubCore.Interfaces;

namespace HcpcsCodes
{
    public class Communicator : ICommunicator<HcpcsCodesMessage>
    {
        private TransactionBase<HcpcsCodesMessage> _transaction;
        const string SOAPENVELOP = "http://www.restfulwebservices.net/ServiceContracts/2008/01";

        public Communicator(TransactionBase<HcpcsCodesMessage> transaction)
        {
            _transaction = transaction;
        }

        #region ICommunicator Members

        public TransactionBase<HcpcsCodesMessage> Send()
        {
            string message = BuildSoapMessage(_transaction.ResponseObject.DestinationMethod, _transaction.ResponseObject.RequestParameters).ToString();
            HttpWebRequest request = BuildHttpRequest(_transaction.ResponseObject.DestinationMethod, _transaction.ResponseObject.DestinationEndpoint);
            string response = WebServiceCall(request, message);
            _transaction.ResponseObject.ResponseParameters["object"] = response;
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
            soapRequest.Append("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ns=\"" + SOAPENVELOP + "\">");
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
