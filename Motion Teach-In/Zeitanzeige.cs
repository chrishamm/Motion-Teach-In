using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motion_Teach_In
{
    public partial class Zeitanzeige : UserControl
    {
        public Zeitanzeige()
        {
            InitializeComponent();
        }

        // Gibt den maximalen Zeitwert an oder setzt diesen
        public int MaxZeit
        {
            get { return slider.Maximum; }
            set { slider.Maximum = (value/1000) + 1; } //skala soll sekunden anzeigen, dient der übersicht
        }

        // Gibt den aktuell gesetzten Zeitwert an oder setzt diesen
        public int Zeitwert
        {
            get { return slider.Value; }
            set { slider.Value = Math.Min(slider.Maximum, value/1000); }
        }

        //enthält alle erzeugte labels, wichtig beim späteren löschen
        List<Label>  Labelliste = new List<Label>(); 

        //errechnet die skalenwerte anhand der maximalen zeit
        public void SkalaBerechnen(int Zeitabsolut) 
        {
            //berechnen der skalenwertanzahl und der länge
            int segmentanzahl = Zeitabsolut / 1000 + 1; 
            int segmentlänge = (this.Width/segmentanzahl);

            if (segmentanzahl <= 30)
            {
                //erzeugen neuer labels mit den angaben der sekunden und parametern (name,location...)
                for (int i = 0; i <= segmentanzahl; i++)
                {
                    Label lb = new Label();
                    lb.Name = "Label" + i.ToString();
                    lb.Text = i.ToString() + "s";
                    Labelliste.Add(lb);
                    lb.Location = new System.Drawing.Point(segmentlänge*i, slider.Height);
                    lb.AutoSize = true;
                    this.Controls.Add(lb);

                }
            }
            else
            {
                 segmentanzahl = Zeitabsolut / 10000 + 1;
                 segmentlänge = (this.Width / segmentanzahl);
                MaxZeit = Zeitabsolut/10 ;
                for (int i = 0; i <= segmentanzahl; i++)
                {
                    Label lb = new Label();
                    lb.Name = "Label" + i.ToString();
                    lb.Text = i.ToString() + "0s";
                    Labelliste.Add(lb);
                    lb.Location = new System.Drawing.Point(segmentlänge * i, slider.Height);
                    lb.AutoSize = true;
                    this.Controls.Add(lb);

                }
            }

        }

        public void SkalaLöschen()
        {
            if (Labelliste.Count != 0)
            {
                foreach (Label name in Labelliste)
                {
                    this.Controls.Remove(name);
                }
            }
            
        }
    }
}
