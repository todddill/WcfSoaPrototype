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

            TransactionData transactionData = new TransactionData(PATH);
            transactionData.XpathToRequestParameters = XPATH + "/request/parameters/description";
            transactionData.XpathToResponseParameters = XPATH + "/response/parameters/object";
            transactionData.XpathToEndpoint = XPATH + "/request/endpoint";
            transactionData.XpathToMethod = XPATH + "/request/method";
            Transaction request = new Transaction(transactionData);

            ICommunicator<HcpcsCodesMessage> communicator = new Communicator(request);

            TransactionBase<HcpcsCodesMessage> response = communicator.Send();

            Assert.IsTrue(response.ResponseObject.ResponseParameters["object"].Contains("HCPCS"));
        }
    }
}
