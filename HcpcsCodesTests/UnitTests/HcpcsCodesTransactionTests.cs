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
        public void Transaction_LoadTransactionConfiguration_RequestHasDescriptionValue()
        {
            MockedValues mockedValues = SetupMockedTransactionValues();
            TransactionDataBase transactionData = new MockTransactionData(mockedValues);
            Transaction transaction = new Transaction(transactionData);

            Assert.IsTrue(transaction.ResponseObject.RequestParameters["description"].Equals("Clinical psychologist"));
        }

        [TestMethod]
        public void Transaction_LoadTransactionConfiguration_ResponseHasObjectValue()
        {
            MockedValues mockedValues = SetupMockedTransactionValues();
            TransactionDataBase transactionData = new MockTransactionData(mockedValues);
            Transaction transaction = new Transaction(transactionData);

            Assert.IsTrue(transaction.ResponseObject.ResponseParameters["object"].Equals("HCPCS"));
        }

        [TestMethod]
        public void Transaction_LoadTransactionConfiguration_HasEndpointValue()
        {
            MockedValues mockedValues = SetupMockedTransactionValues();
            TransactionDataBase transactionData = new MockTransactionData(mockedValues);
            Transaction transaction = new Transaction(transactionData);

            Assert.IsTrue(transaction.ResponseObject.DestinationEndpoint.Equals("http://www.restfulwebservices.net/wcf/HCPCSService.svc"));
        }

        [TestMethod]
        public void Transaction_LoadTransactionConfiguration_HasMethodValue()
        {
            MockedValues mockedValues = SetupMockedTransactionValues();
            TransactionDataBase transactionData = new MockTransactionData(mockedValues);
            Transaction transaction = new Transaction(transactionData);

            Assert.IsTrue(transaction.ResponseObject.DestinationMethod.Equals("GetDetailsByDescription"));
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
