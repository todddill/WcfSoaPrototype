using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BaseClasses
{
    public abstract class TransactionBase
    {
        public enum Status { Complete, Request, Failed };

        public Status TransactionStatus;

        public Hashtable Request { get; private set; }

        public Hashtable Response { get; private set; }

        public TransactionBase()
        {
            this.Request = new Hashtable();
            this.Response = new Hashtable();
        }

        //public void AddRequestParameter(string key, string value)
        //{
        //    if(this.Request.ContainsKey(key))
        //        this.Request[key] = value;
        //}

        //public void AddRequestParameters(Hashtable collection)
        //{
        //    this.Request = collection;
        //}

        //public void AddResponseParameter(string key, string value)
        //{
        //    this.Response[key] = value;
        //}

        //public void AddResponseParameters(Hashtable collection)
        //{
        //    this.Response = collection;
        //}
    }
}