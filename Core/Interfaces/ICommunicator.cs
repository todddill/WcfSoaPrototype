using SoaHubCore.BaseClasses;

namespace SoaHubCore.Interfaces
{
    public interface ICommunicator
    {
        TransactionBase Send();
    }
}
