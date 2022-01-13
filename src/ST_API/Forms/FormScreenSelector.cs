using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Screentaker.Forms
{
    public partial class FormScreenSelector : Form
    {
        #region Internals

        private double _Transparency    = .5;
        private bool _IsGrabbing        = false;
        private bool _ShowSize          = false;
        private Point _StartPosition    = new Point();
        private Point _EndPosition      = new Point();
        private Rectangle _SelectedArea = Rectangle.Empty;
        private Pen _GrabbingPen        = new Pen(Color.Black, 1);
        private Form _CurrentGrabParent = null;

        #endregion

        #region Contructor

        public FormScreenSelector()
        {
            InitializeComponent();

            //Diverse Optimierungen vornehmen
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Falls der linke Button der Maus gedrückt wird, wird as Auswahlfenster
        /// angezeigt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormScreenSelector_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _StartPosition  = new Point(e.X, e.Y);
                _IsGrabbing     = true;
            }
        }

        /// <summary>
        /// Falls die linke Maustaste wieder hochgelassen wird, werden die Koordinaten
        /// gepseichert und das Fenster wird geschlossen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormScreenSelector_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _IsGrabbing = false;
                _EndPosition = new Point(e.X, e.Y);

                this.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// Falls eine Taste auf dem Form gedrückt wurde
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormScreenSelector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
            }

            if (e.KeyCode == Keys.Tab)
            {
                if (_CurrentGrabParent != null)
                {
                    if (_CurrentGrabParent.Visible == false)
                    {
                        _CurrentGrabParent.Visible = true;
                    }
                    else
                    {
                        _CurrentGrabParent.Visible = false;
                    }
                }
            }
        }

        /// <summary>
        /// Wenn die Maus bewegt wird, und breits der Grabbing-Modus aktiv ist wird
        /// nun das Reckteck an den bestimmten Koordinaten gezeichnet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormScreenSelector_MouseMove(object sender, MouseEventArgs e)
        {
            if (_IsGrabbing)
            {
                #region Größe anzeigen

                if (_ShowSize)
                {
                    labelSelectedSize.Visible = true;
                    labelSelectedSize.Text = _SelectedArea.Height.ToString() + "x" + _SelectedArea.Width.ToString();

                    labelSelectedSize.Left = _StartPosition.X;
                    labelSelectedSize.Top = _StartPosition.Y - labelSelectedSize.Height - 1;

                    labelSelectedSize.Refresh();
                }

                #endregion

                this._EndPosition = new Point(e.X, e.Y);
                this.Invalidate();
             }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Öffnet das Fenster zum grabben
        /// </summary>
        /// <param name="GrabParent"></param>
        /// <returns>Öffnet das Auswahlfenster und gibt zurück ob wirklich gegrabbt wurde</returns>
        public DialogResult Grab(Form GrabParent)
        {
            //Einstellungen übernehemen
            this.Opacity        = _Transparency;
            this._CurrentGrabParent = GrabParent;

            DialogResult _Result = this.ShowDialog(GrabParent);

            if (GrabParent != null)
            {
                GrabParent.Visible = true;
            }

            return _Result;
        }

        /// <summary>
        /// Grabbt ein einzelnes Fenster
        /// </summary>
        /// <param name="GrabParent"></param>
        /// <returns></returns>
        public DialogResult GrabForm(Form GrabParent)
        {
            if (GrabParent != null)
            {
                GrabParent.Activated += new EventHandler(GrabParent_Activated);
                GrabParent.Deactivate += new EventHandler(GrabParent_Deactivate);
            }

            //Neue Einstellungen setzen
            this.Opacity        = _Transparency;
            this.Location       = GrabParent.Location;
            this.Size           = GrabParent.Size;

            return ShowDialog(GrabParent);
        }

        void GrabParent_Deactivate(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        void GrabParent_Activated(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Erweitern die Dispose-Methode um diverse Objekte
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            _CurrentGrabParent  = null;
            _GrabbingPen        = null;

            base.Dispose(disposing);
        }

        /// <summary>
        /// Wenn der entsprechende Modus aktiviert ist wird hier das Rechteck gezeichnet
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (_IsGrabbing)
            {      
                int _RWidth     = this._EndPosition.X - this._StartPosition.X;
                int _RHeight    = this._EndPosition.Y - this._StartPosition.Y;
                
                //Neues Rechteck zusammenbauen
                _SelectedArea = new Rectangle(
                    _RWidth < 0 ? this._StartPosition.X + _RWidth : this._StartPosition.X,
                    _RHeight < 0 ? this._StartPosition.Y + _RHeight : this._StartPosition.Y,
                    _RWidth < 0 ? -_RWidth : _RWidth,
                    _RHeight < 0 ? -_RHeight : _RHeight
                );
                e.Graphics.DrawRectangle(_GrabbingPen, _SelectedArea);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Definiert ob die Größe angezeigt werden soll
        /// </summary>
        public bool ShowSize
        {
            get
            {
                return _ShowSize;
            }

            set
            {
                _ShowSize = value;
            }
        }

        /// <summary>
        /// Setzt den Transparenzgrad dieses Fensters
        /// </summary>
        public double Transparency
        {
            get
            {
                return _Transparency;
            }

            set
            {
                _Transparency = value;
            }
        }

        /// <summary>
        /// Liefert ein Viereck mit allem Koordinaten des selektierten Areals zurück
        /// </summary>
        public Rectangle SelectedArea
        {
            get
            {
                return _SelectedArea;
            }
        }

        /// <summary>
        /// Definiert die Farbe und Dicke der Linie die als Auswahlvisualisierung dient
        /// </summary>
        public Pen GrabbingPen
        {
            get
            {
                return _GrabbingPen;
            }

            set
            {
                _GrabbingPen = value;
            }
        }

        #endregion

        /// <summary>
        /// Beim schließen dieses Fensters Resourcen freigeben
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormScreenSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Das Fenster wird beim laden an eine definierte Stelle gesetzt und an Hand der Größe
        /// aller vorhandenen Monitore vergrößtert.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormScreenSelector_Load(object sender, EventArgs e)
        {
            ImageGrabbing _ImageGrabber = new ImageGrabbing();

            this.Location = new Point(0,0);
            this.Height = _ImageGrabber.FullScreen.Height;
            this.Width = _ImageGrabber.FullScreen.Width;
        }
    }
}