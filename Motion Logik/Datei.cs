using System;
using System.Data.SQLite;
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
namespace Motion_Model
{
    public class Datei : ObservableCollection<Linie>
    {
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
            SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=" + filename);
            sqliteConnection.Open();
            dateiname = filename;

            // Tabelle "Koordinaten" auslesen
            SQLiteCommand selectKoordinatenCmd = new SQLiteCommand(sqliteConnection);
            selectKoordinatenCmd.CommandText = "SELECT * FROM Koordinaten;";

            Linie linie = null;
            int indexLinie = 0;
            SQLiteDataReader reader = selectKoordinatenCmd.ExecuteReader();
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

            // Tabelle "Einstellungen" auslesen
            SQLiteCommand selectEinstellungenCommand = new SQLiteCommand(sqliteConnection);
            selectEinstellungenCommand.CommandText = "SELECT * FROM Einstellungen;";
            reader = selectEinstellungenCommand.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(0);
                string wert = reader.GetString(1);

                if (name == "ursprung_x")
                {
                    Ursprung.X = int.Parse(wert);
                }
                else if (name == "ursprung_y")
                {
                    Ursprung.Y = int.Parse(wert);
                }
            }

            // Fertig
            veraendert = false;
        }

        // Speichert diese Instanz in einer SQLite-Datenbank
        public void Speichern(string filename)
        {
            // Verbindung zur Datenquelle herstellen
            SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=" + filename);
            sqliteConnection.Open();

            // Wenn die Datei zum ersten mal oder unter einem anderen Namen gespeichert wird
            if (dateiname != filename)
            {
                dateiname = filename;

                // Tabelle "Koordinaten" anlegen
                SQLiteCommand createCmd = new SQLiteCommand(sqliteConnection);
                createCmd.CommandText = "CREATE TABLE IF NOT EXISTS Koordinaten (linie INTEGER NOT NULL, x INTEGER NOT NULL, y INTEGER NOT NULL, ZeitAbsolut INTEGER NOT NULL);";
                createCmd.ExecuteNonQuery();
                createCmd.CommandText = "CREATE TABLE IF NOT EXISTS Einstellungen (name TEXT, wert TEXT);";
                createCmd.ExecuteNonQuery();
            }

            // Tabelle leeren
            SQLiteCommand deleteCmd = new SQLiteCommand(sqliteConnection);
            deleteCmd.CommandText = "DELETE FROM Koordinaten;";
            deleteCmd.ExecuteNonQuery();
            deleteCmd.CommandText = "DELETE FROM Einstellungen;";
            deleteCmd.ExecuteNonQuery();

            // Erste Tabelle mit Koordinaten füllen und dabei Transaktion nutzen, um höhere Performance zu erreichen
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

            // Weitere Einstellungen speichern
            SQLiteCommand settingsCommand = new SQLiteCommand(sqliteConnection);
            settingsCommand.CommandText = string.Format("INSERT INTO Einstellungen (name, wert) VALUES (\"ursprung_x\", \"{0}\");", Ursprung.X);
            settingsCommand.ExecuteNonQuery();
            settingsCommand.CommandText = string.Format("INSERT INTO Einstellungen (name, wert) VALUES (\"ursprung_y\", \"{0}\");", Ursprung.Y);
            settingsCommand.ExecuteNonQuery();

            // Fertig
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

        private Koordinate ursprung = new Koordinate(0, 0, 0);

        public Koordinate Ursprung
        {
            get { return ursprung; }
            set { ursprung = value; }
        }

        // Liefert die gesamte Zeichendauer der einzelnen Koordinaten zurück
        public int ErmittleGesamtzeit()
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
                            // Soll ein Punkt innerhalb einer Linie gelöscht werden, dann soll die Linie in zwei Teile aufgeteilt werden
                            if (k != 0 && k != this[i].Count - 1)
                            {
                                // Es soll in einer Linie gelöscht werden. Diese einfach aufteilen
                                Linie linie = new Linie();
                                for (int l = this[i].Count - 1; l > k; l--)
                                {
                                    linie.Add(this[i][l]);
                                    this[i].RemoveAt(l);
                                }

                                // Neue Linie hinter dieser einfügen
                                this.Insert(i + 1, linie);
                                break;
                            }

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
