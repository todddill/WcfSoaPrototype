using SoaHubCore.BaseClasses;

namespace SoaHubCore.Interfaces
{
    public interface ICommunicator<T>
    {
        TransactionBase<T> Send();
    }
}
