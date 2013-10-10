using System.Xml.Linq;
using HcpcsCodes;
using HcpcsCodesTests.SetUpData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoaHubCore.BaseClasses;

namespace UnitTests.HcpcsCodesTests
{
    [TestClass]
    public class HcpcsCodesTransactionTests
    {
        const string XPATH = "/hcpcscodesconfiguration";

        [TestMethod]
        public void Transaction_LoadTransactionConfiguration_RequestHasDescriptionValue()
        {
            XDocument configurationData = ConfigurationData.GetHcpcsConfigurationData();
            XPathDefinitions xpathDefinitions = SetUpXPath();
            TransactionBase<HcpcsCodesMessage> transaction = new Transaction(configurationData, xpathDefinitions);
            

            Assert.IsTrue(transaction.ResponseObject.RequestParameters["description"].Equals("Clinical psychologist"));
        }

        [TestMethod]
        public void Transaction_LoadTransactionConfiguration_ResponseHasObjectValue()
        {
            XDocument configurationData = ConfigurationData.GetHcpcsConfigurationData();
            XPathDefinitions xpathDefinitions = SetUpXPath();
            TransactionBase<HcpcsCodesMessage> transaction = new Transaction(configurationData, xpathDefinitions);

            Assert.IsTrue(transaction.ResponseObject.ResponseParameters["object"].Equals("HCPCS"));
        }

        [TestMethod]
        public void Transaction_LoadTransactionConfiguration_HasEndpointValue()
        {
            XDocument configurationData = ConfigurationData.GetHcpcsConfigurationData();
            XPathDefinitions xpathDefinitions = SetUpXPath();
            TransactionBase<HcpcsCodesMessage> transaction = new Transaction(configurationData, xpathDefinitions);

            Assert.IsTrue(transaction.ResponseObject.DestinationEndpoint.Equals("http://www.restfulwebservices.net/wcf/HCPCSService.svc"));
        }

        [TestMethod]
        public void Transaction_LoadTransactionConfiguration_HasMethodValue()
        {
            XDocument configurationData = ConfigurationData.GetHcpcsConfigurationData();
            XPathDefinitions xpathDefinitions = SetUpXPath();
            TransactionBase<HcpcsCodesMessage> transaction = new Transaction(configurationData, xpathDefinitions);

            Assert.IsTrue(transaction.ResponseObject.DestinationMethod.Equals("GetDetailsByDescription"));
        }

        private static XPathDefinitions SetUpXPath()
        {
            XPathDefinitions xpathDefinitions = new XPathDefinitions();
            xpathDefinitions.XpathToRequestParameters = XPATH + "/request/parameters/description";
            xpathDefinitions.XpathToResponseParameters = XPATH + "/response/parameters/object";
            xpathDefinitions.XpathToEndpoint = XPATH + "/request/endpoint";
            xpathDefinitions.XpathToMethod = XPATH + "/request/method";

            return xpathDefinitions;
        }
    }
}
