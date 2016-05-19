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
                    arbeits_kopie[index_außen - 1][index_innen - 1].VergangeneZeit = zeit;
                }

                if (index_innen >= 2 && arbeits_kopie[index_außen - 1][index_innen - 2].Punkt == e.Location)//wenn der letzte punkt gleich dem potentiellen neuen punkt ist wird die neueste koordinate gelöscht
                {
                    arbeits_kopie[index_außen - 1].RemoveAt(index_innen - 1);
                }

                if (index_innen <= 1)                                                                      // greift nur beim ersten durchlauf, hier kein punkt-vergleich (womit auch)
                {
                    arbeits_kopie[index_außen - 1][index_innen - 1].Punkt = e.Location;
                    long zeit = Stoppuhr.ElapsedMilliseconds;
                    arbeits_kopie[index_außen - 1][index_innen - 1].VergangeneZeit = zeit;
                }
                Refresh();
            }


            if (zeichnen_aktiv && löschen)                                                                 //wird aktiv, wenn der Radiergummie gewählt wurde und die maus gedrückt ist
            {
                #region RadiergummiRadius
                Point dreizehn = e.Location;                                                                //punkt-elemente werden eingeführt, um einen Lösch-Bereich zu haben
                                                                                                            //sollte man unter dem phänomen der wurstfinger leiden.

                Point eins = dreizehn;
                eins.X = dreizehn.X-2;
                eins.Y = dreizehn.Y - 2;                                                              //  01 02 03 04 05
                                                                                                      //  06 07 08 09 10
                Point zwei = dreizehn;                                                                //  11 12 13 14 15      13 entspricht der cursor-pos
                zwei.X = e.Location.X -1;                                                             //  16 17 18 19 20
                eins.Y = dreizehn.Y - 2;                                                              //  21 22 23 24 25

                Point drei = dreizehn;
                zwei.X = e.Location.X ;
                eins.Y = dreizehn.Y - 2;

                Point vier = dreizehn;
                vier.X = e.Location.X+1;
                eins.Y = dreizehn.Y - 2;

                Point fünf = dreizehn;
                fünf.X = e.Location.X+2;
                eins.Y = dreizehn.Y - 2;

                Point sechs= dreizehn;
                sechs.X = e.Location.X - 2;
                eins.Y = dreizehn.Y - 1;

                Point sieben = dreizehn;
                sieben.X = e.Location.X - 1;
                eins.Y = dreizehn.Y - 1;

                Point acht = dreizehn;
                acht.X = e.Location.X ;
                eins.Y = dreizehn.Y - 1;

                Point neun = dreizehn;
                neun.X = e.Location.X +1;
                eins.Y = dreizehn.Y - 1;

                Point zehn = dreizehn;
                zehn.X = e.Location.X +2 ;
                eins.Y = dreizehn.Y - 1;

                Point elf = dreizehn;
                elf.X = e.Location.X - 2;
                eins.Y = dreizehn.Y ;

                Point zwölf = dreizehn;
                zwölf.X = e.Location.X -1 ;
                eins.Y = dreizehn.Y ;

                Point vierzehn = dreizehn;
                vierzehn.X = e.Location.X + 1;
                eins.Y = vierzehn.Y ;

                Point fünfzehn = dreizehn;
                fünfzehn.X = e.Location.X + 2;
                eins.Y = fünfzehn.Y ;

                Point sechszehn = dreizehn;
                fünfzehn.X = e.Location.X - 2;
                eins.Y = fünfzehn.Y+1;

                Point siebzehn = dreizehn;
                siebzehn.X = e.Location.X -1;
                eins.Y = fünfzehn.Y + 1;

                Point achtzehn = dreizehn;
                achtzehn.X = e.Location.X ;
                eins.Y = fünfzehn.Y + 1;

                Point neunzehn = dreizehn;
                neunzehn.X = e.Location.X + 1;
                eins.Y = fünfzehn.Y + 1;

                Point zwanzig = dreizehn;
                zwanzig.X = e.Location.X + 2;
                eins.Y = fünfzehn.Y + 1;

                Point einundzwanzig = dreizehn;
                einundzwanzig.X = e.Location.X - 2;
                eins.Y = fünfzehn.Y + 2;

                Point zweiundzwanzig = dreizehn;
                zweiundzwanzig.X = e.Location.X - 1;
                eins.Y = fünfzehn.Y + 2;

                Point dreiundzwanzig = dreizehn;
                dreiundzwanzig.X = e.Location.X ;
                eins.Y = fünfzehn.Y + 2;

                Point vierundzwanzig = dreizehn;
                vierundzwanzig.X = e.Location.X + 1;
                eins.Y = fünfzehn.Y + 2;

                Point fünfundzwanzig = dreizehn;
                fünfundzwanzig.X = e.Location.X + 2;
                eins.Y = fünfzehn.Y + 2;







                #endregion                                                                          //enthält die punkte die den radiergummi definieren


                for (int i = 0; i <= arbeits_kopie.Count - 1; i++)
                {
                    bool test = false;
                   
                    for (int y = 0; y <= arbeits_kopie[i].Count - 1; y++)
                    {
                        if (arbeits_kopie[i][y].Punkt == fünfzehn || arbeits_kopie[i][y].Punkt == eins || arbeits_kopie[i][y].Punkt == zwei || arbeits_kopie[i][y].Punkt == drei || 
                            arbeits_kopie[i][y].Punkt == vier || arbeits_kopie[i][y].Punkt == fünf || arbeits_kopie[i][y].Punkt == sechs || arbeits_kopie[i][y].Punkt == sieben || arbeits_kopie[i][y].Punkt == acht || 
                            arbeits_kopie[i][y].Punkt == neun || arbeits_kopie[i][y].Punkt == zehn || arbeits_kopie[i][y].Punkt == elf || arbeits_kopie[i][y].Punkt == zwölf || arbeits_kopie[i][y].Punkt == dreizehn ||
                            arbeits_kopie[i][y].Punkt == vierzehn || arbeits_kopie[i][y].Punkt == fünfzehn || arbeits_kopie[i][y].Punkt == sechszehn || arbeits_kopie[i][y].Punkt == siebzehn || arbeits_kopie[i][y].Punkt == achtzehn
                             || arbeits_kopie[i][y].Punkt == neunzehn || arbeits_kopie[i][y].Punkt == zwanzig || arbeits_kopie[i][y].Punkt == zweiundzwanzig || arbeits_kopie[i][y].Punkt == dreiundzwanzig || arbeits_kopie[i][y].Punkt == vierundzwanzig
                              || arbeits_kopie[i][y].Punkt == fünfundzwanzig)                                         //durchsuch die koordinaten-listen nach der aktuellen Mauszeigerposition und löscht diese
                        {
                            
                            #region unfertige aufteilung der listen

                            if (y != 0 )
                            {
                                List<Koordinaten> teilen1 = arbeits_kopie[i].GetRange(0, y - 1);
                                List<Koordinaten> teilen2 = arbeits_kopie[i].GetRange(y + 1,arbeits_kopie[i].Count-1 - y);
                               
                                if (teilen1.Count != 0)
                                {
                                    arbeits_kopie.Insert(i + 1, teilen1);
                                }
                                if (teilen2.Count != 0)
                                {   
                                    arbeits_kopie.Insert(i + 1, teilen2);
                                }
                               
                                arbeits_kopie.RemoveAt(i);

                                #endregion

                                Refresh();
                                test = true;
                               
                                break;
                                
                            }
                            if (y == 0 ||y == arbeits_kopie[i].Count-1)
                            {
                                arbeits_kopie[i].RemoveAt(y);
                                if (arbeits_kopie[i].Count <= 1)
                                {
                                    arbeits_kopie.RemoveAt(i);
                                }
                                Refresh();
                            }

                           



                        }
                       

                    }
                    if (test)
                    { break; }
                    
                }
            }
        }

        private void Zeichenfläche_Paint(object sender, PaintEventArgs e)//Event wird bei Refresh aufgerufen, zeichnet entweder normal oder zeichnet im wiedergabemodus "nach"
        {

           Brush pinsel = (Brush)Brushes.Black;                                                              //neues pinsel-obj und graphics-obj erstellen
           
            Graphics g = this.CreateGraphics();



            foreach (List<Koordinaten> points in arbeits_kopie)                                          //durchläuft alle listen, ist die wiedergabe nicht aktiv
            {                                                                                            //wird den koordinaten entsprechend gezeichnet

                foreach (Koordinaten punkt in points)
                {
                    long zeit = punkt.VergangeneZeit;

                    if (!wiedergeben_aktiv)
                    {
                        g.FillRectangle(pinsel, punkt.Punkt.X, punkt.Punkt.Y, 5, 5);
                        

                    }
                    if (wiedergeben_aktiv)                                                                                //ist die wiedergabe aktiv, wird versetzt und zeit-korrekt gezeichnet
                    {
                        g.FillRectangle(pinsel, punkt.Punkt.X + 50, punkt.Punkt.Y + 50, 5, 5);
                       

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
                Cursor = new Cursor(GetType(), "gummi.cur");
               
            }
            else
            {
                Radiergummi.Text = "Löschen";
                löschen = false;
                zeichnen_aktiv = false;
                Cursor = DefaultCursor;
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
