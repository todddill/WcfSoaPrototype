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
        public void Communicator_Send_TransactionHasRequestParameter_Description()
        {
            TransactionBase transaction = new Transaction();

            MockedValues mockedValues = SetupMockedTransactionValues();

            TransactionDataBase transactionData = new MockTransactionData(mockedValues);

            transaction.LoadTransactionConfiguration(transactionData);
            ICommunicator communicator = new Communicator(transaction);

            communicator.Send();

            Assert.IsTrue(transaction.RequestParameters.ContainsKey("description"));
        }

        [TestMethod]
        public void Communicator_Send_TransactionHasResponseParameter_Object()
        {
            TransactionBase transaction = new Transaction();

            MockedValues mockedValues = SetupMockedTransactionValues();

            TransactionDataBase transactionData = new MockTransactionData(mockedValues);

            transaction.LoadTransactionConfiguration(transactionData);
            ICommunicator communicator = new Communicator(transaction);

            communicator.Send();

            Assert.IsTrue(transaction.ResponseParameters.ContainsKey("object"));
        }

        [TestMethod]
        public void Communicator_Send_TransactionHasEndpoint_Name()
        {
            TransactionBase transaction = new Transaction();

            MockedValues mockedValues = SetupMockedTransactionValues();

            TransactionDataBase transactionData = new MockTransactionData(mockedValues);

            transaction.LoadTransactionConfiguration(transactionData);
            ICommunicator communicator = new Communicator(transaction);

            communicator.Send();

            Assert.IsTrue(transaction.DestinationEndpoint.Equals("http://www.restfulwebservices.net/wcf/HCPCSService.svc"));
        }

        private static MockedValues SetupMockedTransactionValues()
        {
            MockedValues mockedValues = new MockedValues();
            mockedValues.RequestKey = "description";
            mockedValues.RequestValue = "Clinical psychologist";
            mockedValues.ResponseKey = "object";
            mockedValues.ResponseValue = "HCPCS";
            mockedValues.Endpoint = "http://www.restfulwebservices.net/wcf/HCPCSService.svc";
            mockedValues.Method = "GetDetailsByDescription";
            return mockedValues;
        }
    }
}
