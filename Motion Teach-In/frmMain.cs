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

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Beim Laden der Form einmalig Event der leeren Datei setzen
            zflInhalt.Datei.CollectionChanged += Datei_CollectionChanged;
        }

        #region Modusauswahl
        private void mnuBeenden_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbZeichnenmodus_Click(object sender, EventArgs e)
        {
            zflInhalt.ControlModus = Zeichenfläche.Modus.Zeichenmodus;
        }

        private void tsbLoeschmodus_Click(object sender, EventArgs e)
        {
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

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!DarfDateiVeraendern())
            {
                // Aktion abbrechen, wenn die Datei nicht gespeichert wurde und die Datei behalten werden soll
                e.Cancel = true;
            }
        }
        #endregion

        #region Ereignisbehandlung der Zeichenfläche
        private void zflInhalt_ModusGeaendert(object sender, Zeichenfläche.Modus alterModus, Zeichenfläche.Modus neuerModus)
        {
            tsbZeichnenmodus.Checked = (neuerModus == Zeichenfläche.Modus.Zeichenmodus);
            tsbLoeschmodus.Checked = (neuerModus == Zeichenfläche.Modus.Loeschmodus);
            tsbWiedergabe.Checked = zazSkala.Visible = (neuerModus == Zeichenfläche.Modus.Wiedergabemodus);
        }

        private void zflInhalt_WiedergabeGestartet(object sender, EventArgs e)
        {
            tsbWiedergabe.Enabled = false;
            tsbStop.Enabled = true;

            zazSkala.MaxZeit = zflInhalt.Datei.ZeitGesamt;
            tmrWiedergabe.Start();
        }

        private void zflInhalt_WiedergabeGestoppt(object sender, EventArgs e)
        {
            tsbWiedergabe.Enabled = true;
            tsbStop.Enabled = false;

            zazSkala.Zeitwert = zflInhalt.WiedergabeZeit;
            tmrWiedergabe.Stop();
        }

        private void tmrWiedergabe_Tick(object sender, EventArgs e)
        {
            // Skala während der Wiedergabe aktualisieren
            zazSkala.Zeitwert = zflInhalt.WiedergabeZeit;
        }

        private void zflInhalt_DateiGeaendert(object sender, Datei alteDatei, Datei neueDatei)
        {
            // Listener für Linienänderungen einbauen
            neueDatei.CollectionChanged += Datei_CollectionChanged;

              zazSkala.MaxZeit = neueDatei.ZeitGesamt;
            zazSkala.Zeitwert = neueDatei.ZeitGesamt;

            // Listbox der Linien neu füllen
            LinienAktualisieren();
        }

        private void Datei_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Listbox aktualisieren
            LinienAktualisieren();
        }

        private void LinienAktualisieren()
        {
            lstLinien.BeginUpdate();
            lstLinien.Items.Clear();
            int counter = 1;
            foreach(Linie l in zflInhalt.Datei)
            {
                lstLinien.Items.Add(String.Format("Linie {0}", counter));
                counter++;
            }
            lstLinien.EndUpdate();
        }
        #endregion

        #region Listbox zur Anzeige bzw. Manipulation von Linien
        private void lstLinien_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ausgewählte Linien markieren
            zflInhalt.MarkierteLinie = (lstLinien.SelectedIndex == -1) ? null : zflInhalt.Datei[lstLinien.SelectedIndex];
        }

        private void lstLinien_KeyDown(object sender, KeyEventArgs e)
        {
            // Ausgewählte Linien beim Druck auf "ENTF" löschen
            if (e.KeyCode == Keys.Delete && lstLinien.SelectedIndex != -1)
            {
                zflInhalt.Datei.RemoveAt(lstLinien.SelectedIndex);
            }
        }

        private void lstLinien_Leave(object sender, EventArgs e)
        {
            // Markierungen sind aktuell nur zulässig wenn der Fokus in der Listbox liegt
            lstLinien.SelectedIndex = -1;
            zflInhalt.MarkierteLinie = null;
        }
        #endregion

        #region Ereignisbehandlung der Zeitanzeige
        // Zeichenfläche bei Änderung des Sliders anpassen
        private void zazSkala_SliderBewegt(object sender, EventArgs e)
        {
            zflInhalt.WiedergabeZeit = zazSkala.Zeitwert;
        }
        #endregion
    }
}
