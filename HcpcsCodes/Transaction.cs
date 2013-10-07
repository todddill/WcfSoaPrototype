using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.BaseClasses;

namespace HcpcsCodes
{
    public class Transaction : TransactionBase
    {
        public Transaction()
        {

        }

        public void CreateRequestParameters(List<string> requestParameters)
        {
            foreach (string parameter in requestParameters)
            {
                this.Request.Add(parameter, string.Empty);
            }
        }
    }
}
