using System;
using Core.BaseClasses;
using Core.Interfaces;
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
            ICommunicator communicator = new Communicator(transaction);

            MockCommunicatorConfiguration configuration = new MockCommunicatorConfiguration(PATH);

            communicator.Send(configuration);

            Assert.IsTrue(transaction.Request.ContainsKey("description"));
        }
    }
}
