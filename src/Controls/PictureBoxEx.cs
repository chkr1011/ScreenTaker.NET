using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Screentaker
{
	/// <summary>
	/// Die PictureBoxEx ist eine PictureBox die zudem Scrollbars
    /// sowie ein Zoom-Funktion bietet
	/// </summary>
	public class PictureBoxEx : System.Windows.Forms.UserControl
	{
        #region Designer generated code
        
        private PictureBox pBoxCurrentImage;
        private Panel OuterPanel;
        private Container components = null;

        private void InitializeComponent()
        {
            this.pBoxCurrentImage = new System.Windows.Forms.PictureBox();
            this.OuterPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxCurrentImage)).BeginInit();
            this.OuterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBoxCurrentImage
            // 
            this.pBoxCurrentImage.BackColor = System.Drawing.SystemColors.Control;
            this.pBoxCurrentImage.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pBoxCurrentImage.Location = new System.Drawing.Point(0, 0);
            this.pBoxCurrentImage.Name = "pBoxCurrentImage";
            this.pBoxCurrentImage.Size = new System.Drawing.Size(89, 78);
            this.pBoxCurrentImage.TabIndex = 3;
            this.pBoxCurrentImage.TabStop = false;
            // 
            // OuterPanel
            // 
            this.OuterPanel.AutoScroll = true;
            this.OuterPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.OuterPanel.Controls.Add(this.pBoxCurrentImage);
            this.OuterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OuterPanel.Location = new System.Drawing.Point(0, 0);
            this.OuterPanel.Name = "OuterPanel";
            this.OuterPanel.Size = new System.Drawing.Size(137, 121);
            this.OuterPanel.TabIndex = 4;
            // 
            // PictureBoxEx
            // 
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.OuterPanel);
            this.DoubleBuffered = true;
            this.Name = "PictureBoxEx";
            this.Size = new System.Drawing.Size(137, 121);
            this.Resize += new System.EventHandler(this.PictureBoxEx_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxCurrentImage)).EndInit();
            this.OuterPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        
        #endregion

		#region Internals

        private Image _SourceImage = null;
        //Das Original-Image wird NIE manipuliert!
        private Image _OriginalImage = null;

        private int _CurrentZoomLevel = 0;
        private Graphics _CurrentGraphics = null;

        private EditModes _CurrentMode = EditModes.None;

        private Point _StartPosition = Point.Empty;
        private Point _EndPosition = Point.Empty;

        private bool _ImageWasChanged = false;
       
        public enum EditModes
        {
            None,
            Zooming,
            LineM,
            Line,
            StringInsert,
            Brush,
            ColorPicker,
            RectangleTool
        }

        #endregion

        public delegate void Image_MouseMoveEventHandler(object sender, MouseEventArgs e);
        public event Image_MouseMoveEventHandler Image_MouseMove;

        public delegate void Image_MouseClickEventHandler(object sender, MouseEventArgs e);
        public event Image_MouseClickEventHandler Image_MouseClick;

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
		public PictureBoxEx()
		{
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            //Events abgeifen
            pBoxCurrentImage.MouseMove += new MouseEventHandler(pBoxCurrentImage_MouseMove);
            pBoxCurrentImage.MouseDown += new MouseEventHandler(pBoxCurrentImage_MouseDown);
            pBoxCurrentImage.MouseUp += new MouseEventHandler(pBoxCurrentImage_MouseUp);
            pBoxCurrentImage.MouseClick += new MouseEventHandler(pBoxCurrentImage_MouseClick);

            SetMode(EditModes.None);
		}

        void pBoxCurrentImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (Image_MouseClick != null)
            { Image_MouseClick(this, e); }
        }

        #endregion

		#region Properties

        /// <summary>
        /// Setzt die Hintergrundfarbe aller Controls
        /// </summary>
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                pBoxCurrentImage.BackColor = value;
                OuterPanel.BackColor = value;

                base.BackColor = value;
            }
        }

        /// <summary>
        /// Liefert die Position des Cursors innerhalb der Picturebox
        /// </summary>
        public Point CursorPosition
        {
            get
            {
                return pBoxCurrentImage.PointToClient(Cursor.Position);
            }
        }

        /// <summary>
        /// Der aktuelle Bearbeitungsmodus
        /// </summary>
        public EditModes EditMode
        {
            get
            {
                return _CurrentMode;
            }
        }

        /// <summary>
        /// Das Image, welches mit dieser Picturebox angezeigt werden soll
        /// </summary>
        public Image Image
        {
            set
            {
                //Anzeigen des Images
                if (value != null)
                {
                    //Falls bisher kein Originalimage gesetzt wurde wird dies
                    //jetzt getan
                    if (_OriginalImage == null) { _OriginalImage = (Image)value.Clone(); } 

                    //Zuweisen des Images an das Control. Danach wird die Größe
                    //des PictureBox-Controls angepasst
                    pBoxCurrentImage.Image = value;
                    pBoxCurrentImage.Size = value.Size;
                    
                    //Neue Graphics-Ebene anlegen
                    _CurrentGraphics = Graphics.FromImage(pBoxCurrentImage.Image);
                    
                    //Quellimage für Manipulationen setzen
                    _SourceImage = (Image)value.Clone();

                    PictureBoxEx_Resize(null, null);
                }
            }

            get
            {
                return pBoxCurrentImage.Image;
            }
        }

        /// <summary>
        /// Liefert das Control in dem das Bild angezeigt wird
        /// </summary>
        [Browsable(true)]
        public PictureBox InnerPictureBox
        {
            get
            {
                return pBoxCurrentImage;
            }

            set
            {
                pBoxCurrentImage = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Panel InnerPanel
        {
            get
            {
                return OuterPanel;
            }

            set
            {
                OuterPanel = value;
            }
        }

        /// <summary>
        /// Liefert zurück ob das Image momentan gezoomt wird
        /// </summary>
        [Browsable(false)]
        public bool IsZoomed
        {
            get
            {
                if (_CurrentZoomLevel == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Liefert zurück ob das Bild bearbeitet wurde
        /// </summary>
        public bool ImageWasChanged
        {
            get
            {
                return _ImageWasChanged;
            }
        }

		#endregion

        #region Private Methods

        /// <summary>
        /// Panel-Resize: Bei einer Größenänderung des Parents wird folgender
        /// Code ausgeführt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OuterPanel_Resize(object sender, EventArgs e)
        {
            if(pBoxCurrentImage.Image != null)
            {
                pBoxCurrentImage.Size = pBoxCurrentImage.Image.Size;

                if ((pBoxCurrentImage.Width >= OuterPanel.Width) ||
                    (pBoxCurrentImage.Height >= OuterPanel.Height))
                {
                    //Falls das Image größer ist wird es oben links in 
                    //der Ecke angezeigt
                    pBoxCurrentImage.Location = new Point(0, 0);
                    
                }
                else
                {
                    //Falls das Image kleiner oder gleich groß ist wird es in der Mitte
                    //des OuterPanel angezeigt
                    pBoxCurrentImage.Left = (this.Width / 2) - (pBoxCurrentImage.Width / 2);
                    pBoxCurrentImage.Top = (this.Height / 2) - (pBoxCurrentImage.Height / 2);
                }
            }


            //if (pBoxCurrentImage.Image != null)
            //{
            //    //Falls momentan gezoomt wird, wird das Image nicht
            //    //zentriert
            //    if (_CurrentZoomLevel != 0)
            //    { return; }

            //    if ((pBoxCurrentImage.Height > OuterPanel.Height) || (pBoxCurrentImage.Width > OuterPanel.Width))
            //    {
            //        //pBoxCurrentImage.Size     = pBoxCurrentImage.Image.Size;
            //        pBoxCurrentImage.Location = new Point(0, 0);
            //    }
            //    else
            //    {
            //        //Das Image zentrieren
            //        CenterImage();
            //    }

            //    pBoxCurrentImage.Visible = true;
            //}
            //else
            //{
            //    //Ausblenden des Cotrols falls kein Image angezeigt werden kann
            //    pBoxCurrentImage.Visible = false;
            //}
        }

        /// <summary>
        /// Legt das Graphics-Element neu an. Dabei gehen alle Änderungen verloren
        /// </summary>
        private void ResetGraphics()
        {
            pBoxCurrentImage.Image = (Image)_SourceImage.Clone();
            _CurrentGraphics = Graphics.FromImage(pBoxCurrentImage.Image); 
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Setzt das Imagegröße auf die Größe des InnerPanels und setzt den PictureBox-SizeMode auf Stretch
        /// </summary>
        public void FitToScreen()
        {
            pBoxCurrentImage.Size =  OuterPanel.Size;
            Image = new Bitmap(Image, OuterPanel.Size);
            pBoxCurrentImage.Location = new Point(0, 0);
        }

        /// <summary>
        /// Sett die Größe der ImageBox auf die Größe des Images und richtet den Screenshot neu aus
        /// </summary>
        public void FitToImage()
        {
            Image = (Image)_OriginalImage.Clone();
            PictureBoxEx_Resize(null, null);
        }

        /// <summary>
        /// Aktualisert das aktuelle Image mit dem angezeigten. Wenn die Größe
        /// sich unterscheidet wird es neu positioniert
        /// </summary>
        /// <param name="Source"></param>
        public void UpdateImage(Image Source)
        {
            if (Image == null)
            {
                Image = Source;
                return;
            }

            if (Source.Size == _SourceImage.Size)
            {
                _SourceImage = Source;
                pBoxCurrentImage.Image = Source;
            }
            else
            {
                Image = Source;
            }
        }

        /// <summary>
        /// Liefert Farbe des Pixels an der Position X-Y
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public Color GetColor(int _CurrentX, int _CurrentY)
        {
            Bitmap _Bitmap = (Bitmap)pBoxCurrentImage.Image;
            Color _ReturnValue = Color.Empty;

            try
            {
                if ((_CurrentX > 0) && (_CurrentX < pBoxCurrentImage.Image.Width))
                {
                    if ((_CurrentY > 0) && (_CurrentY < pBoxCurrentImage.Image.Height))
                    {
                        _ReturnValue = _Bitmap.GetPixel(_CurrentX, _CurrentY);
                    }
                }
            }
            catch { }

            return _ReturnValue;
        }

        /// <summary>
        /// Liefert die aktuelle Farbe zurück
        /// </summary>
        /// <returns></returns>
        public Color GetCurrentColor()
        {
            return GetColor(CursorPosition.X, CursorPosition.Y);
        }

        /// <summary>
        /// Stellt das Ausgangsbild wieder her
        /// </summary>
        public void RestoreOriginalImage()
        {
            SetMode(EditModes.None);
            this.Image = (Image)_OriginalImage.Clone();
            SetOriginalSize();
        }

        /// <summary>
        /// Setzt den neuen Mode und passt die Oberfläche den neuen Gegebenheiten an
        /// </summary>
        /// <param name="NewMode"></param>
        public void SetMode(EditModes NewMode)
        {
            _CurrentMode        = NewMode;
            _ImageWasChanged    = false;

            _StartPosition      = Point.Empty;
            _EndPosition        = Point.Empty;

            #region Cursor setzen

            switch (NewMode)
            {
                case EditModes.Line: 
                    this.pBoxCurrentImage.Cursor = Cursors.Cross; break;
                case EditModes.None: 
                    this.pBoxCurrentImage.Cursor = Cursors.Arrow; break;
                case EditModes.StringInsert:
                    this.pBoxCurrentImage.Cursor = Cursors.Cross; break;
                case EditModes.ColorPicker:
                    this.pBoxCurrentImage.Cursor = Cursors.Cross; break;
                case EditModes.RectangleTool:
                    this.pBoxCurrentImage.Cursor = Cursors.Cross; break;
            }

            #endregion
        }

        /// <summary>
		/// Make the PictureBox dimensions larger to effect the Zoom.
		/// </summary>
		/// <remarks>Maximum 5 times bigger</remarks>
		public void ZoomIn() 
		{
            try
            {
                //Abbruch, damit es zu keinem Fehler kommt
                if (_CurrentZoomLevel == 10)
                {
                    return;
                }

                if (_CurrentZoomLevel == 0) { _CurrentZoomLevel = 2; }
                else { _CurrentZoomLevel++; }

                pBoxCurrentImage.Location = new Point(0, 0);
                 pBoxCurrentImage.Image = ScaleByPercent(_SourceImage, 125);
                pBoxCurrentImage.Size = pBoxCurrentImage.Image.Size;
            }
            catch
            {

            }
		}

        /// <summary>
        /// Imagegröße verändern
        /// </summary>
        /// <param name="imgPhoto"></param>
        /// <param name="Percent"></param>
        /// <returns></returns>
        private Image ScaleByPercent(Image Source, int Percent)
        {

            int sourceWidth = Source.Width;
            int sourceHeight = Source.Height;
            int sourceX = 0;
            int sourceY = 0;

            int destX = 0;
            int destY = 0;
            int destWidth = Source.Width +  (50 * _CurrentZoomLevel);
            int destHeight = Source.Height + (50 * _CurrentZoomLevel);

            Bitmap _Result = new Bitmap(destWidth, destHeight,
                                     System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            _Result.SetResolution(Source.HorizontalResolution,
                                    Source.VerticalResolution);

            Graphics _ResultGraphics = Graphics.FromImage(_Result);
            _ResultGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            _ResultGraphics.DrawImage(Source,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            _ResultGraphics.Dispose();
            return _Result;
        }

		/// <summary>
		/// Make the PictureBox dimensions smaller to effect the Zoom.
		/// </summary>
		/// <remarks>Minimum 5 times smaller</remarks>
		public void ZoomOut() 
		{
            try
            {
                //Abbruch, damit es zu keinem Fehler kommt
                if (_CurrentZoomLevel == -10)
                {
                    return;
                }

                if (_CurrentZoomLevel == 0) { _CurrentZoomLevel = -2; }
                else { _CurrentZoomLevel--; }

                pBoxCurrentImage.Location = new Point(0, 0);
                pBoxCurrentImage.Image = ScaleByPercent(_SourceImage, 75);
                pBoxCurrentImage.Size = pBoxCurrentImage.Image.Size;
            }
            catch
            {
                
            }
		}

        /// <summary>
        /// Setzt das Image auf die Orginalgröße und zentriert es
        /// </summary>
        public void SetOriginalSize()
        {
            pBoxCurrentImage.Image = _SourceImage;
            pBoxCurrentImage.Size   = pBoxCurrentImage.Image.Size;
            
            _CurrentZoomLevel       = 0;
        }

        /// <summary>
        /// Schreibt einen Text an eine beliebige Position im Bild
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="StringColor"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public void WriteString(string Value, Color StringColor, int X, int Y)
        {
            Graphics _CurrentGraphics = Graphics.FromImage(pBoxCurrentImage.Image);
            Font _CurrentFont = new Font("Tahoma", 12, FontStyle.Bold | FontStyle.Italic);

            
            _CurrentGraphics.DrawString(Value, _CurrentFont, Brushes.Red, X, Y);
            _CurrentGraphics.Save();
            pBoxCurrentImage.Refresh();
        }
    
        #endregion

        #region Mouse events

        /// <summary>
        /// Wenn die Maus bewegt wird...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pBoxCurrentImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (_CurrentMode == EditModes.None)
            { return; }

            //Event feuern welches über das oberste Control abgegriffen werden kann
            if (Image_MouseMove != null)
            { Image_MouseMove(this, e); }

            switch(_CurrentMode)
            {
                #region Mode: Line

                case EditModes.Line:
                    if (_StartPosition != Point.Empty)
                    {
                        ResetGraphics();
                        _CurrentGraphics.DrawLine(new Pen(Color.Red, 2), _StartPosition, e.Location);
                    }
          
                    break;

                #endregion

                #region Mode: StringInsert

                case EditModes.StringInsert:
                    ResetGraphics();
                    _CurrentGraphics.DrawString("Screentaker.NET", new Font("Tahoma", 14,
                        FontStyle.Bold | FontStyle.Italic),
                        Brushes.Red, e.Location);

                    break;

                #endregion

                #region Mode: Brush

                case EditModes.Brush:
                    ResetGraphics();

                    break;

                #endregion

                #region Mode: Rectangle Tool

                case EditModes.RectangleTool:
                    _EndPosition = e.Location;

                    if (_StartPosition == Point.Empty)
                    {
                        return;
                    }


                    int _RWidth = this._EndPosition.X - this._StartPosition.X;
                    int _RHeight = this._EndPosition.Y - this._StartPosition.Y;


                    //Neues Rechteck zusammenbauen
                    Rectangle _SelectedArea = new Rectangle(
                        _RWidth < 0 ? this._StartPosition.X + _RWidth : this._StartPosition.X,
                        _RHeight < 0 ? this._StartPosition.Y + _RHeight : this._StartPosition.Y,
                        _RWidth < 0 ? -_RWidth : _RWidth,
                        _RHeight < 0 ? -_RHeight : _RHeight
                    );

                    ResetGraphics();
                    _CurrentGraphics.DrawRectangle(new Pen(Color.Red, 2), _SelectedArea);
                    _CurrentGraphics.Save();

                    break;


                #endregion
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pBoxCurrentImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (_CurrentMode == EditModes.None) { return; }
            if (e.Button != MouseButtons.Left) { return; }

            switch (_CurrentMode)
            {
                #region Mode: Line

                case EditModes.Line:
                    if (_StartPosition == Point.Empty)
                    {
                        _SourceImage = pBoxCurrentImage.Image;
                        _StartPosition = e.Location;
                    }
                    else
                    {
                        _ImageWasChanged = true;
                        _StartPosition = Point.Empty;
                    }

                    break;

                #endregion

                #region Mode: StringInsert

                case EditModes.StringInsert:
                    _ImageWasChanged = true;
                    SetMode(EditModes.None);

                    break;


                #endregion

                #region Mode: Rectangle Tool

                case EditModes.RectangleTool:
                    if (_StartPosition == Point.Empty)
                    {
                        _SourceImage = pBoxCurrentImage.Image;
                        _StartPosition = e.Location;
                    }
                    else
                    {
                        _CurrentGraphics.Save();
                        _StartPosition = Point.Empty;
                        _ImageWasChanged = true;
                    }

                    break;

                #endregion
            }
        }

        /// <summary>
        /// Wenn die Maus losgelassen wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pBoxCurrentImage_MouseUp(object sender, MouseEventArgs e)
        {
            pBoxCurrentImage_MouseDown(sender, e);
        }
		
        #endregion

        #region Disposing

		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#endregion

        private void PictureBoxEx_Resize(object sender, EventArgs e)
        {
            OuterPanel.AutoScrollPosition = new Point(0,0);

            if (pBoxCurrentImage.Image != null)
            {
                if ((pBoxCurrentImage.Width >= OuterPanel.Width) ||
                    (pBoxCurrentImage.Height >= OuterPanel.Height))
                {
                    //Falls das Image größer ist wird es oben links in 
                    //der Ecke angezeigt
                    pBoxCurrentImage.Location = new Point(0, 0);

                }
                else
                {
                    //Falls das Image kleiner oder gleich groß ist wird es in der Mitte
                    //des OuterPanel angezeigt
                    pBoxCurrentImage.Left = (this.Width / 2) - (pBoxCurrentImage.Width / 2);
                    pBoxCurrentImage.Top = (this.Height / 2) - (pBoxCurrentImage.Height / 2);
                }
            }
        }
	}
}
