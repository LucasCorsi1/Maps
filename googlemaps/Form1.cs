using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace googlemaps
{
    public partial class Form1 : Form
    {
        private double alt, lng;
        private GMapOverlay overlay = new GMapOverlay("Marcador");
        private double[,] Graph;
        private Connections MakerPoint = new Connections();
        private List<PointLatLng> pointLatLngs = new List<PointLatLng>();
        private List<Connections> GetConnections = new List<Connections>();
        private TSP travellingSalesProblem = new TSP();
        Route route;


        public Form1()  // configs iniciais
        {
            InitializeComponent();
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyA85W4s3A3xP0vCc_5L-ZIQ8gW7VUlCi8Y"; // KEY  **não compartilhar por favor
            Map.MapProvider = GMapProviders.GoogleMap;
            Map.DragButton = MouseButtons.Left;
            Map.SetPositionByKeywords("Curitiba,Parana, Brazil");
            Map.MinZoom = 3;
            Map.MaxZoom = 15;
            Map.Zoom = 12;

        }

        private void btnCarregar_Click(object sender, EventArgs e) // carrega lat e long preenchido.
        {
            alt = Convert.ToDouble(textBoxLatitude.Text);
            lng = Convert.ToDouble(textBoxLongitude.Text);
            Map.Position = new PointLatLng(alt, lng);
            Map.Zoom = 15;
        }

        private void buttonmaker_Click(object sender, EventArgs e) // marca pelo botão
        {
            pointLatLngs.Add(new PointLatLng(alt, lng));
            PointLatLng point = new PointLatLng(alt, lng);
            loadMap(point);
            AddMaker(point);
            RefreshMap();

        }

        private void buttonroute_Click(object sender, EventArgs e)
        {
            GraphGenerator();
            double cust = 0;
            foreach (Connections con in GetConnections)
            {
                con.Visited = false;
            }
            GetConnections[pointLatLngs.Count - 1].Visited = true;
            route =  travellingSalesProblem.Solve(Graph, GetConnections);
            GMapOverlay routes = new GMapOverlay("Routes");

            for (int i = 0; i < route.Routes.Count; i++)
            {
                if (i + 1 < route.Routes.Count)
                {
                    MapRoute mapRoute = GoogleMapProvider.Instance.GetRoute(route.Routes[i].Point, route.Routes[i + 1].Point, false, false, 12);
                    GMapRoute gMapRoute = new GMapRoute(mapRoute.Points, "My Route");
                    routes.Routes.Add(gMapRoute);
                    Map.Overlays.Add(routes);
                    cust += gMapRoute.Distance;
                }
            }
            RefreshMap();

            labelKm.Text += cust.ToString("N2"); 
        }

        private void GraphGenerator() // gerar matriz de custo
        {
            Graph = new double[pointLatLngs.Count, pointLatLngs.Count];
            for (int i = 0; i < Graph.GetLength(0); i++)
            {
                for (int j = 0; j < Graph.GetLength(1); j++)
                {
                    Graph[i, j] = GoogleMapProvider.Instance.GetRoute(pointLatLngs[i], pointLatLngs[j], false, false, 12).Distance;/// gera a matriz com valores     
                }
            }

        }

        private void buttonclean_Click(object sender, EventArgs e) // limpa todos os dados do mapa
        {
            if (Map.Overlays.Count > 0)
            {
                route.Routes.Clear();
                Map.Overlays.Remove(overlay);
                Map.Overlays.RemoveAt(0);
                Map.Refresh();
                labelKm.Text = "Km";
                overlay.Markers.RemoveAt(0);
                RefreshMap();
            }
        }
        private void RefreshMap()  // atualiza informação do mapa
        {
            Map.Zoom--;
            Map.Zoom++;
        }
        private void Map_MouseClick(object sender, MouseEventArgs e)      // marca o ponto  com o botão direito do mouse 
        {

            if (e.Button == MouseButtons.Right)
            {
                if (pointLatLngs.Count < 6)
                {
                    PointLatLng Point = Map.FromLocalToLatLng(e.X, e.Y);
                    alt = Point.Lat;
                    lng = Point.Lng;
                    textBoxLatitude.Text = alt.ToString();
                    textBoxLongitude.Text = lng.ToString();
                    AddMaker(Point); // adiciona marcador ao mapa
                    pointLatLngs.Add(Point);  // adiciona pontos a lista
                    RefreshMap();
                }
                else
                {
                    MessageBox.Show("Máximo de 6 pontos");
                }
            }
        }

        private void loadMap(PointLatLng point) // recarrega posição
        {
            Map.Position = point;
        }
        private void AddMaker(PointLatLng pointLatLng, GMarkerGoogleType gMarker = GMarkerGoogleType.arrow) // adiciona o marcador e mostra informação quando passado mouse por cima do ponto marcado
        {
            GMarkerGoogle Marker = new GMarkerGoogle(pointLatLng, gMarker)
            {
                ToolTipText = $"Lat: {Map.Position.Lat} + Long: {Map.Position.Lng}"
            };
            MakerPoint.SetId(pointLatLngs.Count);
            MakerPoint.Point = pointLatLng;
            MakerPoint.Visited = false;
            GetConnections.Add(MakerPoint);
            overlay.Markers.Add(Marker);
            Map.Overlays.Add(overlay);
            RefreshMap();
        }

    }

}






