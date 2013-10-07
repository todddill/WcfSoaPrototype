using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.BaseClasses;

namespace Core.Interfaces
{
    public interface ICommunicator
    {
        TransactionBase Send(CommunicatorConfigurationBase configuration);
    }
}
