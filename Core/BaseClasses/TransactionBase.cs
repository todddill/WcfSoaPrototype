using System.Collections;
using System.Collections.Generic;

namespace SoaHubCore.BaseClasses
{
    public enum Status { Complete, Request, Failed };

    public abstract class TransactionBase
    {
        public Status TransactionStatus { get; set; }

        public abstract Dictionary<string, string> RequestParameters { get; }

        public abstract Dictionary<string, string> ResponseParameters { get; }

        public string DestinationEndpoint { get; set; }

        public string DestinationMethod { get; set; }

        public abstract void LoadTransactionConfiguration(TransactionDataBase transactionData);

    }
}