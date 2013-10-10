using System;
using System.Collections.Generic;
using SoaHubCore.BaseClasses;

namespace FootballPool
{
    public class FootballPoolMessage
    {
        public string[] Cities { get; set; }
        public DateTime LastGroupPlayed { get; set; }
        public string GameInfo { get; set; }
    }

    public class Transaction : TransactionBase<FootballPoolMessage>
    {
        private FootballPoolMessage _responseObject = new FootballPoolMessage();

        public override FootballPoolMessage ResponseObject 
        {
            get { return _responseObject;  }
        }
    }
}
