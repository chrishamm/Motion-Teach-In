using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Motion_Teach_In
{
    public partial class Zeichenfläche : UserControl
    {
        public Zeichenfläche()
        {
            InitializeComponent();
        }

       public static bool m_Drawing;
       public static List<List<Point>> m_Points;
       public static Stopwatch Stoppuhr = new Stopwatch();
        
        

        private void Zeichenfläche_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            m_Points = new List<List<Point>>();
            this.DoubleBuffered = true;
            this.MouseDown += new MouseEventHandler(Zeichenfläche_MouseDown);
            this.MouseUp += new MouseEventHandler(Zeichenfläche_MouseUp);
            this.MouseMove += new MouseEventHandler(Zeichenfläche_MouseMove);
            this.Paint += new PaintEventHandler(Zeichenfläche_Paint);
            



        }
        
        private void Zeichenfläche_MouseDown(object sender, MouseEventArgs e)
        {
            m_Points.Add(new List<Point>());
            m_Drawing = true;
            Stoppuhr.Start();
            
        }

        private void Zeichenfläche_MouseUp(object sender, MouseEventArgs e)
        {
            m_Drawing = false;
            Stoppuhr.Reset();
        }

        private void Zeichenfläche_MouseMove(object sender, MouseEventArgs e)
        {
           
            
            
            

            if (m_Drawing  )
            {
                m_Points[m_Points.Count - 1].Add(e.Location);

                TimeSpan vergangene_zeit = Stoppuhr.Elapsed;
               int vergangene_zeit_absolut = (int) vergangene_zeit.TotalMilliseconds;
                int interval = vergangene_zeit_absolut % 10;

                if (interval == 0)
                {
                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"C:\Users\Public\Koordinaten.txt", true))
                    {

                        file.WriteLine(e.Location.X + "," + e.Location.Y + "," + vergangene_zeit_absolut);
                    }
                }
                
                
                this.Refresh();
            }
            
        }

        private void Zeichenfläche_Paint(object sender, PaintEventArgs e)
        {
            foreach (List<Point> points in m_Points)
            {
                if (points.Count > 1)
                    e.Graphics.DrawLines(new Pen(new SolidBrush(Color.Black), 2), points.ToArray());
            }
        }
    }
}
