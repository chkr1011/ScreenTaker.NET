using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Screentaker
{
    public class STTabPage : TabPage
    {
        #region Internals

        private PictureBoxEx _InternalPictureBoxEx = new PictureBoxEx();
        private ContextMenu _CurrentContextMenu = new ContextMenu();

        private MenuItem _StretchViewSwitch = new MenuItem();
        private MenuItem _CloseTab = new MenuItem();

        #endregion

        public STTabPage()
        {
            _InternalPictureBoxEx.Location = new System.Drawing.Point(0,0);
            _InternalPictureBoxEx.Size = this.Size;
            _InternalPictureBoxEx.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _InternalPictureBoxEx.Dock = DockStyle.Fill;
            _InternalPictureBoxEx.InnerPictureBox.MouseClick += new MouseEventHandler(InnerControls_MouseClick);
            _InternalPictureBoxEx.InnerPanel.MouseClick += new MouseEventHandler(InnerControls_MouseClick);


            this.Controls.Add(_InternalPictureBoxEx);

            //MenuItems für das Kontextmenü anlegen und hinzufügen
            _StretchViewSwitch.Name = "StretchViewSwitch";
            _StretchViewSwitch.Text = "Ansicht an Fenster anpassen";
            _StretchViewSwitch.Click += new EventHandler(_StretchViewSwitch_Click);

            _CloseTab.Name = "CloseTab";
            _CloseTab.Text = "Schließen";
            _CloseTab.Click += new EventHandler(_CloseTab_Click);
            
            //Items hinzufügen
            _CurrentContextMenu.MenuItems.Add(_StretchViewSwitch);
            _CurrentContextMenu.MenuItems.Add(_CloseTab);
        }

        /// <summary>
        /// Schließt den Tab, bzw. löst das entsprechende Event aus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _CloseTab_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        /// <summary>
        /// Kontextmenü anzeigen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void InnerControls_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            { _CurrentContextMenu.Show(_InternalPictureBoxEx, PointToClient(MousePosition)); }
        }

        /// <summary>
        /// Ansicht an Größe anpassen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _StretchViewSwitch_Click(object sender, EventArgs e)
        {
            if (!_StretchViewSwitch.Checked)
            { _InternalPictureBoxEx.FitToScreen(); }
            else
            { _InternalPictureBoxEx.FitToImage(); }

            //Wechseln der Ansicht
            _StretchViewSwitch.Checked = !_StretchViewSwitch.Checked;
        }
        
        #region Properties

        /// <summary>
        /// Hintergrundfarbe dieses Controls
        /// </summary>
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                _InternalPictureBoxEx.BackColor = value;
            }
        }     

        /// <summary>
        /// Der anzuzeigende Screenshot
        /// </summary>
        public Image ScreenImage
        {
            set
            {
                _InternalPictureBoxEx.Image = value;
            }

            get
            {
                return _InternalPictureBoxEx.Image;
            }
        }

        /// <summary>
        /// Liefert den internen Screen
        /// </summary>
        public PictureBoxEx Screen
        {
            get
            {
                return _InternalPictureBoxEx;
            }

            set
            {
                _InternalPictureBoxEx = value;
            }
        }

        /// <summary>
        /// Der Titel dieses Screenshots
        /// </summary>
        public string Title
        {
            set
            {
                base.Text = value;
            }

            get
            {
                return base.Text;
            }
        }

        /// <summary>
        /// Das zugrundeliegende PictureBox-Control
        /// </summary>
        public PictureBoxEx PictureControl
        {
            get
            {
                return _InternalPictureBoxEx;
            }

            set
            {
                _InternalPictureBoxEx = value;
            }
        }

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // STTabPage
            //
            this.ResumeLayout(false);

        }

    }
}
