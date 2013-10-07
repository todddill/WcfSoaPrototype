using System;
using System.Collections.Specialized;
using System.Xml.Linq;
using HcpcsCodes;
using HcpcsCodesTests.SetUpData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.HcpcsCodesTests
{
    [TestClass]
    public class HcpcsCodesCommunicatorConfigurationTests
    {
        [TestMethod]
        public void CommunicatorConfiguration_Read_HasValueDescription()
        {
            CommunicatorConfiguration config = new CommunicatorConfiguration(string.Empty);
            config.XmlConfiguration = ConfigurationData.GetHcpcsConfigurationData();
            config.Read();

            Assert.IsTrue(config.RequestParameters[0].Equals("description"));
        }
    }
}
