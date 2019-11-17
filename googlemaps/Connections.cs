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

        public Connections(int id, PointLatLng point, bool visited)
        {
            this.id = id;
            this.point = point;
            this.visited = visited;
        }

        public int Id { get => id; set => id = value; }
        public PointLatLng Point { get => point; set => point = value; }
        public bool Visited { get => visited; set => visited = value; }
    }
}
