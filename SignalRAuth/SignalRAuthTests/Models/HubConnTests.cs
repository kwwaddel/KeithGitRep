using Microsoft.VisualStudio.TestTools.UnitTesting;
using SignalRAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAuth.Models.Tests
{
    [TestClass()]
    public class HubConnTests
    {
        [TestMethod()]
        public void OnConnectedTest()
        {
            Assert.AreEqual(1, HubConn.Connections.Count);
        }
    }
}