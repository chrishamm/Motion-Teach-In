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
            set { slider.Maximum = value; }
        }

        // Gibt den aktuell gesetzten Zeitwert an oder setzt diesen
        public int Zeitwert
        {
            get { return slider.Value; }
            set { slider.Value = Math.Min(slider.Maximum, value); }
        }
    }
}
