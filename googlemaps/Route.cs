using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace googlemaps
{
    class Route
    {
        private Connections  init;
        private Connections current;
        private List<Connections> routes = new List<Connections>();
        private double cust;

        public Route( Connections connections)
        {
            init = connections;
            current = connections;
            routes.Add(connections);
        }

        public double Cust { get => cust; set => cust = value; }
        internal Connections Init { get => init; set => init = value; }
        internal Connections Current { get => current; set => current = value; }
        internal List<Connections> Routes { get => routes; set => routes = value; }
    }
}
