using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.BaseClasses;

namespace HcpcsCodes
{
    public class Communicator : ICommunicator
    {
        private TransactionBase _transaction;

        public Communicator(TransactionBase transaction)
        {
            _transaction = transaction;
        }

        #region ICommunicator Members

        public TransactionBase Send(CommunicatorConfigurationBase configuration)
        {
            configuration.Read();
            GetRequestFormat(configuration.RequestParameters);
            return _transaction;
        }

        #endregion

        private void GetRequestFormat(List<string> requestParameters)
        { 
            foreach(string parameter in requestParameters)
            {
                _transaction.Request.Add(parameter, string.Empty);
            }
        }
    }
}
