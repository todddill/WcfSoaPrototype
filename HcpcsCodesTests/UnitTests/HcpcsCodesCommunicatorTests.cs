using SoaHubCore.BaseClasses;
using SoaHubCore.Interfaces;
using HcpcsCodes;
using HcpcsCodesTests.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.HcpcsCodesTests
{
    [TestClass]
    public class HcpcsCodesCommunicatorTests
    {
        const string PATH = "configurationTests.txt";

        [TestMethod]
        public void Communicator_Send_TransactionHasRequestParameter_Name()
        {
            TransactionBase transaction = new Transaction();
            TransactionDataBase transactionData = new MockTransactionData("description", "Clinical psychologist");
            transaction.LoadTransactionConfiguration(transactionData);
            ICommunicator communicator = new Communicator(transaction);

            communicator.Send();

            Assert.IsTrue(transaction.RequestParameters.ContainsKey("description"));
        }
    }
}
