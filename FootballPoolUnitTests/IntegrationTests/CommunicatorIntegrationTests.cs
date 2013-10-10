using System;
using FootballPool;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoaHubCore.BaseClasses;
using SoaHubCore.Interfaces;

namespace HcpcsCodesTests.IntegrationTests
{
    [TestClass]
    public class CommunicatorIntegrationTests
    {
        [TestMethod]
        public void Communicator_Send_GetFirstCity()
        {
            Transaction request = new Transaction();
            ICommunicator<FootballPoolMessage> communicator = new Communicator(request);
            TransactionBase<FootballPoolMessage> response = communicator.Send();
            Assert.IsTrue(response.ResponseObject.Cities[0].Equals("Charkov"));
        }

        [TestMethod]
        public void Communicator_Send_GetLastGroupGameDate()
        {
            Transaction request = new Transaction();
            ICommunicator<FootballPoolMessage> communicator = new Communicator(request);
            TransactionBase<FootballPoolMessage> response = communicator.Send();
            Assert.IsTrue(response.ResponseObject.LastGroupPlayed.Year == 2012);
        }

        [TestMethod]
        public void Communicator_Send_GetGameInformation()
        {
            Transaction request = new Transaction();
            ICommunicator<FootballPoolMessage> communicator = new Communicator(request);
            TransactionBase<FootballPoolMessage> response = communicator.Send();
            Assert.IsTrue(response.ResponseObject.GameInfo.Contains("58145"));
        }
    }
}
