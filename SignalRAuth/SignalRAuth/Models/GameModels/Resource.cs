using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAuth.Models.GameModels
{
    class Resource : Card
    {
        public Res TheResource { get; set; }
        public int Quantity { get; set; }

        public Resource(Res r, int q)
        {
            TheResource = r;
            Quantity = q;
        }
    }
}
