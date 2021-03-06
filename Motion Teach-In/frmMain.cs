﻿using System;
using System.Windows.Forms;
using Motion_Model;
using Motion_View;
using Motion_Robot;
using dobottest.CPlusDll;


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
        private void tsbBewegen_Click(object sender, EventArgs e)
        {
            zflInhalt.ControlModus = Zeichenfläche.Modus.Bewegemodus;
        }

        private void tsbZeichnenmodus_Click(object sender, EventArgs e)
        {
            zflInhalt.ControlModus = Zeichenfläche.Modus.Zeichenmodus;
        }

        private void tsbLoeschmodus_Click(object sender, EventArgs e)
        {
            zflInhalt.ControlModus = Zeichenfläche.Modus.Loeschmodus;
        }
        private void tsbUrsprungFestlegen_Click(object sender, EventArgs e)
        {
            zflInhalt.ControlModus = Zeichenfläche.Modus.Ursprungsmodus;
        }

        private void tsbWiedergabe_Click(object sender, EventArgs e)
        {
            zflInhalt.ControlModus = Zeichenfläche.Modus.Wiedergabemodus;

            zazSkala.MaxZeit = zflInhalt.Datei.ErmittleGesamtzeit();
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
            // Buttons der Toolbar aktualisieren
            tsbBewegen.Checked = (neuerModus == Zeichenfläche.Modus.Bewegemodus);
            tsbZeichnenmodus.Checked = (neuerModus == Zeichenfläche.Modus.Zeichenmodus);
            tsbLoeschmodus.Checked = (neuerModus == Zeichenfläche.Modus.Loeschmodus);
            tsbWiedergabeStarten.Checked = (neuerModus == Zeichenfläche.Modus.Wiedergabemodus);
            tsbUrsprungFestlegen.Checked = (neuerModus == Zeichenfläche.Modus.Ursprungsmodus);

            // Zeitskala nur im Wiedergabemodus aktivieren
            zazSkala.Enabled = (neuerModus == Zeichenfläche.Modus.Wiedergabemodus);
        }

        private void zflInhalt_MouseUp(object sender, MouseEventArgs e)
        {
            if (zflInhalt.ControlModus == Zeichenfläche.Modus.Zeichenmodus)
            {
                // Im Zeichenodus die Skala aktuell halten
                zazSkala.Zeitwert = zazSkala.MaxZeit = zflInhalt.Datei.ErmittleGesamtzeit();
            }
        }

        private void zflInhalt_WiedergabeGestartet(object sender, EventArgs e)
        {
            tsbWiedergabeStarten.Enabled = false;
            tsbWiedergabeStoppen.Enabled = true;

            tmrWiedergabe.Start();
        }

        private void zflInhalt_WiedergabeGestoppt(object sender, EventArgs e)
        {
            tsbWiedergabeStarten.Enabled = true;
            tsbWiedergabeStoppen.Enabled = false;

            zazSkala.Zeitwert = zazSkala.MaxZeit;
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

            // Zeitskala anpassen
            zazSkala.Zeitwert = zazSkala.MaxZeit = zflInhalt.Datei.ErmittleGesamtzeit();

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
            foreach (Linie l in zflInhalt.Datei)
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

        private void mnuBeenden_Click(object sender, EventArgs e)
        {
            Close();
        }

        // erzeugt eine neue roboterform wenn eine Bewegung aktuell vorhanden ist, wenn nicht wird Benachrichtigung ausgegeben
        private void btn_robotersteuerung_Click(object sender, EventArgs e)
        {
            if (zflInhalt.Datei.Count != 0)
            {   
                Form roboterfenster = new Robotform(zflInhalt.Datei, zflInhalt.Height, zflInhalt.Width);
            }
            else
            {
                MessageBox.Show("Wähle zuerst eine Bewegung aus!");
                return;
            }
        }
    }
}
