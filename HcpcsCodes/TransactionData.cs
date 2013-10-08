using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using SoaHubCore.BaseClasses;

namespace HcpcsCodes
{
    public class TransactionData : TransactionDataBase
    {
        public XDocument XmlData { get; set; }
        public string XpathToRequestParameters { get; set; }

        public TransactionData(string pathToConfigurationData)
        {
            XmlData = LoadTransactionConfigurationData(pathToConfigurationData);
        }

        public override Dictionary<string, string> RequestParameters
        {
            get
            {
                var parameterNodes = XmlData.XPathSelectElements(XpathToRequestParameters);
                return parameterNodes.ToDictionary(n => n.Name.ToString(), n => n.Value);
            }
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
