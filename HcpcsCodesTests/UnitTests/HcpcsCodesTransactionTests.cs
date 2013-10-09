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
            Transaction transaction = new Transaction();
            MockedValues mockedValues = SetupMockedTransactionValues();

            TransactionDataBase transactionData = new MockTransactionData(mockedValues);
            transaction.LoadTransactionConfiguration(transactionData);

            Assert.IsTrue(transaction.RequestParameters["description"].Equals("Clinical psychologist"));
        }

        [TestMethod]
        public void Transaction_LoadTransactionConfiguration_ResponseHasObjectValue()
        {
            Transaction transaction = new Transaction();
            MockedValues mockedValues = SetupMockedTransactionValues();

            TransactionDataBase transactionData = new MockTransactionData(mockedValues);
            transaction.LoadTransactionConfiguration(transactionData);

            Assert.IsTrue(transaction.ResponseParameters["object"].Equals("HCPCS"));
        }

        [TestMethod]
        public void Transaction_LoadTransactionConfiguration_HasEndpointValue()
        {
            Transaction transaction = new Transaction();
            MockedValues mockedValues = SetupMockedTransactionValues();

            TransactionDataBase transactionData = new MockTransactionData(mockedValues);
            transaction.LoadTransactionConfiguration(transactionData);

            Assert.IsTrue(transaction.DestinationEndpoint.Equals("http://www.restfulwebservices.net/wcf/HCPCSService.svc"));
        }

        [TestMethod]
        public void Transaction_LoadTransactionConfiguration_HasMethodValue()
        {
            Transaction transaction = new Transaction();
            MockedValues mockedValues = SetupMockedTransactionValues();

            TransactionDataBase transactionData = new MockTransactionData(mockedValues);
            transaction.LoadTransactionConfiguration(transactionData);

            Assert.IsTrue(transaction.DestinationMethod.Equals("GetDetailsByDescription"));
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
