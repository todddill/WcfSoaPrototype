using SoaHubCore.BaseClasses;
using SoaHubCore.Interfaces;
using HcpcsCodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HcpcsCodesTests.SetUpData;
using System.Xml.Linq;

namespace UnitTests.HcpcsCodesTests
{
    [TestClass]
    public class HcpcsCodesCommunicatorTests
    {
        const string PATH = "configurationTests.txt";
        const string XPATH = "/hcpcscodesconfiguration";

        [TestMethod]
        public void Communicator_Send_TransactionHasRequestParameter_Description()
        {
            XDocument configurationData = ConfigurationData.GetHcpcsConfigurationData();
            XPathDefinitions xpathDefinitions = SetUpXPath();
            TransactionBase<HcpcsCodesMessage> transaction = new Transaction(configurationData, xpathDefinitions);
            ICommunicator<HcpcsCodesMessage> communicator = new Communicator(transaction);

            communicator.Send();

            Assert.IsTrue(transaction.ResponseObject.RequestParameters.ContainsKey("description"));
        }

        [TestMethod]
        public void Communicator_Send_TransactionHasResponseParameter_Object()
        {
            XDocument configurationData = ConfigurationData.GetHcpcsConfigurationData();
            XPathDefinitions xpathDefinitions = SetUpXPath();
            TransactionBase<HcpcsCodesMessage> transaction = new Transaction(configurationData, xpathDefinitions);
            ICommunicator<HcpcsCodesMessage> communicator = new Communicator(transaction);

            communicator.Send();

            Assert.IsTrue(transaction.ResponseObject.ResponseParameters.ContainsKey("object"));
        }

        [TestMethod]
        public void Communicator_Send_TransactionHasEndpoint_Name()
        {
            XDocument configurationData = ConfigurationData.GetHcpcsConfigurationData();
            XPathDefinitions xpathDefinitions = SetUpXPath();
            TransactionBase<HcpcsCodesMessage> transaction = new Transaction(configurationData, xpathDefinitions);
            ICommunicator<HcpcsCodesMessage> communicator = new Communicator(transaction);

            communicator.Send();

            Assert.IsTrue(transaction.ResponseObject.DestinationEndpoint.Equals("http://www.restfulwebservices.net/wcf/HCPCSService.svc"));
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
