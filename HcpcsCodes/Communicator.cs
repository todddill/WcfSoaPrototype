using System.Collections.Generic;
using SoaHubCore.BaseClasses;
using SoaHubCore.Interfaces;

namespace HcpcsCodes
{
    public class Communicator : ICommunicator
    {
        private TransactionBase _transaction;

        public Communicator(TransactionBase transaction)
        {
            _transaction = transaction;
            BuildRequestMessage();
        }

        private static string BuildRequestMessage()
        {
            return string.Empty;
        }

        #region ICommunicator Members

        public TransactionBase Send()
        {
            return _transaction;
        }

        #endregion
    }
}
