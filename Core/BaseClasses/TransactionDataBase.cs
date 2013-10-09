using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoaHubCore.BaseClasses
{
    public abstract class TransactionDataBase
    {
        public abstract Dictionary<string, string> RequestParameters { get; }
        public abstract Dictionary<string, string> ResponseParameters { get; }
        public abstract string DestinationEndpoint { get; }
        public abstract string DestinationMethod { get; }
    }
}
