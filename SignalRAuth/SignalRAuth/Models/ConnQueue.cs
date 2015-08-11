using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SignalRAuth.Models
{
    public class ConnQueue
    {
        public ConcurrentQueue<String> Connections;

        public ConnQueue()
        {
            Connections = new ConcurrentQueue<String>();
        }

        public List<String> GetPlayers()
        {
            Debug.WriteLine(Connections.Count);
            return new List<String>(Connections);
        }
    }
}