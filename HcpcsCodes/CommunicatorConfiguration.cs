using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Core.BaseClasses;
using System.Collections.Specialized;
using System.Xml.Linq;

namespace HcpcsCodes
{
    public class CommunicatorConfiguration : CommunicatorConfigurationBase
    {
        public XDocument XmlConfiguration { get; set; }

        public CommunicatorConfiguration(string path)
        {
            if(!string.IsNullOrEmpty(path))
            {
                string data = File.ReadAllText(path);
                XmlConfiguration = XDocument.Load(path);
            }
        }

        public override void Read()
        {
            RequestParameters = ReadRequestParameters();
        }

        private List<string> ReadRequestParameters()
        {
            List<string> returnValues = new List<string>();
            var data = (from e in XmlConfiguration.Descendants("parameter")
                        where e.Parent.Parent.Name == ("request")
                        select e.Value).ToArray();

            foreach (var p in data)
                returnValues.Add(p.ToString());

            return returnValues;
        }

        public override void Write(string path)
        {
            XmlConfiguration.Save(path);
        }

        public void ClearConfiguration(string path)
        {
            File.Delete(path);
        }
    }
}
