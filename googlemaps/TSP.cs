using System.Collections.Generic;

namespace googlemaps
{
    internal class TSP
    {

        public Route Solve(double[,] graph, List<Connections> points) // Caixeiro Viajante Resolver
        {
            double RouteCust = 0;
            Route shortestRoute = new Route(points[points.Count - 1]);
            while (shortestRoute.Routes.Count != points.Count  )
            {
                Connections neighbors = null;
                double custNeighbors = double.MaxValue;
                for (int i = 0; i < points.Count; i++)
                {
                    if (graph[shortestRoute.Current.GetId(), i] < custNeighbors && graph[shortestRoute.Current.GetId(), i] != 0 && points[i].Visited == false)
                    {
                        neighbors = points[i];
                        custNeighbors = graph[shortestRoute.Current.GetId(), i];
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
            RouteCust += graph[shortestRoute.Init.GetId(), shortestRoute.Current.GetId()];
            shortestRoute.Routes.Add(points[points.Count - 1]);
            shortestRoute.Cust = RouteCust;
            return shortestRoute;
        }
    }
}
