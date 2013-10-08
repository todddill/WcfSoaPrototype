using System.Collections.Generic;
using SoaHubCore.BaseClasses;

namespace HcpcsCodes
{
    public class Transaction : TransactionBase
    {
        private Dictionary<string, string> _requestParameters = new Dictionary<string, string>();
        private Dictionary<string, string> _responseParameters = new Dictionary<string, string>();
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

        public override void LoadTransactionConfiguration(TransactionDataBase transactionData)
        {
            _transactionData = transactionData;
            LoadRequestParameters();
        }
    }
}
