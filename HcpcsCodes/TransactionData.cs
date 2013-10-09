using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using SoaHubCore.BaseClasses;

namespace HcpcsCodes
{
    public class TransactionData : TransactionDataBase
    {
        public XDocument XmlData { get; set; }
        public string XpathToRequestParameters { get; set; }
        public string XpathToResponseParameters { get; set; }
        public string XpathToEndpoint { get; set; }
        public string XpathToMethod { get; set; }

        public TransactionData(string pathToConfigurationData)
        {
            XmlData = LoadTransactionConfigurationData(pathToConfigurationData);
        }

        public override Dictionary<string, string> RequestParameters
        {
            get
            {
                return GetRequestParameters();
            }
        }

        public override Dictionary<string, string> ResponseParameters
        {
            get
            {
                return GetResponseParameters();
            }
        }

        private Dictionary<string, string> GetResponseParameters()
        {
            if (!string.IsNullOrEmpty(XpathToResponseParameters))
            {
                var parameterNodes = XmlData.XPathSelectElements(XpathToResponseParameters);
                return parameterNodes.ToDictionary(n => n.Name.ToString(), n => n.Value);
            }
            return new Dictionary<string, string>();
        }

        private Dictionary<string, string> GetRequestParameters()
        {
            if (!string.IsNullOrEmpty(XpathToRequestParameters))
            {
                var parameterNodes = XmlData.XPathSelectElements(XpathToRequestParameters);
                return parameterNodes.ToDictionary(n => n.Name.ToString(), n => n.Value);
            }
            return new Dictionary<string, string>();
        }

        public override string DestinationEndpoint
        {
            get 
            {
                return GetEndPoint();
            }
        }

        public override string DestinationMethod
        {
            get
            {
                return GetMethod();
            }
        }

        private string GetMethod()
        {
            if (!string.IsNullOrEmpty(XpathToMethod))
            {
                var methodNode = XmlData.XPathSelectElement(XpathToMethod);
                return methodNode.Value;
            }
            return string.Empty;
        }

        private string GetEndPoint()
        {
            if (!string.IsNullOrEmpty(XpathToEndpoint))
            {
                var endpointNode = XmlData.XPathSelectElement(XpathToEndpoint);
                return endpointNode.Value;
            }
            return string.Empty;
        }

        private static XDocument LoadTransactionConfigurationData(string pathToConfigurationData)
        {
            if (string.IsNullOrEmpty(pathToConfigurationData)) return new XDocument();
            return XDocument.Load(pathToConfigurationData);
        }

        public void Write(string pathToConfigurationData)
        {
            XmlData.Save(pathToConfigurationData);
        }

        public static void ClearConfiguration(string pathToConfigurationData)
        {
            File.Delete(pathToConfigurationData);
        }

        
    }
}
