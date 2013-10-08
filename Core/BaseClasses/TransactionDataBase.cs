using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoaHubCore.BaseClasses
{
    public abstract class TransactionDataBase
    {
        public abstract Dictionary<string, string> RequestParameters { get; }
    }
}
