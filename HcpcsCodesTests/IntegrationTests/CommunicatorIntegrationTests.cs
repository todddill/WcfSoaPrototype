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

            Transaction request = new Transaction();
            TransactionData transactionData = new TransactionData(PATH);
            transactionData.XpathToRequestParameters = XPATH + "/request/parameters/description";
            transactionData.XpathToResponseParameters = XPATH + "/response/parameters/object";
            transactionData.XpathToEndpoint = XPATH + "/request/endpoint";
            transactionData.XpathToMethod = XPATH + "/request/method";
            request.LoadTransactionConfiguration(transactionData);
            ICommunicator communicator = new Communicator(request);

            TransactionBase response = communicator.Send();

            Assert.IsTrue(response.ResponseParameters["object"].Contains("HCPCS"));
        }
    }
}
