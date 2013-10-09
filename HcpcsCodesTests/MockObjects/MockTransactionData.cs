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
        private string _requestkey;
        private string _requestvalue;
        private string _responsekey;
        private string _responsevalue;
        private string _endpoint;
        private string _method;

        public MockTransactionData(MockedValues mockedValues)
        {
            _requestkey = mockedValues.RequestKey;
            _requestvalue = mockedValues.RequestValue;
            _responsekey = mockedValues.ResponseKey;
            _responsevalue = mockedValues.ResponseValue;
            _endpoint = mockedValues.Endpoint;
            _method = mockedValues.Method;
        }

        public override Dictionary<string, string> RequestParameters
        {
            get
            {
                Dictionary<string, string> returnParams = new Dictionary<string, string>();
                returnParams.Add(_requestkey, _requestvalue);
                return returnParams;
            }
        }

        public override Dictionary<string, string> ResponseParameters
        {
            get
            {
                Dictionary<string, string> returnParams = new Dictionary<string, string>();
                returnParams.Add(_responsekey, _responsevalue);
                return returnParams;
            }
        }

        public override string DestinationEndpoint
        {
            get { return _endpoint; }
        }

        public override string DestinationMethod
        {
            get { return _method; }
        }
    }

    public class MockedValues
    {
        public string RequestKey { get; set; }
        public string RequestValue { get; set; }
        public string ResponseKey { get; set; }
        public string ResponseValue { get; set; }
        public string Endpoint { get; set; }
        public string Method { get; set; }
    }
}
