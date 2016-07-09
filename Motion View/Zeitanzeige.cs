using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Motion_View
{
    public partial class Zeitanzeige : UserControl
    {
        public Zeitanzeige()
        {
            InitializeComponent();
        }

        // Legt Labels als Skaleninformationen an
        static readonly int paddingLabel = 16;          // in px. Gibt den Abstand des Sliders vom Rand an
        static readonly int maxSkalenSegmente = 20;
        static readonly int minLabelGroesse = 40;       // in px. Gibt die minimale Breite eines Labels an

        // Gibt den maximalen Zeitwert an oder setzt diesen
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public int MaxZeit
        {
            get { return slider.Maximum; }
            set
            {
                // Slider anpassen
                slider.Maximum = value;

                // Anzahl und Größe der einzelnen Labels berechnen
                int segmentanzahl = Math.Min(MaxZeit / 1000 + 1, maxSkalenSegmente);
                int segmentlänge = Math.Max((pnlLabels.Width - paddingLabel * 2) / segmentanzahl, minLabelGroesse);

                // Neue Labels mit den Angaben der Sekunden und Parametern erzeugen
                pnlLabels.Controls.Clear();
                for (int i = 0; i <= segmentanzahl; i++)
                {
                    Label lb = new Label();
                    lb.Text = ((MaxZeit / 1000.0) * ((float)i / (float)segmentanzahl)).ToString("0.0") + " s";
                    lb.AutoSize = true;
                    lb.Location = new Point(segmentlänge * i + paddingLabel, pnlLabels.Padding.Top);
                    pnlLabels.Controls.Add(lb);
                }

                // Alle Labels zentrieren
                foreach (Control control in pnlLabels.Controls)
                {
                    Label lb = (Label)control;
                    lb.Location = new Point(Math.Max(0, lb.Location.X - lb.Width / 2), pnlLabels.Padding.Top);
                }
            }
        }

        // Gibt den aktuell gesetzten Zeitwert an oder setzt diesen
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public int Zeitwert
        {
            get { return slider.Value; }
            set { slider.Value = Math.Min(slider.Maximum, value); }
        }

        // Positioniert die Labels bei Größenänderungen neu
        private void pnlLabels_Resize(object sender, EventArgs e)
        {
            // Labels neu positionieren
            int segmentanzahl = Math.Min(MaxZeit / 1000 + 1, maxSkalenSegmente);
            int segmentlänge = Math.Max((pnlLabels.Width - paddingLabel * 2) / segmentanzahl, minLabelGroesse);

            for (int i = 0; i < pnlLabels.Controls.Count; i++)
            {
                Label lb = (Label)pnlLabels.Controls[i];
                lb.Location = new Point(segmentlänge * i + paddingLabel - lb.Width / 2, pnlLabels.Padding.Top);
            }
        }

        // Event zur Benachrichtigung bei manuellem Ändern des Sliders
        public event EventHandler SliderBewegt;

        private void slider_Scroll(object sender, EventArgs e)
        {
            SliderBewegt?.Invoke(sender, e);
        }
    }
}
