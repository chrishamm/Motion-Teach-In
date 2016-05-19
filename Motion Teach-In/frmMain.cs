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

        #region Dateioperationen
        private bool DarfDateiVeraendern()
        {
            if (zflInhalt.Datei.Veraendert)
            {
                DialogResult res = MessageBox.Show("Diese Datei ist verändert worden.\n\nMöchten Sie Ihre Änderungen speichern?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    if (sfdDatei.ShowDialog() == DialogResult.OK)
                    {
                        zflInhalt.Datei.Speichern(sfdDatei.FileName);
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (res == DialogResult.Cancel)
                {
                    return false;
                }
            }
            return true;
        }

        private void mnuNeu_Click(object sender, EventArgs e)
        {
            if (DarfDateiVeraendern())
            {
                zflInhalt.Datei = new Datei();
            }
        }

        private void mnuÖffnen_Click(object sender, EventArgs e)
        {
            if (DarfDateiVeraendern() && ofdDatei.ShowDialog() == DialogResult.OK)
            {
                zflInhalt.Datei = new Datei(ofdDatei.FileName);
            }
        }

        private void mnuSpeichern_Click(object sender, EventArgs e)
        {
            if (zflInhalt.Datei.Dateiname != "")
            {
                zflInhalt.Datei.Speichern();
            }
            else
            {
                mnuSpeichernUnter.PerformClick();
            }
        }

        private void mnuSpeichernUnter_Click(object sender, EventArgs e)
        {
            if (sfdDatei.ShowDialog() == DialogResult.OK)
            {
                zflInhalt.Datei.Speichern(sfdDatei.FileName);
            }
        }
        #endregion

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!DarfDateiVeraendern())
            {
                e.Cancel = true;
            }
        }
    }
}
