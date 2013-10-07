using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.BaseClasses;

namespace HcpcsCodesTests.MockObjects
{
    public class MockCommunicatorConfiguration : CommunicatorConfigurationBase
    {
        public string RequestParameter1 { get; set; }

        public MockCommunicatorConfiguration(string endpoint)
        {
            this.Endpoint = endpoint;
        }

        public override System.Collections.Specialized.NameValueCollection Read()
        {
            throw new NotImplementedException();
        }

        public override void Write(System.Collections.Specialized.NameValueCollection collection)
        {
            throw new NotImplementedException();
        }
    }
}
