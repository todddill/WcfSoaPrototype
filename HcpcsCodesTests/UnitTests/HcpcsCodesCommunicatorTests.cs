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
            MockedValues mockedValues = SetupMockedTransactionValues();
            TransactionDataBase transactionData = new MockTransactionData(mockedValues);
            TransactionBase<HcpcsCodesMessage> transaction = new Transaction(transactionData);
            ICommunicator<HcpcsCodesMessage> communicator = new Communicator(transaction);

            communicator.Send();

            Assert.IsTrue(transaction.ResponseObject.RequestParameters.ContainsKey("description"));
        }

        [TestMethod]
        public void Communicator_Send_TransactionHasResponseParameter_Object()
        {
            MockedValues mockedValues = SetupMockedTransactionValues();
            TransactionDataBase transactionData = new MockTransactionData(mockedValues);
            TransactionBase<HcpcsCodesMessage> transaction = new Transaction(transactionData);

            ICommunicator<HcpcsCodesMessage> communicator = new Communicator(transaction);

            communicator.Send();

            Assert.IsTrue(transaction.ResponseObject.ResponseParameters.ContainsKey("object"));
        }

        [TestMethod]
        public void Communicator_Send_TransactionHasEndpoint_Name()
        {
            MockedValues mockedValues = SetupMockedTransactionValues();
            TransactionDataBase transactionData = new MockTransactionData(mockedValues);
            TransactionBase<HcpcsCodesMessage> transaction = new Transaction(transactionData);
            ICommunicator<HcpcsCodesMessage> communicator = new Communicator(transaction);

            communicator.Send();

            Assert.IsTrue(transaction.ResponseObject.DestinationEndpoint.Equals("http://www.restfulwebservices.net/wcf/HCPCSService.svc"));
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
