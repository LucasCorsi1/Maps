using GMap.NET;
using GMap.NET.MapProviders;
using System;
using System.Windows.Forms;

namespace googlemaps
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Map.MapProvider = GMapProviders.GoogleMap;
            Map.Zoom = 10;

        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            Map.DragButton = MouseButtons.Left;
       

            double altitude = Convert.ToDouble(textBoxAltitude.Text);
            double longitude = Convert.ToDouble(textBoxLongitude.Text);

            Map.Position = new PointLatLng(altitude, longitude);

            Map.MinZoom = 3;
            Map.MaxZoom = 15;
            Map.Zoom = 10;


        }
    }
}
