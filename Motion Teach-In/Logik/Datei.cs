using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace Motion_Teach_In
{
    public class Datei : List<Linie>
    {
        // Allgemeine Variablen
        string dateiname;

        #region Konstruktoren und Methoden für Dateizugriff
        // Konstruktur für leere Dateien
        public Datei()
        {

        }

        // Konstruktur zum Laden von existierenden Dateien
        public Datei(string filename)
        {
            dateiname = filename;
        }

        // Speichert die aktuelle Instanz in einer SQLite-Datenbank
        public void Speichern(string dateiname)
        {

        }

        public void Speichern()
        {

        }
        #endregion

        #region Methoden zum Zugriff auf den Inhalt
        // Lösche alle Punkte im Rechteck lb x lh um den Punkt x, y
        // Liefert true zurück, wenn Punkte gelöscht worden sind
        public bool LoescheBei(int x, int y, int lb, int lh)
        {
            bool punkteGeloescht = false;

            int min_x = x - lb / 2;
            int max_x = x + lb / 2;
            int min_y = y - lh / 2;
            int max_y = y + lh / 2;

            for(int i = Count - 1; i >= 0; i--)
            {
                // Alle passenden Koordinaten aus der Linie entfernen
                for(int k = this[i].Count - 1; k >= 0; k--)
                {
                    Koordinate koord = this[i][k];
                    if (koord.X >= min_x && koord.X <= max_x)
                    {
                        if (koord.Y >= min_y && koord.Y <= max_y)
                        {
                            // Punkt befindet sich inenrhalb des angegebenen Rechtecks, also löschen
                            this[i].RemoveAt(k);
                            punkteGeloescht = true;
                        }
                    }
                }

                // Sind in dieser Linie überhaupt noch Punkte enthalten?
                if (this[i].Count == 0)
                {
                    // Nein - Linie löschen
                    this.RemoveAt(i);
                }
            }

            return punkteGeloescht;
        }
        #endregion
    }
}
