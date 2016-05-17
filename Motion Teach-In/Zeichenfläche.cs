using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;


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
        public static bool zähler = true;
        
       // public  List<List<Point>> arbeits_kopie;
        public List<List<Koordinaten>>  arbeits_kopie;
        public static Stopwatch Stoppuhr = new Stopwatch();
        public long unabhängige_zeit = 0;
        
#endregion


        

        private void Zeichenfläche_Load(object sender, EventArgs e)
        {
            
          //  arbeits_kopie = new List<List<Point>>();   
              arbeits_kopie = new List<List<Koordinaten>>();
            this.DoubleBuffered = true;
            this.MouseDown += new MouseEventHandler(Zeichenfläche_MouseDown);
            this.MouseUp += new MouseEventHandler(Zeichenfläche_MouseUp);
            this.MouseMove += new MouseEventHandler(Zeichenfläche_MouseMove);
            this.Paint += new PaintEventHandler(Zeichenfläche_Paint);
 }

        private void Zeichenfläche_MouseDown(object sender, MouseEventArgs e)
        {
            if (!löschen && zähler)
            {
               // arbeits_kopie.Add(new List<Point>());
               arbeits_kopie.Add(new List<Koordinaten>());
                
                Stoppuhr.Start();
                zähler = false;
                
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
            zähler = true;
            
            if (zeichnen_aktiv && !löschen)
            {
                // arbeits_kopie[arbeits_kopie.Count - 1].Add(e.Location);
                
                Koordinaten koord = new Koordinaten();
               arbeits_kopie[arbeits_kopie.Count-1].Add(koord);
               int index = arbeits_kopie[arbeits_kopie.Count - 1].Count;
               arbeits_kopie[arbeits_kopie.Count -1][index-1].Punkt = e.Location;
                long  zeit =  Stoppuhr.ElapsedMilliseconds;
                arbeits_kopie[arbeits_kopie.Count - 1][index - 1].vergangegene_zeit = zeit;

                
                Refresh();
            }


            if (zeichnen_aktiv && löschen)
            {
                for (int i = 0; i <= arbeits_kopie.Count - 1; i++) //ändern
                {
                    for (int y = 0; y <= arbeits_kopie[i].Count - 1; y++)
                    {
                        if (arbeits_kopie[i][y].Punkt == e.Location)
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
            
            

                foreach (List<Koordinaten> points in arbeits_kopie)
                {

                    foreach (Koordinaten punkt in points)
                    {
                        long zeit = punkt.vergangegene_zeit;

                        if (!wiedergeben_aktiv)
                        {
                            g.FillRectangle(pinsel, punkt.Punkt.X, punkt.Punkt.Y, 2, 2);
                        }
                        else
                        {
                            g.FillRectangle(pinsel, punkt.Punkt.X + 50, punkt.Punkt.Y + 50, 2, 2);

                            Thread.Sleep((int) (zeit - unabhängige_zeit));
                            unabhängige_zeit = zeit;

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

        public  void Wiedergabe()
        {
            wiedergeben_aktiv = true;
            
            Refresh();
           
            wiedergeben_aktiv = false;




        }
    // if (points.Count > 1)
    //  e.Graphics.DrawLines(new Pen(new SolidBrush(Color.Black), 10), points.ToArray());
}
}
