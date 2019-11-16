using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace googlemaps
{
    class Connections
    {
        private int id;
        private PointLatLng point;
        private bool visited;

        public int GetId()
        {
            return id;
        }

        public void SetId(int value)
        {
            id = value;
        }

        public PointLatLng Point { get => point; set => point = value; }
        public bool Visited { get => visited; set => visited = value; }
    }
}
