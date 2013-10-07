using System;
using System.Collections.Generic;
using System.Xml.Linq;
using HcpcsCodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HcpcsCodesTests.IntegrationTests
{
    [TestClass]
    public class CommunicatorConfigurationIntegrationTests
    {
        const string PATH = "configurationData.xml";

        [TestMethod]
        public void Read_XmlConfiguratonFromFileSystem_FirstValueIsDescription()
        {
            XDocument doc = SetUpData.ConfigurationData.GetHcpcsConfigurationData();
            SetUpData.ConfigurationData.SaveDataToAnXmlFile(PATH);

            CommunicatorConfiguration configuration = new CommunicatorConfiguration(PATH);
            configuration.Read();
            List<string> requestParameters = configuration.RequestParameters;

            Assert.IsTrue(requestParameters[0].Contains("description"));

            SetUpData.ConfigurationData.ClearConfigurationData(PATH);
        }

        [TestMethod]
        public void Read_XmlConfiguratonFromFileSystem_SecondValueIsIdentifier()
        {
            XDocument doc = SetUpData.ConfigurationData.GetHcpcsConfigurationData();
            SetUpData.ConfigurationData.SaveDataToAnXmlFile(PATH);

            CommunicatorConfiguration configuration = new CommunicatorConfiguration(PATH);
            configuration.Read();
            List<string> requestParameters = configuration.RequestParameters;

            Assert.IsTrue(requestParameters[1].Contains("identifier"));

            SetUpData.ConfigurationData.ClearConfigurationData(PATH);
        }
    }
}
