using System.Collections.Generic;

namespace googlemaps
{
    internal class TSP
    {

        public Route Solve(double[,] graph, List<Connections> points) // Caixeiro Viajante 
        {
            double RouteCust = 0;
            Route shortestRoute = new Route(points[0]);
            while (shortestRoute.Routes.Count != points.Count)
            {
                Connections neighbors = null;
                double custNeighbors = double.MaxValue;
                for (int i = 0; i < points.Count; i++)
                {
                    if (graph[shortestRoute.Current.Id, i] < custNeighbors 
                        && graph[shortestRoute.Current.Id, i] != 0 
                        && points[i].Visited == false)
                    {
                        neighbors = points[i];
                        custNeighbors = graph[shortestRoute.Current.Id, i];
                    }
                }
                if (neighbors != null)
                {
                    shortestRoute.Routes.Add(neighbors);
                    shortestRoute.Current = neighbors;
                    neighbors.Visited = true;
                    RouteCust += custNeighbors;
                }
            }
            RouteCust += graph[shortestRoute.Init.Id, shortestRoute.Current.Id];
            shortestRoute.Routes.Add(points[0]);
            shortestRoute.Cust = RouteCust;
            return shortestRoute;
        }
    }
}
