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

        public int AlleZeit // soll im Timer1_tick angegben werden und die max. größe des slides setzen.
        {
            get { return AlleZeit; }
            set { this.slider.Maximum = value; }
        }

        public void Aktualisieren(Koordinate k) // soll den aktuellen zeit wert der koordinate addieren und im  slider anzeigen.
        {
            this.slider.Value += (int) k.Zeit;
            
        }
    }
}
