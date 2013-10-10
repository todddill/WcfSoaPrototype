using System.Collections.Generic;
using SoaHubCore.BaseClasses;

namespace HcpcsCodes
{
    public class HcpcsCodesMessage
    {
        public Dictionary<string, string> RequestParameters { get; set; }

        public Dictionary<string, string> ResponseParameters { get; set; }

        public string DestinationEndpoint { get; set; }

        public string DestinationMethod { get; set; }
    }

    public class Transaction : TransactionBase<HcpcsCodesMessage>
    {

        private TransactionDataBase _transactionData;

        private HcpcsCodesMessage _hcpcsCodesMessage = new HcpcsCodesMessage();

        public Transaction(TransactionDataBase transactionData)
        {
            LoadTransactionConfiguration(transactionData);
        }

        private void LoadRequestParameters()
        {
            _hcpcsCodesMessage.RequestParameters = _transactionData.RequestParameters;
        }

        private void LoadResponseParameters()
        {
            _hcpcsCodesMessage.ResponseParameters = _transactionData.ResponseParameters;
        }

        private void LoadTransactionConfiguration(TransactionDataBase transactionData)
        {
            _transactionData = transactionData;
            LoadRequestParameters();
            LoadConnectionData();
            LoadResponseParameters();
        }

        private void LoadConnectionData()
        {
            _hcpcsCodesMessage.DestinationEndpoint = _transactionData.DestinationEndpoint;
            _hcpcsCodesMessage.DestinationMethod = _transactionData.DestinationMethod;
        }

        public override HcpcsCodesMessage ResponseObject
        {
            get { return _hcpcsCodesMessage; }
        }
    }
}
