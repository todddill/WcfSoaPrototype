using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoaHubCore.BaseClasses;

namespace HcpcsCodesTests.MockObjects
{
    public class MockTransactionData : TransactionDataBase
    {
        private string _key;
        private string _value;

        public MockTransactionData(string key, string value)
        {
            _key = key;
            _value = value;
        }

        public override Dictionary<string, string> RequestParameters
        {
            get
            {
                Dictionary<string, string> returnParams = new Dictionary<string, string>();
                returnParams.Add(_key, _value);
                return returnParams;
            }
        }
    }
}
