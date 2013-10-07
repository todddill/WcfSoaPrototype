using System;
using System.Collections.Specialized;
using System.Xml.Linq;
using Core.BaseClasses;
using HcpcsCodes;
using HcpcsCodesTests.SetUpData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.HcpcsCodesTests
{
    [TestClass]
    public class HcpcsCodesTransactionTests
    {
        const string PATH = "configurationTests.txt";

        [TestMethod]
        public void Transacton_AddParamteter_ParameterIsInTheList()
        {
            Transaction transaction = new Transaction();
            transaction.Request.Add("Name", "Value");
            Assert.IsTrue(transaction.Request["Name"].Equals("Value"));
        }

        [TestMethod]
        public void Transaction_PopulateRequestParams_CheckTheyExist()
        {
            Transaction transaction = new Transaction();
            CommunicatorConfiguration config = new CommunicatorConfiguration(string.Empty);
            config.XmlConfiguration = ConfigurationData.GetHcpcsConfigurationData();
            config.Read();

            transaction.CreateRequestParameters(config.RequestParameters);

            transaction.Request.Add("Description", "Clinical psychologist");
            Assert.IsTrue(transaction.Request["Description"].Equals("Clinical psychologist"));
        }
    }
}
