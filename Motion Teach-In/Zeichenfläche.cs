using System;
using System.Collections.Generic;
using System.Drawing;
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

 #region globale variablen
        public static bool zeichnen_aktiv;
        public static bool wiedergeben_aktiv = false;
        public static bool löschen = false;
        public  List<List<Point>> arbeits_kopie;     
        public static Stopwatch Stoppuhr = new Stopwatch();
        
#endregion




        private void Zeichenfläche_Load(object sender, EventArgs e)
        {
            
            arbeits_kopie = new List<List<Point>>();       
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
                arbeits_kopie.Add(new List<Point>());
                
                Stoppuhr.Start();
            }
            zeichnen_aktiv = true;

        }

        private void Zeichenfläche_MouseUp(object sender, MouseEventArgs e)
        {
            zeichnen_aktiv = false;
            Stoppuhr.Reset();

        }

        private void Zeichenfläche_MouseMove(object sender, MouseEventArgs e)
        {

            if (zeichnen_aktiv && !löschen)
            {
                arbeits_kopie[arbeits_kopie.Count - 1].Add(e.Location);
                #region unfertige zeit
                /* TimeSpan vergangene_zeit = Stoppuhr.Elapsed;
                int vergangene_zeit_absolut = (int) vergangene_zeit.TotalMilliseconds;
                 int interval = vergangene_zeit_absolut % 10;

                 if (interval == 0)
                 {


                 }*/

#endregion
                Refresh();
            }


            if (zeichnen_aktiv && löschen)
            {
                for (int i = 0; i <= arbeits_kopie.Count - 1; i++)
                {
                    for (int y = 0; y <= arbeits_kopie[i].Count - 1; y++)
                    {
                        if (arbeits_kopie[i][y] == e.Location)
                        {
                            arbeits_kopie[i].RemoveAt(y);
                            #region unfertige aufteilung der listen
                            /* List<Point> teilen1 = arbeits_kopie[i].GetRange(0, --y);
                            List<Point> teilen2 = arbeits_kopie[i].GetRange(++y, arbeits_kopie[i].Count-1);
                            if (teilen1 != null)
                            {
                                arbeits_kopie.Insert(--i, teilen1);
                            }
                            if (teilen2 != null)
                            {
                                arbeits_kopie.Insert(++i, teilen2);
                            }
                            arbeits_kopie.RemoveAt(i);*/
                            #endregion
                            Refresh();
                       
                        }
                       
                    }
                }
            }
        }

        private void Zeichenfläche_Paint(object sender, PaintEventArgs e)
        {
            
            Brush pinsel = (Brush)Brushes.Black;
            Graphics g = this.CreateGraphics();

            foreach (List<Point> points in arbeits_kopie)
            {
                
                foreach (Point punkt in points)
                {
                    if (!wiedergeben_aktiv)
                    {
                        g.FillRectangle(pinsel, punkt.X, punkt.Y, 2, 2);
                    }
                    else 
                    {
                        g.FillRectangle(pinsel, punkt.X+50, punkt.Y+50, 2, 2); //dient nur zum testen, damit es nicht zu überlagerungen zwischen original und wiedergabe kommt
                    }
                }
            }
            g.Dispose();
            
        }




        private void Radiergummi_Click(object sender, EventArgs e)
        {   
            if (löschen == false)
            {
                löschen = true;
                Radiergummi.Text = "Löschen aktiv";
            }
            else
            {
                Radiergummi.Text = "Löschen";
                löschen = false;
                zeichnen_aktiv = false;
            }
        }

        public  void Wiedergabe(List<List<Point>> kohledurchschlag)
        {
            wiedergeben_aktiv = true;
            
            Refresh();
            wiedergeben_aktiv = false;
         
           
        }
    // if (points.Count > 1)
    //  e.Graphics.DrawLines(new Pen(new SolidBrush(Color.Black), 10), points.ToArray());
}
}
