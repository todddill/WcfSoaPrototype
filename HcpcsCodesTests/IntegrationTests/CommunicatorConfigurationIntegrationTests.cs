using System;
using System.Collections.Generic;
using System.Xml.Linq;
using HcpcsCodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HcpcsCodesTests.IntegrationTests
{
    [TestClass]
    public class CommunicatorConfigurationIntegrationTests
    {
        const string PATH = "configurationData.xml";
        const string XPATH = "/hcpcscodesconfiguration";

        [TestMethod]
        public void Transaction_LoadTransactionConfigurationFromXmlFile_ContainsValueDescription()
        {
            XDocument doc = SetUpData.ConfigurationData.GetHcpcsConfigurationData();
            SetUpData.ConfigurationData.SaveDataToAnXmlFile(PATH);

            Transaction transaction = new Transaction();
            TransactionData transactionData = new TransactionData(PATH);
            transactionData.XpathToRequestParameters = XPATH + "/request/parameters/description";
            transaction.LoadTransactionConfiguration(transactionData);

            Assert.IsTrue(transaction.RequestParameters.ContainsKey("description"));

            SetUpData.ConfigurationData.ClearConfigurationData(PATH);
        }

        [TestMethod]
        public void Transaction_LoadTransactionConfigurationFromXmlFile_ContainsValueObject()
        {
            XDocument doc = SetUpData.ConfigurationData.GetHcpcsConfigurationData();
            SetUpData.ConfigurationData.SaveDataToAnXmlFile(PATH);

            Transaction transaction = new Transaction();
            TransactionData transactionData = new TransactionData(PATH);
            transactionData.XpathToResponseParameters = XPATH + "/response/parameters/object";
            transaction.LoadTransactionConfiguration(transactionData);

            Assert.IsTrue(transaction.ResponseParameters.ContainsKey("object"));

            SetUpData.ConfigurationData.ClearConfigurationData(PATH);
        }

        [TestMethod]
        public void Transaction_LoadTransactionConfigurationFromXmlFile_NoPathEqualsNoParameters()
        {
            XDocument doc = SetUpData.ConfigurationData.GetHcpcsConfigurationData();
            SetUpData.ConfigurationData.SaveDataToAnXmlFile(PATH);

            Transaction transaction = new Transaction();
            TransactionData transactionData = new TransactionData(PATH);
            transactionData.XpathToRequestParameters = string.Empty;
            transaction.LoadTransactionConfiguration(transactionData);

            Assert.IsTrue(transaction.RequestParameters.Count == 0);

            SetUpData.ConfigurationData.ClearConfigurationData(PATH);
        }

        [TestMethod]
        public void Transaction_LoadTransactionConfigurationFromXmlFile_XpathToEndpointReturnsValue()
        {
            XDocument doc = SetUpData.ConfigurationData.GetHcpcsConfigurationData();
            SetUpData.ConfigurationData.SaveDataToAnXmlFile(PATH);

            Transaction transaction = new Transaction();
            TransactionData transactionData = new TransactionData(PATH);
            transactionData.XpathToEndpoint =  XPATH + "/request/endpoint";
            transaction.LoadTransactionConfiguration(transactionData);

            Assert.IsTrue(transaction.DestinationEndpoint.Equals("http://www.restfulwebservices.net/wcf/HCPCSService.svc"));

            SetUpData.ConfigurationData.ClearConfigurationData(PATH);
        }

        [TestMethod]
        public void Transaction_LoadTransactionConfigurationFromXmlFile_XpathToMethodReturnsValue()
        {
            XDocument doc = SetUpData.ConfigurationData.GetHcpcsConfigurationData();
            SetUpData.ConfigurationData.SaveDataToAnXmlFile(PATH);

            Transaction transaction = new Transaction();
            TransactionData transactionData = new TransactionData(PATH);
            transactionData.XpathToMethod = XPATH + "/request/method";
            transaction.LoadTransactionConfiguration(transactionData);

            Assert.IsTrue(transaction.DestinationMethod.Equals("GetDetailsByDescription"));

            SetUpData.ConfigurationData.ClearConfigurationData(PATH);
        }
    }
}
