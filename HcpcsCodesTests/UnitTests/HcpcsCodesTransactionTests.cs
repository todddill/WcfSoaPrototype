using HcpcsCodes;
using HcpcsCodesTests.MockObjects;
using HcpcsCodesTests.SetUpData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoaHubCore.BaseClasses;

namespace UnitTests.HcpcsCodesTests
{
    [TestClass]
    public class HcpcsCodesTransactionTests
    {
        [TestMethod]
        public void Transacton_AddParamteter_ParameterIsInTheList()
        {
            Transaction transaction = new Transaction();
            transaction.RequestParameters.Add("Name", "Value");
            Assert.IsTrue(transaction.RequestParameters["Name"].Equals("Value"));
        }

        [TestMethod]
        public void Transaction_LoadTransactionConfiguration_HasDescriptionValue()
        {
            Transaction transaction = new Transaction();
            TransactionDataBase transactionData = new MockTransactionData("description", "Clinical psychologist");
            transaction.LoadTransactionConfiguration(transactionData);

            Assert.IsTrue(transaction.RequestParameters["description"].Equals("Clinical psychologist"));
        }
    }
}
