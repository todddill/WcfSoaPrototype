using System;
using System.Xml.Linq;
using HcpcsCodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoaHubCore.BaseClasses;
using SoaHubCore.Interfaces;

namespace HcpcsCodesTests.IntegrationTests
{
    [TestClass]
    public class CommunicatorIntegrationTests
    {
        const string PATH = "configurationData.xml";
        const string XPATH = "/hcpcscodesconfiguration";

        [TestMethod]
        public void Communicator_Send_GetResponse()
        {
            XDocument doc = SetUpData.ConfigurationData.GetHcpcsConfigurationData();
            SetUpData.ConfigurationData.SaveDataToAnXmlFile(PATH);

            XDocument xmlData = XDocument.Load(PATH);
            XPathDefinitions xpathDefinitions = SetUpXPath();
            TransactionBase<HcpcsCodesMessage> transaction = new Transaction(xmlData, xpathDefinitions);

            ICommunicator<HcpcsCodesMessage> communicator = new Communicator(transaction);

            TransactionBase<HcpcsCodesMessage> response = communicator.Send();

            Assert.IsTrue(response.ResponseObject.ResponseParameters["object"].Contains("HCPCS"));
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
