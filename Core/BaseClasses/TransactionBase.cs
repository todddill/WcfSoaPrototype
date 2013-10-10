using System.Collections;
using System.Collections.Generic;

namespace SoaHubCore.BaseClasses
{
    public abstract class TransactionBase<T>
    {
        public abstract T ResponseObject { get; }
    }
}