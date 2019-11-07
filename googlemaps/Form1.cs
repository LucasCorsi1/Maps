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
        private List<PointLatLng> points;
        private double altitude, longitude;
        private GMapOverlay overlay = new GMapOverlay("Marcador");


        public Form1()
        {
            InitializeComponent();
            points = new List<PointLatLng>();
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyA85W4s3A3xP0vCc_5L-ZIQ8gW7VUlCi8Y"; // KEY  **não compartilhar por favor
            Map.MapProvider = GMapProviders.GoogleMap;
            Map.DragButton = MouseButtons.Left;
            Map.SetPositionByKeywords("Curitiba,Parana, Brazil");
            Map.MinZoom = 3;
            Map.MaxZoom = 15;
            Map.Zoom = 12;

        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            altitude = Convert.ToDouble(textBoxLatitude.Text);
            longitude = Convert.ToDouble(textBoxLongitude.Text);
            Map.Position = new PointLatLng(altitude, longitude);
            Map.Zoom = 15;
        }

        private void buttonmaker_Click(object sender, EventArgs e)
        {
            points.Add(new PointLatLng(altitude, longitude));

            PointLatLng point = new PointLatLng(altitude, longitude);

            loadMap(point);
            AddMaker(point);
            RefreshMap();

        }

        private void buttonroute_Click(object sender, EventArgs e)
        {
            // marcar os pontos de rotas mouse direito ou botao


            MapRoute route0 = GoogleMapProvider.Instance.GetRoute(points[0], points[1], false, false, 12);
            MapRoute route1 = GoogleMapProvider.Instance.GetRoute(points[1], points[2], false, false, 12);
            MapRoute route2 = GoogleMapProvider.Instance.GetRoute(points[2], points[3], false, false, 12);

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

            GMapOverlay routes = new GMapOverlay("Routes");
            routes.Routes.Add(rt1);
            routes.Routes.Add(rt2);
            routes.Routes.Add(rt3);

            Map.Overlays.Add(routes);

            double total = Math.Round(route0.Distance + route1.Distance + route2.Distance, 3);

            labelKm.Text = "Distancia Total :  " + total.ToString() + " Km ";
            RefreshMap();
 
        }

        private void buttonclean_Click(object sender, EventArgs e)
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


        private void RefreshMap()
        {
            Map.Zoom--;
            Map.Zoom++;
        }


        // marca com o botão do mouse

        private void Map_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                PointLatLng Point = Map.FromLocalToLatLng(e.X, e.Y);
                altitude = Point.Lat;
                longitude = Point.Lng;

                textBoxLatitude.Text = altitude.ToString();
                textBoxLongitude.Text = longitude.ToString();

                AddMaker(Point);
                points.Add(Point);
                RefreshMap();

            }

        }


        private void loadMap(PointLatLng point)
        {
            Map.Position = point;
        }

        private void AddMaker(PointLatLng pointLatLng, GMarkerGoogleType gMarker = GMarkerGoogleType.arrow)
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






