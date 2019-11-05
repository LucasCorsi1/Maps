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
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyA85W4s3A3xP0vCc_5L-ZIQ8gW7VUlCi8Y"; // KEY  **não compartilhar por favor
            Map.MapProvider = GMapProviders.GoogleMap;
            Map.Zoom = 15;
            points = new List<PointLatLng>();


        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            if (numAltitude.Value != null & numLongitude.Value != null)
            {
                Map.DragButton = MouseButtons.Left;


                altitude = Convert.ToDouble(numAltitude.Value);
                longitude = Convert.ToDouble(numLongitude.Value);

                Map.Position = new PointLatLng(altitude, longitude);

                Map.MinZoom = 3;
                Map.MaxZoom = 15;
                Map.Zoom = 15;

            }
        }

        private void buttonmaker_Click(object sender, EventArgs e)
        {

            points.Add(new PointLatLng(altitude, longitude));

            PointLatLng point = new PointLatLng(altitude, longitude);
            GMarkerGoogle gMarker = new GMarkerGoogle(point, GMarkerGoogleType.blue_dot);

            overlay.Markers.Add(gMarker);

            Map.Overlays.Add(overlay);

        }

        private void buttonroute_Click(object sender, EventArgs e)
        {
            MapRoute route0 = GoogleMapProvider.Instance.GetRoute(points[0], points[1], false, false, 12);
            MapRoute route1 = GoogleMapProvider.Instance.GetRoute(points[1], points[2], false, false, 12);
            MapRoute route2 = GoogleMapProvider.Instance.GetRoute(points[2], points[3], false, false, 12);

            GMapRoute rt1 = new GMapRoute(route0.Points, "My Route1")
            {
                Stroke = new Pen(Color.Cyan , 5)
            };
            GMapRoute rt2 = new GMapRoute(route1.Points, "My Route2")
            {
                Stroke = new Pen(Color.Red , 5)
            };
            GMapRoute rt3 = new GMapRoute(route2.Points, "My Route3")
            {
                Stroke = new Pen(Color.Yellow,5)
            };

            GMapOverlay routes = new GMapOverlay("Routes");
            routes.Routes.Add(rt1);
            routes.Routes.Add(rt2);
            routes.Routes.Add(rt3);

            Map.Overlays.Add(routes);


        }



        private void buttonclean_Click(object sender, EventArgs e)
        {
            points.Clear();
            Map.Overlays.Remove(overlay);

        }
    }

}






