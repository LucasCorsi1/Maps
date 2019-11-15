using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace googlemaps
{
    public partial class Form1 : Form
    {
        private Dictionary<int, PointLatLng> points;
        private double altitude, longitude;
        private GMapOverlay overlay = new GMapOverlay("Marcador");
        private double[,] grafo;
        private int ID = 0;
        private List<PointLatLng> listacaminhomenor = new List<PointLatLng>();



        public Form1()  // configs iniciais
        {
            InitializeComponent();
            points = new Dictionary<int, PointLatLng>();
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
            altitude = Convert.ToDouble(textBoxLatitude.Text);
            longitude = Convert.ToDouble(textBoxLongitude.Text);
            Map.Position = new PointLatLng(altitude, longitude);
            Map.Zoom = 15;
        }

        private void buttonmaker_Click(object sender, EventArgs e) // marca pelo botão
        {

            points.Add(ID++, new PointLatLng(altitude, longitude));

            PointLatLng point = new PointLatLng(altitude, longitude);

            loadMap(point);
            AddMaker(point);
            RefreshMap();

        }

        private void buttonroute_Click(object sender, EventArgs e)
        {
            menorcaminho();

            MapRoute route0 = GoogleMapProvider.Instance.GetRoute(listacaminhomenor[0], points[1], false, false, 12);
            MapRoute route1 = GoogleMapProvider.Instance.GetRoute(listacaminhomenor[1], points[2], false, false, 12);
            MapRoute route2 = GoogleMapProvider.Instance.GetRoute(listacaminhomenor[2], points[3], false, false, 12);
            MapRoute route3 = GoogleMapProvider.Instance.GetRoute(listacaminhomenor[3], points[4], false, false, 12);
            MapRoute route4 = GoogleMapProvider.Instance.GetRoute(listacaminhomenor[4], points[5], false, false, 12);
            MapRoute route5 = GoogleMapProvider.Instance.GetRoute(listacaminhomenor[5], points[0], false, false, 12);


            GMapRoute rt1 = new GMapRoute(route0.Points, "My Route1")
            {
                Stroke = new Pen(Color.Cyan, 5)
            };
            GMapRoute rt2 = new GMapRoute(route1.Points, "My Route2")
            {
                Stroke = new Pen(Color.Red, 5)
            };
            GMapRoute rt3 = new GMapRoute(route2.Points, "My Route3")
            {
                Stroke = new Pen(Color.Yellow, 5)
            };
            GMapRoute rt4 = new GMapRoute(route3.Points, "My Route4")
            {
                Stroke = new Pen(Color.Aqua, 5)
            };
            GMapRoute rt5 = new GMapRoute(route4.Points, "My Route5")
            {
                Stroke = new Pen(Color.Azure, 5)
            };
            GMapRoute rt6 = new GMapRoute(route5.Points, "My Route6")
            {
                Stroke = new Pen(Color.Bisque, 5)
            };

            GMapOverlay routes = new GMapOverlay("Routes");
            routes.Routes.Add(rt1);
            routes.Routes.Add(rt2);
            routes.Routes.Add(rt3);
            routes.Routes.Add(rt4);
            routes.Routes.Add(rt5);
            routes.Routes.Add(rt6);

            Map.Overlays.Add(routes);

            RefreshMap();
        }


        private List<PointLatLng> menorcaminho() // gerar algorimo de menor caminho
        {
            int count = 0;

            int menor = int.MaxValue;
            grafo = new double[points.Count, points.Count];


            for (int i = 0; i < grafo.GetLength(0); i++)
            {
                for (int j = 0; j < grafo.GetLength(1); j++)
                {
                    MapRoute route = GoogleMapProvider.Instance.GetRoute(points[i], points[j], false, false, 12);
                    grafo[i, j] = Math.Round(route.Distance, 2);

                    richTextBox1.AppendText(grafo[i, j].ToString() + "  ");
                    count++;
                    if (count == 6)
                    {
                        count = 0;
                        richTextBox1.AppendText(Environment.NewLine);
                    }
                }
            }

            return listacaminhomenor;
        }


        private void buttonclean_Click(object sender, EventArgs e) // limpa todos os dados do mapa
        {
            if (Map.Overlays.Count > 0)
            {
                points.Clear();
                Map.Overlays.Remove(overlay);
                Map.Overlays.RemoveAt(0);
                Map.Refresh();
                labelKm.Text = "Km";
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
            if (points.Count < 6)
            {
                if (e.Button == MouseButtons.Right)
                {

                    PointLatLng Point = Map.FromLocalToLatLng(e.X, e.Y);
                    altitude = Point.Lat;
                    longitude = Point.Lng;

                    textBoxLatitude.Text = altitude.ToString();
                    textBoxLongitude.Text = longitude.ToString();

                    AddMaker(Point); // adiciona marcador ao mapa
                    points.Add(ID++, Point);  // adiciona pontos a lista
                    RefreshMap();

                }
            }
            else
            {
                MessageBox.Show("Máximo de 6 pontos");
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
                ToolTipText = $"Latitude: {Map.Position.Lat} + Longitude: {Map.Position.Lng}"
            };

            overlay.Markers.Add(Marker);

            Map.Overlays.Add(overlay);
            RefreshMap();

        }

    }

}






