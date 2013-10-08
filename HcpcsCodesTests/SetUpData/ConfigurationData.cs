using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HcpcsCodesTests.SetUpData
{
    public static class ConfigurationData
    {
        public static XDocument GetHcpcsConfigurationData()
        {
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("hcpcscodesconfiguration",
                    new XElement("request",
                        new XElement("parameters",
                            new XElement("description", "Clinical psychologist")))));
            return doc;
        }

        public static void SaveDataToAnXmlFile(string filename)
        {
            XDocument doc = GetHcpcsConfigurationData();
            doc.Save(filename);
        }

        public static void ClearConfigurationData(string filename)
        {
            File.Delete(filename);
        }
    }
}
