using System;
using HcpcsCodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HcpcsCodesTests.UnitTests
{
    [TestClass]
    public class HcpcsCodesTransactionDataTests
    {
        [TestMethod]
        public void LoadConfigurationData_NoPath_EmptyXDocument()
        {
            TransactionData transactionData = new TransactionData(string.Empty);
            Assert.IsNull(transactionData.XmlData.Root);
        }
    }
}
