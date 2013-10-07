using System;
using System.Collections.Specialized;
using HcpcsCodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HcpcsCodesTests
{
    [TestClass]
    public class HcpcsCodesCommunicatorConfigurationTests
    {
        const string PATH = "configurationTests.txt";
        [TestMethod]
        public void CommunicatorConfiguration_Read_HasWrittenValues()
        {
            NameValueCollection collection = new NameValueCollection();
            collection.Add("Description", "");

            CommunicatorConfiguration config = new CommunicatorConfiguration(PATH);
            config.Write(collection);
            NameValueCollection actualCollection = config.Read();
            config.ClearConfiguration();
            Assert.IsTrue(collection[0].Equals(actualCollection[0]));
        }

        [TestMethod]
        public void CommunicatorConfiguration_ClearConfiguration_FileIsDeleted()
        {
            NameValueCollection collection = new NameValueCollection();
            collection.Add("Description", "");

            CommunicatorConfiguration config = new CommunicatorConfiguration(PATH);
            config.Write(collection);

            config.ClearConfiguration();
            Assert.IsFalse(config.FileExists);
        }
    }
}
