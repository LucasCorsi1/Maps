namespace googlemaps
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCarregar = new System.Windows.Forms.Button();
            this.Map = new GMap.NET.WindowsForms.GMapControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonclean = new System.Windows.Forms.Button();
            this.buttonmaker = new System.Windows.Forms.Button();
            this.buttonroute = new System.Windows.Forms.Button();
            this.numAltitude = new System.Windows.Forms.NumericUpDown();
            this.numLongitude = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numAltitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLongitude)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCarregar
            // 
            this.btnCarregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCarregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarregar.Location = new System.Drawing.Point(826, 98);
            this.btnCarregar.Name = "btnCarregar";
            this.btnCarregar.Size = new System.Drawing.Size(112, 28);
            this.btnCarregar.TabIndex = 6;
            this.btnCarregar.Text = "Carregar";
            this.btnCarregar.UseVisualStyleBackColor = true;
            this.btnCarregar.Click += new System.EventHandler(this.btnCarregar_Click);
            // 
            // Map
            // 
            this.Map.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Map.Bearing = 0F;
            this.Map.CanDragMap = true;
            this.Map.EmptyTileColor = System.Drawing.Color.Navy;
            this.Map.GrayScaleMode = false;
            this.Map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.Map.LevelsKeepInMemmory = 5;
            this.Map.Location = new System.Drawing.Point(0, 0);
            this.Map.MarkersEnabled = true;
            this.Map.MaxZoom = 2;
            this.Map.MinZoom = 2;
            this.Map.MouseWheelZoomEnabled = true;
            this.Map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.Map.Name = "Map";
            this.Map.NegativeMode = false;
            this.Map.PolygonsEnabled = true;
            this.Map.RetryLoadTile = 0;
            this.Map.RoutesEnabled = true;
            this.Map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.Map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.Map.ShowTileGridLines = false;
            this.Map.Size = new System.Drawing.Size(820, 739);
            this.Map.TabIndex = 8;
            this.Map.Zoom = 0D;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(820, 739);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1011, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Altitude";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1011, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Longitude";
            // 
            // buttonclean
            // 
            this.buttonclean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonclean.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonclean.Location = new System.Drawing.Point(845, 166);
            this.buttonclean.Name = "buttonclean";
            this.buttonclean.Size = new System.Drawing.Size(201, 28);
            this.buttonclean.TabIndex = 11;
            this.buttonclean.Text = "Limpar Marcadores";
            this.buttonclean.UseVisualStyleBackColor = true;
            this.buttonclean.Click += new System.EventHandler(this.buttonclean_Click);
            // 
            // buttonmaker
            // 
            this.buttonmaker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonmaker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonmaker.Location = new System.Drawing.Point(944, 98);
            this.buttonmaker.Name = "buttonmaker";
            this.buttonmaker.Size = new System.Drawing.Size(112, 28);
            this.buttonmaker.TabIndex = 12;
            this.buttonmaker.Text = "Marcar";
            this.buttonmaker.UseVisualStyleBackColor = true;
            this.buttonmaker.Click += new System.EventHandler(this.buttonmaker_Click);
            // 
            // buttonroute
            // 
            this.buttonroute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonroute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonroute.Location = new System.Drawing.Point(826, 132);
            this.buttonroute.Name = "buttonroute";
            this.buttonroute.Size = new System.Drawing.Size(112, 28);
            this.buttonroute.TabIndex = 13;
            this.buttonroute.Text = "Rota";
            this.buttonroute.UseVisualStyleBackColor = true;
            this.buttonroute.Click += new System.EventHandler(this.buttonroute_Click);
            // 
            // numAltitude
            // 
            this.numAltitude.DecimalPlaces = 9;
            this.numAltitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAltitude.Location = new System.Drawing.Point(826, 24);
            this.numAltitude.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.numAltitude.Minimum = new decimal(new int[] {
            1241513983,
            370409800,
            542101,
            -2147483648});
            this.numAltitude.Name = "numAltitude";
            this.numAltitude.Size = new System.Drawing.Size(179, 26);
            this.numAltitude.TabIndex = 15;
            this.numAltitude.Value = new decimal(new int[] {
            25442026,
            0,
            0,
            -2147090432});
            // 
            // numLongitude
            // 
            this.numLongitude.DecimalPlaces = 9;
            this.numLongitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numLongitude.Location = new System.Drawing.Point(826, 53);
            this.numLongitude.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.numLongitude.Minimum = new decimal(new int[] {
            1241513983,
            370409800,
            542101,
            -2147483648});
            this.numLongitude.Name = "numLongitude";
            this.numLongitude.Size = new System.Drawing.Size(179, 26);
            this.numLongitude.TabIndex = 16;
            this.numLongitude.Value = new decimal(new int[] {
            49238707,
            0,
            0,
            -2147090432});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 739);
            this.Controls.Add(this.numLongitude);
            this.Controls.Add(this.numAltitude);
            this.Controls.Add(this.buttonroute);
            this.Controls.Add(this.buttonmaker);
            this.Controls.Add(this.buttonclean);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Map);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.btnCarregar);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numAltitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLongitude)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCarregar;
        private GMap.NET.WindowsForms.GMapControl Map;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonclean;
        private System.Windows.Forms.Button buttonmaker;
        private System.Windows.Forms.Button buttonroute;
        private System.Windows.Forms.NumericUpDown numAltitude;
        private System.Windows.Forms.NumericUpDown numLongitude;
    }
}

