﻿using System;
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
        public static bool zeichnen_aktiv;                                                          //schalter um zeichnen zu ermöglichen            
        public static bool wiedergeben_aktiv = false;                                               //schalter um wiedergabe zu ermöglichen
        public static bool löschen = false;                                                         //schalter um löschen zu ermöglichen
                                                                  //schalter, weil mouse_down sich doppelt aufruft.
        public List<List<Koordinaten>> arbeits_kopie;                                               //Globale Listen-Liste auf der opperiert wird
        public static Stopwatch Stoppuhr = new Stopwatch();                                         //Stopuhr zum erfassen der zeit zwischen den einzellnen punkten
        public long unabhängige_zeit = 0;                                                           //zwischenspeicher-variable für die Zeit

        #endregion




        private void Zeichenfläche_Load(object sender, EventArgs e)//Event welches beim Laden der Form aufgerufen wird
        {


            arbeits_kopie = new List<List<Koordinaten>>();                                              //Erstellen der Events und der initialen Listen-Liste
            this.DoubleBuffered = true;
           
        }

        private void Zeichenfläche_MouseDown(object sender, MouseEventArgs e)//Event wird ausgelöst wenn die Maus gedrückt wird (quasi initial-zündung)
        {
            if (!löschen )
            {
                arbeits_kopie.Add(new List<Koordinaten>());
                Stoppuhr.Start();
                
            }
            zeichnen_aktiv = true;
        }

        private void Zeichenfläche_MouseUp(object sender, MouseEventArgs e)//Event wird ausgelöst wenn die Maus losgelassen wird
        {
            zeichnen_aktiv = false;                                                                        //wird die maus losgelassen, wird die uhr zurück gesetzt und das zeichnen ist nicht mehr möglich
            Stoppuhr.Reset();
        }

        private void Zeichenfläche_MouseMove(object sender, MouseEventArgs e)//Event wird ausgelöst, wenn die Maus bewegt wird
        {
            

            if (zeichnen_aktiv && !löschen)                                                                //ist das zeichnen ermöglicht und will man nicht löschen, werden hier die mauskoord. gesammelt und sortiert
            {
                Koordinaten koord = new Koordinaten();
                arbeits_kopie[arbeits_kopie.Count - 1].Add(koord);

                int index_innen = arbeits_kopie[arbeits_kopie.Count - 1].Count;                            //dient nur zu verkürzung der indizes
                int index_außen = arbeits_kopie.Count;


                //if-abfragen sortieren doppelte punkte aus
                if (index_innen >= 2 && arbeits_kopie[index_außen - 1][index_innen - 2].Punkt != e.Location) //wenn der letzte punkt ungleich dem potentiellen neuen punkt ist und es überhaupt schon
                {                                                                                          //2 Punkte gibt, wird der Punkt-Wert und der zeitwert übernommen
                    arbeits_kopie[index_außen - 1][index_innen - 1].Punkt = e.Location;
                    long zeit = Stoppuhr.ElapsedMilliseconds;
                    arbeits_kopie[index_außen - 1][index_innen - 1].vergangegene_zeit = zeit;
                }

                if (index_innen >= 2 && arbeits_kopie[index_außen - 1][index_innen - 2].Punkt == e.Location)//wenn der letzte punkt gleich dem potentiellen neuen punkt ist wird die neueste koordinate gelöscht
                {
                    arbeits_kopie[index_außen - 1].RemoveAt(index_innen - 1);
                }

                if (index_innen <= 1)                                                                      // greift nur beim ersten durchlauf, hier kein punkt-vergleich (womit auch)
                {
                    arbeits_kopie[index_außen - 1][index_innen - 1].Punkt = e.Location;
                    long zeit = Stoppuhr.ElapsedMilliseconds;
                    arbeits_kopie[index_außen - 1][index_innen - 1].vergangegene_zeit = zeit;
                }
                Refresh();
            }


            if (zeichnen_aktiv && löschen)                                                                 //wird aktiv, wenn der Radiergummie gewählt wurde und die maus gedrückt ist
            {
                Point fünf = e.Location;                                                                //punkt-elemente werden eingeführt, um einen Lösch-Bereich zu haben
                                                                                                        //sollte man unter dem phänomen der wurstfinger leiden.
                Point vier = fünf;
                vier.X = fünf.X-1;

                Point sechs = fünf;
                sechs.X = e.Location.X +1;

                Point eins = fünf;
                eins.X = fünf.X - 1;
                eins.Y = fünf.Y + 1;

                Point zwei = fünf;
                eins.Y = fünf.Y + 1;

                Point drei = fünf;
                eins.X = fünf.X + 1;
                eins.Y = fünf.Y + 1;

                Point sieben = fünf;
                eins.X = fünf.X - 1;
                eins.Y = fünf.Y -1;

                Point acht = fünf;
                
                eins.Y = fünf.Y - 1;

                Point neun = fünf;
                eins.X = fünf.X + 1;
                eins.Y = fünf.Y - 1;



                for (int i = 0; i <= arbeits_kopie.Count - 1; i++)
                {
                    for (int y = 0; y <= arbeits_kopie[i].Count - 1; y++)
                    {
                        if (arbeits_kopie[i][y].Punkt == fünf || arbeits_kopie[i][y].Punkt == eins || arbeits_kopie[i][y].Punkt == zwei || arbeits_kopie[i][y].Punkt == drei || arbeits_kopie[i][y].Punkt == vier || arbeits_kopie[i][y].Punkt == sechs || arbeits_kopie[i][y].Punkt == sieben || arbeits_kopie[i][y].Punkt == acht || arbeits_kopie[i][y].Punkt == neun )                                         //durchsuch die koordinaten-listen nach der aktuellen Mauszeigerposition und löscht diese
                        {
                            
                            #region unfertige aufteilung der listen

                            if (y != 0)
                            {
                                List<Koordinaten> teilen1 = arbeits_kopie[i].GetRange(0, y - 1);
                                List<Koordinaten> teilen2 = arbeits_kopie[i].GetRange(y + 1,arbeits_kopie[i].Count-1 - y);
                                // arbeits_kopie[i].RemoveAt(y);
                                // arbeits_kopie[i].Clear();
                                if (teilen1 != null)
                                {
                                    arbeits_kopie.Insert(i + 1, teilen1);
                                }
                                if (teilen2 != null)
                                {
                                    arbeits_kopie.Insert(i + 2, teilen2);
                                }
                               // arbeits_kopie[i].Clear();
                                arbeits_kopie.RemoveAt(i);

                                #endregion

                                Refresh();

                                break;
                            }





                        }

                    }
                }
            }
        }

        private void Zeichenfläche_Paint(object sender, PaintEventArgs e)//Event wird bei Refresh aufgerufen, zeichnet entweder normal oder zeichnet im wiedergabemodus "nach"
        {

           Brush pinsel = (Brush)Brushes.Black;                                                              //neues pinsel-obj und graphics-obj erstellen
           // Pen stift = new Pen(Color.Black);
            Graphics g = this.CreateGraphics();



            foreach (List<Koordinaten> points in arbeits_kopie)                                          //durchläuft alle listen, ist die wiedergabe nicht aktiv
            {                                                                                            //wird den koordinaten entsprechend gezeichnet

                foreach (Koordinaten punkt in points)
                {
                    long zeit = punkt.vergangegene_zeit;

                    if (!wiedergeben_aktiv)
                    {
                        g.FillRectangle(pinsel, punkt.Punkt.X, punkt.Punkt.Y, 4, 4);
                        

                    }
                    else                                                                                 //ist die wiedergabe aktiv, wird versetzt und zeit-korrekt gezeichnet
                    {
                        g.FillRectangle(pinsel, punkt.Punkt.X + 50, punkt.Punkt.Y + 50, 4, 4);
                       

                        Thread.Sleep((int)(zeit - unabhängige_zeit));
                        unabhängige_zeit = zeit;
                    }
                }
            }
            g.Dispose();
            unabhängige_zeit = 0;
        }


        private void Radiergummi_Click(object sender, EventArgs e)//event wird ausgelöst wenn auf den radiergummi-button geklickt wird, fungiert eigentlich nur als bool-schalter
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

        public void Wiedergabe()//event wird ausgelöst wenn der wiedergabe-button gedrückt wird, fungiert als schalter (wiedergabe ein/aus) und zwingt die form sich neu zu zeichnen
        {
            wiedergeben_aktiv = true;

            Refresh();

            wiedergeben_aktiv = false;
        }
    }
}
