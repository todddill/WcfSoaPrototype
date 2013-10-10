using System;
using System.IO;
using System.Xml.Serialization;
using FootballPool.eu.dataaccess.footballpool;
using SoaHubCore.BaseClasses;
using SoaHubCore.Interfaces;

namespace FootballPool
{
    public class Communicator : ICommunicator<FootballPoolMessage>, IDisposable
    {
        private Info _proxy = new Info();
        private TransactionBase<FootballPoolMessage> _transaction;

        public Communicator(TransactionBase<FootballPoolMessage> transaction)
        {
            _transaction = transaction;
        }

        #region ICommunicator Members

        public TransactionBase<FootballPoolMessage> Send()
        {
            _transaction.ResponseObject.Cities = GetCities();
            _transaction.ResponseObject.LastGroupPlayed = GetLastGroupGameDate();
            _transaction.ResponseObject.GameInfo = SerializeObject<tGameInfo>(GetGameInfo(1));

            return _transaction;
        }

        private tGameInfo GetGameInfo(int gameId)
        {
            return _proxy.GameInfo(gameId);
        }

        public static string SerializeObject<T>(T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
            StringWriter textWriter = new StringWriter();

            xmlSerializer.Serialize(textWriter, toSerialize);
            return textWriter.ToString();
        }

        private DateTime GetLastGroupGameDate()
        {
            return _proxy.DateLastGroupGame();
        }

        private string[] GetCities()
        {
            return _proxy.Cities();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        // NOTE: Leave out the finalizer altogether if this class doesn't 
        // own unmanaged resources itself, but leave the other methods
        // exactly as they are. 
        ~Communicator() 
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }
        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (disposing) 
            {
                // free managed resources
                if (_proxy != null)
                {
                    _proxy.Dispose();
                }
            }
        }

        #endregion
    }
}
