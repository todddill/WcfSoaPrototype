using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoaHubCore.Interfaces;
using SoaHubCore.BaseClasses;
using FootballPool.eu.dataaccess.footballpool;
using System.Xml.Serialization;
using System.IO;

namespace FootballPool
{
    public class Communicator : ICommunicator<FootballPoolMessage>
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
    }
}
