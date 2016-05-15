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
using System.Runtime.InteropServices;


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
        //public static List<List<Point>> m_Points_löschen;
        public static Stopwatch Stoppuhr = new Stopwatch();
        public static bool löschen = false;
        public  List<List<int>> Bewegung = new List<List<int>>();
        
       
        
        

        private void Zeichenfläche_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            m_Points = new List<List<Point>>();
           // m_Points.Add(new List<Point>());
            this.DoubleBuffered = true;
            this.MouseDown += new MouseEventHandler(Zeichenfläche_MouseDown);
            this.MouseUp += new MouseEventHandler(Zeichenfläche_MouseUp);
            this.MouseMove += new MouseEventHandler(Zeichenfläche_MouseMove);
            this.Paint += new PaintEventHandler(Zeichenfläche_Paint);
            



        }
        
        private void Zeichenfläche_MouseDown(object sender, MouseEventArgs e)
        {
            if (!löschen)
            {
                m_Points.Add(new List<Point>());
            }
            m_Drawing = true;
            Stoppuhr.Start();
            Bewegung.Add(new List<int>()); // index 1 = x-werte;
            Bewegung.Add(new List<int>()); // index 2 = y-werte;
            Bewegung.Add(new List<int>()); // index 3 = v-werte;


        }

        private void Zeichenfläche_MouseUp(object sender, MouseEventArgs e)
        {
            m_Drawing = false;
            Stoppuhr.Reset();
           
        }

        private void Zeichenfläche_MouseMove(object sender, MouseEventArgs e)
        {
           
            
            
            

            if (m_Drawing && !löschen )
            {
                m_Points[m_Points.Count - 1].Add(e.Location);

             /*   TimeSpan vergangene_zeit = Stoppuhr.Elapsed;
               int vergangene_zeit_absolut = (int) vergangene_zeit.TotalMilliseconds;
                int interval = vergangene_zeit_absolut % 10;

                if (interval == 0)
                {
                    Bewegung[0].Add(e.Location.X);
                    Bewegung[1].Add(e.Location.Y);
                 
                }*/
                
                
                this.Refresh();
            }
            


            if (m_Drawing && löschen)

            {
                
             //  List<Point> temp_list = new List<Point>();
               // temp_list.Add(e.Location);
                

               for (int i = 0; i<= m_Points.Count-1;i++)
               {

                   for (int y = 0; y <= m_Points[i].Count - 1; y++)
                   {
                       if (m_Points[i][y] == e.Location)
                       {
                            //MessageBox.Show("eintrag");
                            m_Points[i].RemoveAt(y);
                            
                           
                            this.Refresh();
                        }
                   }
           
                
                }
             
            
                //this.Refresh();
            }
            
            
        }

        private void Zeichenfläche_Paint(object sender, PaintEventArgs e)
        {

            Brush aBrush = (Brush)Brushes.Black;
            Graphics g = this.CreateGraphics();

            


            foreach (List<Point> points in m_Points)
            {// if (points.Count > 1)
             //  e.Graphics.DrawLines(new Pen(new SolidBrush(Color.Black), 10), points.ToArray());
                foreach (Point punkt in points)
                {
                    g.FillRectangle(aBrush, punkt.X, punkt.Y, 3, 3);
                   
                }
            }

         



        }
        
       


        private void Radiergummi_Click(object sender, EventArgs e)
        {
            if (löschen == false)
            {
                löschen = true;
            }
            else
            {
                löschen = false;
                m_Drawing = false;
            }
        }
    }
}
