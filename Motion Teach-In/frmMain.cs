using System;
using System.Windows.Forms;

namespace Motion_Teach_In
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        #region Modusauswahl
        private void mnuBeenden_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbZeichnenmodus_Click(object sender, EventArgs e)
        {
            tsbZeichnenmodus.Checked = true;
            tsbLoeschmodus.Checked = false;
            zflInhalt.ControlModus = Zeichenfläche.Modus.Zeichenmodus;
        }

        private void tsbLoeschmodus_Click(object sender, EventArgs e)
        {
            tsbZeichnenmodus.Checked = false;
            tsbLoeschmodus.Checked = true;
            zflInhalt.ControlModus = Zeichenfläche.Modus.Loeschmodus;
        }

        private void tsbWiedergabe_Click(object sender, EventArgs e)
        {
            zflInhalt.ControlModus = Zeichenfläche.Modus.Wiedergabemodus;
            zflInhalt.WiedergabeStarten();
        }

        private void tsbStop_Click(object sender, EventArgs e)
        {
            zflInhalt.WiedergabeStoppen();
        }

        private void zflInhalt_WiedergabeGestartet(object sender, EventArgs e)
        {
            tsbZeichnenmodus.Checked = false;
            tsbLoeschmodus.Checked = false;

            tsbWiedergabe.Checked = true;
            tsbWiedergabe.Enabled = false;
            tsbStop.Enabled = true;
        }

        private void zflInhalt_WiedergabeGestoppt(object sender, EventArgs e)
        {
            zflInhalt.ControlModus = Zeichenfläche.Modus.Zeichenmodus;
            tsbZeichnenmodus.Checked = true;

            tsbWiedergabe.Enabled = true;
            tsbWiedergabe.Checked = false;
            tsbStop.Enabled = false;
        }
        #endregion
    }
}
