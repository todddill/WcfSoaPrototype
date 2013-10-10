using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Linq;
using SoaHubCore.BaseClasses;

namespace HcpcsCodes
{
    public class HcpcsCodesMessage
    {
        public Dictionary<string, string> RequestParameters { get; set; }

        public Dictionary<string, string> ResponseParameters { get; set; }

        public string DestinationEndpoint { get; set; }

        public string DestinationMethod { get; set; }

        public string MessageNamespace { get; set; }
    }

    public class XPathDefinitions
    {
        public string XpathToRequestParameters { get; set; }
        public string XpathToResponseParameters { get; set; }
        public string XpathToEndpoint { get; set; }
        public string XpathToMethod { get; set; }
    }

    public class Transaction : TransactionBase<HcpcsCodesMessage>
    {
        private HcpcsCodesMessage _hcpcsCodesMessage = new HcpcsCodesMessage();
        private XPathDefinitions _xpathDefinitions = new XPathDefinitions();
        private XDocument _xmlConfiguration = new XDocument();

        public Transaction(XDocument xmlConfiguration, XPathDefinitions xpathDefinitions)
        {
            if (xmlConfiguration != null)
            {
                _xpathDefinitions = xpathDefinitions;
                _xmlConfiguration = xmlConfiguration;
                LoadRequestParameters();
                LoadResponseParameters();
                LoadConnectionData();
            }
        }

        private void LoadRequestParameters()
        {
            var parameterNodes = _xmlConfiguration.XPathSelectElements(_xpathDefinitions.XpathToRequestParameters);
            _hcpcsCodesMessage.RequestParameters = parameterNodes.ToDictionary(n => n.Name.ToString(), n => n.Value);
        }

        private void LoadResponseParameters()
        {
            var parameterNodes = _xmlConfiguration.XPathSelectElements(_xpathDefinitions.XpathToResponseParameters);
            _hcpcsCodesMessage.ResponseParameters = parameterNodes.ToDictionary(n => n.Name.ToString(), n => n.Value);
        }

        private void LoadConnectionData()
        {
            _hcpcsCodesMessage.DestinationEndpoint = _xmlConfiguration.XPathSelectElement(_xpathDefinitions.XpathToEndpoint).Value;
            _hcpcsCodesMessage.DestinationMethod = _xmlConfiguration.XPathSelectElement(_xpathDefinitions.XpathToMethod).Value;
        }

        public override HcpcsCodesMessage ResponseObject
        {
            get { return _hcpcsCodesMessage; }
        }
    }
}
