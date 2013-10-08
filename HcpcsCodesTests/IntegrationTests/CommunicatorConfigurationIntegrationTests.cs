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
        const string XPATH = "/hcpcscodesconfiguration/request/parameters";

        [TestMethod]
        public void Transaction_LoadTransactionConfigurationFromXmlFile_ContainsValueDescription()
        {
            XDocument doc = SetUpData.ConfigurationData.GetHcpcsConfigurationData();
            SetUpData.ConfigurationData.SaveDataToAnXmlFile(PATH);

            Transaction transaction = new Transaction();
            TransactionData transactionData = new TransactionData(PATH);
            transactionData.XpathToRequestParameters = XPATH + "/description";
            transaction.LoadTransactionConfiguration(transactionData);

            Assert.IsTrue(transaction.RequestParameters.ContainsKey("description"));

            SetUpData.ConfigurationData.ClearConfigurationData(PATH);
        }
    }
}
