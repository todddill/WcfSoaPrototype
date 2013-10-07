using System;
using System.Collections.Specialized;
using Core.BaseClasses;
using HcpcsCodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HcpcsCodesTests
{
    [TestClass]
    public class HcpcsCodesTransactionTests
    {
        const string PATH = "configurationTests.txt";

        [TestMethod]
        public void Transacton_AddParamteter_ParameterIsInTheList()
        {
            Transaction transaction = new Transaction();
            transaction.AddRequestParameter("Name", "Value");
            Assert.IsTrue(transaction.Request["Name"].Equals("Value"));
        }

        [TestMethod]
        public void Transaction_PopulateRequestParams_CheckTheyExist()
        {
            NameValueCollection collection = new NameValueCollection();
            collection.Add("Description", "");

            CommunicatorConfiguration config = new CommunicatorConfiguration(PATH);
            config.Write(collection);

            Transaction transaction = new Transaction();
            //transaction.AddRequestParameters(config.Read());

            transaction.AddRequestParameter("Description", "Clinical psychologist");

            config.ClearConfiguration();
            Assert.IsTrue(transaction.Request["Description"].Equals("Clinical psychologist"));
        }
    }
}
