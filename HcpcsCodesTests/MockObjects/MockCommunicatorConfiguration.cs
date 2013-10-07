using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Core.BaseClasses;

namespace HcpcsCodesTests.MockObjects
{
    public class MockCommunicatorConfiguration : CommunicatorConfigurationBase
    {
        public MockCommunicatorConfiguration(string endpoint)
        {
            this.Endpoint = endpoint;
        }

        public override void Read()
        {
            this.RequestParameters = new List<string>();
            this.RequestParameters.Add("description");
        }

        public override void Write(string path)
        {
            throw new NotImplementedException();
        }
    }
}
