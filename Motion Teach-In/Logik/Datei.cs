using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

// Datei-Klasse zur logischen Abbildung eines Projekts
//
// Jede Datei ist aus Elementen der Klasse "Linie" aufgebaut, welche 
// wiederum die einzelnen Koordinaten inkl. zeitlicher Dimensionen enthält.
//
// Zur Speicherung dieser Informationen werden alle Koordinaten in dem folgenden
// Format in einer SQLite-Tabelle names "Koordinaten" abgespeichert:
//
// Linie (int) | X (int) | Y (int) | Zeit (int, in ms)
// Bei anderen DB-Systemen könnte es erforderlich sein einen "id"-Schlüssel zur
// Beibehaltung der Reihenfolge anzulegen.
namespace Motion_Teach_In
{
    public class Datei : ObservableCollection<Linie>
    {
        SQLiteConnection sqliteConnection;

        #region Methoden und Felder für Dateizugriff
        string dateiname;
        public string Dateiname
        {
            get
            {
                return dateiname;
            }
        }

        // Konstruktur für leere Dateien
        public Datei()
        {
            dateiname = "";
        }

        // Konstruktur zum Laden von existierenden Dateien
        public Datei(string filename)
        {
            // Verbindung zur Datenquelle herstellen
            sqliteConnection = new SQLiteConnection("Data Source=" + filename);
            sqliteConnection.Open();
            dateiname = filename;

            // Tabelle "Koordinaten" auslesen
            SQLiteCommand selectCmd = new SQLiteCommand(sqliteConnection);
            selectCmd.CommandText = "SELECT * FROM Koordinaten;";

            Linie linie = null;
            int indexLinie = 0;
            SQLiteDataReader reader = selectCmd.ExecuteReader();
            while (reader.Read())
            {
                int neuerIndexLinie = reader.GetInt32(0);
                if (linie == null || indexLinie != neuerIndexLinie)
                {
                    linie = new Linie();
                    Add(linie);
                    indexLinie = neuerIndexLinie;
                }

                int x = reader.GetInt32(1);
                int y = reader.GetInt32(2);
                int zeit = reader.GetInt32(3);
                linie.Add(new Koordinate(x, y, zeit));
            }

            // Fertig
            veraendert = false;
        }

        // Speichert diese Instanz in einer SQLite-Datenbank
        public void Speichern(string filename)
        {
            if (dateiname != filename)
            {
                // Verbindung zur Datenquelle herstellen
                sqliteConnection = new SQLiteConnection("Data Source=" + filename);
                sqliteConnection.Open();
                dateiname = filename;

                // Tabelle "Koordinaten" anlegen
                SQLiteCommand createCmd = new SQLiteCommand(sqliteConnection);
                createCmd.CommandText = "CREATE TABLE IF NOT EXISTS Koordinaten (linie INTEGER NOT NULL, x INTEGER NOT NULL, y INTEGER NOT NULL, ZeitAbsolut INTEGER NOT NULL);";
                createCmd.ExecuteNonQuery();
            }

            // Tabelle leeren
            SQLiteCommand deleteCmd = new SQLiteCommand(sqliteConnection);
            deleteCmd.CommandText = "DELETE FROM Koordinaten;";
            deleteCmd.ExecuteNonQuery();

            // Tabelle füllen und dabei Transaktion nutzen, um höhere Performance zu erreichen
            SQLiteCommand insertCmd = new SQLiteCommand(sqliteConnection);
            SQLiteTransaction transaction = sqliteConnection.BeginTransaction();
            for(int indexLinie = 0; indexLinie < Count; indexLinie++)
            {
                Linie linie = this[indexLinie];
                foreach(Koordinate koord in linie)
                {
                    insertCmd.CommandText = String.Format("INSERT INTO Koordinaten (linie, x, y, ZeitAbsolut) VALUES ({0}, {1}, {2}, {3});",
                        indexLinie, koord.X, koord.Y, koord.Zeit);
                    insertCmd.ExecuteNonQuery();
                }
            }
            transaction.Commit();
            veraendert = false;
        }

        public void Speichern()
        {
            Speichern(dateiname);
        }

        // Ist die Datei seit dem letzten Speichern verändert worden?
        private bool veraendert;
        public bool Veraendert
        {
            get
            {
                if (dateiname == "" && Count > 0)
                {
                    return true;
                }
                return veraendert;
            }
        }

        public new void Add(Linie item)
        {
            item.CollectionChanged += LinieChanged;
            base.Add(item);
        }

        private void LinieChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            veraendert = true;
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            veraendert = true;
            base.OnCollectionChanged(e);
        }
        #endregion

        // Liefert die gesamte Zeichendauer der einzelnen Koordinaten zurück
        public int ZeitGesamt
        {
            get
            {
                int zeit = 0;
                foreach (Linie l in this)
                {
                    foreach (Koordinate koord in l)
                    {
                        zeit += koord.Zeit;
                    }
                }
                return zeit;
            }
            set { ZeitGesamt = value; }
        }

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
    }
}
