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

        public abstract string DestinationEndpoint { get; }

        public abstract string DestinationMethod { get; }

        public abstract void LoadTransactionConfiguration(TransactionDataBase transactionData);

    }
}