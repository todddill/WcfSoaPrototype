using System.Collections.Generic;
using SoaHubCore.BaseClasses;

namespace HcpcsCodes
{
    public class Transaction : TransactionBase
    {
        private Dictionary<string, string> _requestParameters = new Dictionary<string, string>();
        private Dictionary<string, string> _responseParameters = new Dictionary<string, string>();
        private string _endpoint = string.Empty;
        private string _method = string.Empty;

        private TransactionDataBase _transactionData;

        public Transaction()
        {
            
        }

        public override Dictionary<string, string> RequestParameters
        {
            get { return _requestParameters; }
        }

        public override Dictionary<string, string> ResponseParameters
        {
            get { return _responseParameters; }
        }

        private void LoadRequestParameters()
        {
            _requestParameters = _transactionData.RequestParameters;
        }

        private void LoadResponseParameters()
        {
            _responseParameters = _transactionData.ResponseParameters;
        }

        public override void LoadTransactionConfiguration(TransactionDataBase transactionData)
        {
            _transactionData = transactionData;
            LoadRequestParameters();
            LoadConnectionData();
            LoadResponseParameters();
        }

        private void LoadConnectionData()
        {
            _endpoint = _transactionData.DestinationEndpoint;
            _method = _transactionData.DestinationMethod;
        }

        public override string DestinationEndpoint
        {
            get
            {
                return _endpoint;
            }
        }

        public override string DestinationMethod
        {
            get
            {
                return _method;
            }
        }
    }
}
