using System;
using System.Collections.Generic;
using System.Xml.Linq;
using HcpcsCodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoaHubCore.BaseClasses;

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

            XDocument xmlData = XDocument.Load(PATH);
            XPathDefinitions xpathDefinitions = SetUpXPath();
            TransactionBase<HcpcsCodesMessage> transaction = new Transaction(xmlData, xpathDefinitions);

            Assert.IsTrue(transaction.ResponseObject.RequestParameters.ContainsKey("description"));

            SetUpData.ConfigurationData.ClearConfigurationData(PATH);
        }

        [TestMethod]
        public void Transaction_LoadTransactionConfigurationFromXmlFile_ContainsValueObject()
        {
            XDocument doc = SetUpData.ConfigurationData.GetHcpcsConfigurationData();
            SetUpData.ConfigurationData.SaveDataToAnXmlFile(PATH);

            XDocument xmlData = XDocument.Load(PATH);
            XPathDefinitions xpathDefinitions = SetUpXPath();
            TransactionBase<HcpcsCodesMessage> transaction = new Transaction(xmlData, xpathDefinitions);

            Assert.IsTrue(transaction.ResponseObject.ResponseParameters.ContainsKey("object"));

            SetUpData.ConfigurationData.ClearConfigurationData(PATH);
        }

        [TestMethod]
        public void Transaction_LoadTransactionConfigurationFromXmlFile_NullDocumentEqualsNoParameters()
        {
            XDocument xmlData = null;
            XPathDefinitions xpathDefinitions = SetUpXPath();
            TransactionBase<HcpcsCodesMessage> transaction = new Transaction(xmlData, xpathDefinitions);

            Assert.IsTrue(transaction.ResponseObject.RequestParameters == null);

            SetUpData.ConfigurationData.ClearConfigurationData(PATH);
        }

        [TestMethod]
        public void Transaction_LoadTransactionConfigurationFromXmlFile_XpathToEndpointReturnsValue()
        {
            XDocument doc = SetUpData.ConfigurationData.GetHcpcsConfigurationData();
            SetUpData.ConfigurationData.SaveDataToAnXmlFile(PATH);

            XDocument xmlData = XDocument.Load(PATH);
            XPathDefinitions xpathDefinitions = SetUpXPath();
            TransactionBase<HcpcsCodesMessage> transaction = new Transaction(xmlData, xpathDefinitions);

            Assert.IsTrue(transaction.ResponseObject.DestinationEndpoint.Equals("http://www.restfulwebservices.net/wcf/HCPCSService.svc"));

            SetUpData.ConfigurationData.ClearConfigurationData(PATH);
        }

        [TestMethod]
        public void Transaction_LoadTransactionConfigurationFromXmlFile_XpathToMethodReturnsValue()
        {
            XDocument doc = SetUpData.ConfigurationData.GetHcpcsConfigurationData();
            SetUpData.ConfigurationData.SaveDataToAnXmlFile(PATH);

            XDocument xmlData = XDocument.Load(PATH);
            XPathDefinitions xpathDefinitions = SetUpXPath();
            TransactionBase<HcpcsCodesMessage> transaction = new Transaction(xmlData, xpathDefinitions);

            Assert.IsTrue(transaction.ResponseObject.DestinationMethod.Equals("GetDetailsByDescription"));

            SetUpData.ConfigurationData.ClearConfigurationData(PATH);
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
