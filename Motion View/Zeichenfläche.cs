using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Motion_Model;

namespace Motion_View
{
    public partial class Zeichenfläche : UserControl
    {
        #region Fixe Werte
        private static readonly int PunktDurchmesser = 5;       // Durchmesser für gezeichnete Punkte

        private static readonly int Loeschhoehe = 15;           // Breite des zu löschenden Rechtecks im Löschmodus
        private static readonly int Loeschbreite = 15;          // Höhe des zu löschenden Rechtecks im Löschmodus

        private static readonly int Verbindungshoehe = 25;      // Breite des bei Linienverbindungen benutzten Rechtecks zur Ermittlung der naheliegenden Punkte
        private static readonly int Verbindungsbreite = 25;     // Breite des bei Linienverbindungen benutzten Rechtecks zur Ermittlung der naheliegenden Punkte
        #endregion

        public Zeichenfläche()
        {
            InitializeComponent();
        }

        private void Zeichenfläche_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;

            datei.CollectionChanged += Datei_CollectionChanged;
            stoppuhr = new Stopwatch();     // Zum Messen der zeitlichen Dimension beim Zeichnen
        }

        #region Zustand des Controls
        public enum Modus
        {
            Bewegemodus,        // Der gesamte Sketch kann bewegt werden
            Zeichenmodus,       // Neue Bewegungen können aufgezeichnet werden
            Loeschmodus,        // Bereits eingegebene Bewegungen können per Radiergummi gelöscht werden
            Wiedergabemodus,     // Bereits eingegebene Bewegungen werden abgespielt
            Ursprungsmodus      // Ursprung kann per Klick definiert werden
        }

        private Modus aktuellerModus = Modus.Zeichenmodus;
        public Modus ControlModus
        {
            get
            {
                return aktuellerModus;
            }

            set
            {
                // Hat sich der Modus überhaupt verändert?
                if (aktuellerModus == value)
                {
                    // Nein - hier stoppen
                    return;
                }

                // Control vor dem Setzen des neuen Modus prüfen und ggf. zurücksetzen
                switch (ControlModus)
                {
                    case Modus.Bewegemodus:
                    case Modus.Loeschmodus:
                        Cursor = Cursors.Default;
                        break;

                    case Modus.Wiedergabemodus:
                        if (modusAktiv)
                        {
                            WiedergabeStoppen();
                        }
                        break;
                }

                // Erst dann neuen Modus anwenden
                switch (value)
                {
                    case Modus.Bewegemodus:
                        Cursor = Cursors.SizeAll;
                        break;

                    case Modus.Loeschmodus:
                        Cursor = new Cursor(new MemoryStream(Motion_View.Properties.Resources.gummi));
                        break;

                    case Modus.Wiedergabemodus:
                        akkumulierteZeitTotal = 0;
                        numWiedergegebeneLinien = 0;
                        break;
                }

                Modus alterModus = aktuellerModus;
                aktuellerModus = value;
                ModusGeaendert?.Invoke(this, alterModus, value);
            }
        }
        private bool modusAktiv;                                // Ist der gewählte Modus gerade aktiv?

        private Point zeichnungOffset = new Point(0, 0);        // Alle Koordinaten werden um dieses Offset verschoben gezeichnet bzw. aufgenommen

        private Point bewegenStartOffset;                       // Enthält das Zeichnungsoffset, welches beim Mausklick gesetzt war
        private Point bewegenStartKoordinate;                   // Enthält die Koordinaten des Mausklicks während die Zeichnung bewegt wird

        private Point ursprungKoordinate;

        public delegate void ModusGeaendertEvent(object sender, Modus alterModus, Modus neuerModus);
        public event ModusGeaendertEvent ModusGeaendert;
        #endregion

        #region Bindung an die Dateikomponente
        private Datei datei = new Datei();                      // Darf nie null werden

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Datei Datei
        {
            get
            {
                return datei;
            }

            set
            {
                if (value == null)
                {
                    // Wir benötigen stets eine valide Instanz der Dateiklasse...
                    throw new ArgumentNullException();
                }
                if (value == datei)
                {
                    // Ignorieren wenn die Datei identisch ist
                    return;
                }

                Datei alteDatei = datei;
                datei = value;
                zeichnungOffset.X = zeichnungOffset.Y = 0;
                Invalidate();

                alteDatei.CollectionChanged -= Datei_CollectionChanged;
                datei.CollectionChanged += Datei_CollectionChanged;

                DateiGeaendert?.Invoke(this, alteDatei, datei);
            }
        }

        private void Datei_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Bei Änderungen der Datei soll das Control neu gezeichnet werden...
            Invalidate();
        }

        public delegate void DateiGeaendertEvent(object sender, Datei alteDatei, Datei neueDatei);
        public event DateiGeaendertEvent DateiGeaendert;
        #endregion

        #region Events zum Einspeichern von Bewegungen per Touch und per Maus
        private Stopwatch stoppuhr;                 // Zum Erfassen der Zeit zwischen den einzelnen Punkten
        private Linie zeichnendeLinie;              // Welche Linie wird gerade gezeichnet?

        // Event wird ausgelöst wenn die Maus gedrückt wird (quasi initial-zündung)
        private void Zeichenfläche_MouseDown(object sender, MouseEventArgs e)
        {
            if (ControlModus == Modus.Bewegemodus)
            {
                bewegenStartOffset = zeichnungOffset;
                bewegenStartKoordinate = e.Location;
                modusAktiv = true;
            }
            else if (ControlModus == Modus.Zeichenmodus)
            {
                // Neue Linie anlegen
                zeichnendeLinie = new Linie();
                datei.Add(zeichnendeLinie);

                // Zeichenmodus effektiv aktivieren
                stoppuhr.Start();
                modusAktiv = true;

                // Ersten Punkt an dieser Koordinate anlegen
                Zeichenfläche_MouseMove(this, e);
            }
            else if (ControlModus == Modus.Loeschmodus || ControlModus == Modus.Ursprungsmodus)
            {
                modusAktiv = true;
            }
        }

        // Event wird ausgelöst wenn die Maus losgelassen wird
        private void Zeichenfläche_MouseUp(object sender, MouseEventArgs e)
        {
            if (modusAktiv)
            {
                if (ControlModus == Modus.Zeichenmodus)
                {
                    // Prüfen ob der Endpunkt der Linie mit dem Startpunkt einer anderen Linie verbunden werden kann
                    foreach(Koordinate koordinate in datei.ErmittleRandpunkteBei(e.X - zeichnungOffset.X, e.Y - zeichnungOffset.Y, Verbindungsbreite, Verbindungshoehe))
                    {
                        if (koordinate.IstStartpunkt && koordinate.Linie != zeichnendeLinie)
                        {
                            if (MessageBox.Show(String.Format("Möchten Sie die gezeichnete Linie mit der Linie {0} beim Endpunkt zusammenführen?", datei.IndexOf(koordinate.Linie) + 1),
                                Application.ProductName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                var linie = koordinate.Linie;
                                zeichnendeLinie.LinieAnhängen(linie);
                                datei.Remove(linie);
                                break;
                            }
                        }
                    }

                    // Prüfen ob der Startpunkt der Linie mit dem Endpunkt einer anderen Linie verbunden werden kann
                    foreach(Koordinate koordinate in datei.ErmittleRandpunkteBei(zeichnendeLinie[0].X, zeichnendeLinie[0].Y, Verbindungsbreite, Verbindungshoehe))
                    {
                        if (koordinate.IstEndpunkt && koordinate.Linie != zeichnendeLinie)
                        {
                            if (MessageBox.Show(String.Format("Möchten Sie die gezeichnete Linie mit der Linie {0} beim Startpunkt zusammenführen?", datei.IndexOf(koordinate.Linie) + 1),
                                Application.ProductName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                koordinate.Linie.LinieAnhängen(zeichnendeLinie);
                                datei.Remove(zeichnendeLinie);
                                break;
                            }
                        }
                    }
                }
                else if (ControlModus == Modus.Ursprungsmodus)
                {
                    // Ursprung der Datei definieren
                    datei.Ursprung.X = ursprungKoordinate.X - zeichnungOffset.X;
                    datei.Ursprung.Y = ursprungKoordinate.Y - zeichnungOffset.Y;

                    ControlModus = Modus.Zeichenmodus;
                    Invalidate();
                }

                stoppuhr.Reset();
                zeichnendeLinie = null;
                modusAktiv = false;
            }
        }

        // Event wird ausgelöst, wenn die Maus bewegt wird oder wenn eine neue Koordinate aufgenommen werden soll
        private void Zeichenfläche_MouseMove(object sender, MouseEventArgs e)
        {
            // Wir können nur reagieren, wenn die Maus oder der Touch-Controller aktiviert wurde...
            if (!modusAktiv)
            {
                return;
            }

            // In welchem Modus befindet sich das Control?
            switch (ControlModus)
            {
                case Modus.Bewegemodus:
                    // Neues Offset für Zeichnung setzen und Control neu zeichnen
                    if (modusAktiv)
                    {
                        zeichnungOffset.X = bewegenStartOffset.X - bewegenStartKoordinate.X + e.Location.X;
                        zeichnungOffset.Y = bewegenStartOffset.Y - bewegenStartKoordinate.Y + e.Location.Y;
                        Invalidate();
                    }
                    break;
                
                case Modus.Zeichenmodus:
                    // Ist die letzte Koordinate ungleich der aktuelle Koordinate?
                    if (zeichnendeLinie.LetzteKoordinate != e.Location)
                    {
                        // Nein - neue Koordinate erzeugen und aufnehmen
                        zeichnendeLinie.Add(new Koordinate(e.X - zeichnungOffset.X, e.Y - zeichnungOffset.Y, (int)stoppuhr.ElapsedMilliseconds));
                        stoppuhr.Restart();

                        // Neuen Block zeichnen
                        Invalidate();
                    }
                    break;

                case Modus.Loeschmodus:
                    // Der Löschmodus soll alle Punkte im enthaltenen Rechteck löschen, was von der Dateiklasse erledigt wird
                    if (datei.LoescheBei(e.X - zeichnungOffset.X, e.Y - zeichnungOffset.Y, Loeschhoehe, Loeschbreite))
                    {
                        // Aus Performancegründen wird das Control nur bei Änderungen des Inhalts neu gezeichnet
                        Invalidate();
                    }
                    break;

                case Modus.Ursprungsmodus:
                    ursprungKoordinate = e.Location;
                    Invalidate();
                    break;
            }
        }
        #endregion

        #region Wiedergabesteuerung
        private int akkumulierteZeitTotal;          // Wieviel ms sind insgesamt seit dem Wiedergabestart abgespielt worden?
        private int numWiedergegebeneLinien;        // Wieviele Linien sind schon gezeichnet worden?
        private int stoppuhrOffset;                 // Offset in ms fürs manuelle Setzen der wiedergegebenen Zeit

        public event EventHandler WiedergabeGestartet;
        public event EventHandler WiedergabeGestoppt;

        // Methode um die zeitliche Wiedergabe des eingegebenen Inhalts zu starten
        public void WiedergabeStarten()
        {
            if (ControlModus == Modus.Wiedergabemodus)
            {
                tmrZeichnen.Enabled = true;
                modusAktiv = true;

                akkumulierteZeitTotal = 0;
                numWiedergegebeneLinien = 0;
                stoppuhrOffset = 0;

                stoppuhr.Start();
                Invalidate();

                WiedergabeGestartet?.Invoke(this, new EventArgs());
            }
        }

        // Stoppt die Wiedergabe der eingegebenen Bewegungen
        public void WiedergabeStoppen()
        {
            if (ControlModus == Modus.Wiedergabemodus)
            {
                stoppuhr.Stop();
                
                tmrZeichnen.Enabled = false;
                modusAktiv = false;
                Invalidate();

                WiedergabeGestoppt?.Invoke(this, new EventArgs());
            }
        }

        // Liefert die Zeit in ms seit dem Wiedergabebeginn zurück und setzt diese bei Bedarf
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public int WiedergabeZeit
        {
            get
            {
                if (stoppuhr.IsRunning)
                {
                    return akkumulierteZeitTotal + (int)stoppuhr.ElapsedMilliseconds + stoppuhrOffset;
                }
                return akkumulierteZeitTotal;
            }

            set
            {
                // Wiedergabeparameter zurücksetzen
                akkumulierteZeitTotal = 0;
                numWiedergegebeneLinien = 0;
                stoppuhrOffset = 0;

                // Ermitteln wieviele Linien gezeichnet werden können und zeitliches Offset für die Stoppuhr ermitteln
                foreach(Linie l in datei)
                {
                    bool wiedergabeUnterbrochen = false;
                    foreach (Koordinate koord in l)
                    {
                        if (akkumulierteZeitTotal + koord.Zeit > value)
                        {
                            // Bis zu dieser Koordinate soll gezeichnet werden
                            wiedergabeUnterbrochen = true;
                            break;
                        }
                        akkumulierteZeitTotal += koord.Zeit;
                        stoppuhrOffset += koord.Zeit;
                    }

                    if (wiedergabeUnterbrochen)
                    {
                        break;
                    }

                    stoppuhrOffset = 0;
                    numWiedergegebeneLinien++;
                }

                // Werte übernehmen
                if (ControlModus == Modus.Wiedergabemodus)
                {
                    if (modusAktiv)
                    {
                        stoppuhr.Restart();
                    }
                    Invalidate();
                }
            }
        }

        private void tmrZeichnen_Tick(object sender, EventArgs e)
        {
            // Erneutes Zeichnen des Steuerelements erzwingen
            Invalidate();
        }
        #endregion

        #region Visualisierung des Controls

        private Pen ursprungPinsel = Pens.Aquamarine;

        public Pen UrsprungPinsel
        {
            get { return ursprungPinsel; }
            set { ursprungPinsel = value; }
        }

        private Brush punktPinsel = Brushes.Black;
        public Brush PunktPinsel
        {
            get { return punktPinsel; }
            set { punktPinsel = value; }
        }

        private Pen linienPinsel = Pens.DarkGray;
        public Pen LinienPinsel
        {
            get { return linienPinsel; }
            set { linienPinsel = value; }
        }

        // Sonderdarstellung für selektierte/markierte Linien
        private Brush markierterPunktPinsel = Brushes.Red;
        public Brush MarkierterPunktPinsel
        {
            get { return markierterPunktPinsel; }
            set { markierterPunktPinsel = value; }
        }

        private Pen markierterLinienPinsel = Pens.DarkRed;
        public Pen MarkierterLinienPinsel
        {
            get { return markierterLinienPinsel; }
            set { markierterLinienPinsel = value; }
        }

        // Eigenschaft zum Setzen von markierten Linien
        private Linie markierteLinie;
        [Browsable(false)]
        public Linie MarkierteLinie
        {
            get { return markierteLinie; }
            set
            {
                markierteLinie = value;
                Refresh();
            }
        }

        // Event wird bei Refresh aufgerufen, zeichnet entweder normal oder zeichnet im Wiedergabemodus "nach"
        private void Zeichenfläche_Paint(object sender, PaintEventArgs e)
        {
            // Optionen für den Wiedergabemodus
            int akkumulierteZeit = 0;
            int numAktuelleLinie = 0;

            // Ursprung einzeichnen
            if (ControlModus == Modus.Ursprungsmodus)
            {
                e.Graphics.DrawLine(UrsprungPinsel, ursprungKoordinate.X, 0, ursprungKoordinate.X, Height);
                e.Graphics.DrawLine(UrsprungPinsel, 0, ursprungKoordinate.Y, Width, ursprungKoordinate.Y);
            }
            else
            {
                e.Graphics.DrawLine(UrsprungPinsel, datei.Ursprung.X + zeichnungOffset.X, 0, datei.Ursprung.X + zeichnungOffset.X, Height);
                e.Graphics.DrawLine(UrsprungPinsel, 0, datei.Ursprung.Y + zeichnungOffset.Y, Width, datei.Ursprung.Y + zeichnungOffset.Y);
            }

            // Verbindungslinien zwischen den einzelnen Punkten zeichnen
            foreach (Linie l in datei)
            {
                Koordinate letzteKoordinate = null;
                foreach (Koordinate k in l)
                {
                    // Kann diese Verbindungslinie im Wiedergabemodus gezeichnet werden?
                    if (ControlModus == Modus.Wiedergabemodus)
                    {
                        if (numWiedergegebeneLinien == numAktuelleLinie)
                        {
                            if (akkumulierteZeit + k.Zeit > stoppuhr.ElapsedMilliseconds + stoppuhrOffset)
                            {
                                break;
                            }
                            else
                            {
                                akkumulierteZeit += k.Zeit;
                            }
                        }
                    }

                    if (letzteKoordinate != null)
                    {
                        // Offset anwenden
                        int x = k.X + zeichnungOffset.X;
                        int y = k.Y + zeichnungOffset.Y;
                        int letztesX = letzteKoordinate.X + zeichnungOffset.X;
                        int letztesY = letzteKoordinate.Y + zeichnungOffset.Y;

                        // Verbindungen zwischen Punkten mit grauer Linie zeichnen
                        e.Graphics.DrawLine((l == markierteLinie) ? markierterLinienPinsel : linienPinsel, letztesX, letztesY, x, y);
                    }
                    letzteKoordinate = k;
                }

                if (ControlModus == Modus.Wiedergabemodus)
                {
                    numAktuelleLinie++;

                    // Nicht mehr als bis zur aktuellen Linie zeichnen...
                    if (numAktuelleLinie > numWiedergegebeneLinien)
                    {
                        break;
                    }
                }
            }

            // Punkte zeichnen
            bool wiedergabeUnterbrochen = false;
            akkumulierteZeit = 0;
            numAktuelleLinie = 0;

            foreach (Linie l in datei)
            {
                foreach (Koordinate k in l)
                {
                    // Kann dieser Punkt im Wiedergabemodus gezeichnet werden?
                    if (ControlModus == Modus.Wiedergabemodus)
                    {
                        if (numWiedergegebeneLinien == numAktuelleLinie)
                        {
                            if (akkumulierteZeit + k.Zeit > stoppuhr.ElapsedMilliseconds + stoppuhrOffset)
                            {
                                wiedergabeUnterbrochen = true;
                                break;
                            }
                            else
                            {
                                akkumulierteZeit += k.Zeit;
                            }
                        }
                    }

                    // Offset anwenden
                    int x = k.X + zeichnungOffset.X;
                    int y = k.Y + zeichnungOffset.Y;

                    // Punkte als Kreise zeichnen
                    e.Graphics.FillEllipse((l == markierteLinie) ? markierterPunktPinsel : punktPinsel,
                        x - PunktDurchmesser / 2, y - PunktDurchmesser / 2, PunktDurchmesser, PunktDurchmesser);
                }

                if (ControlModus == Modus.Wiedergabemodus)
                {
                    if (numWiedergegebeneLinien == numAktuelleLinie && !wiedergabeUnterbrochen && modusAktiv)
                    {
                        // Aktuelle Linie konnte ohne Unterbrechung gezeichnet werden, also mit der nächsten weitermachen
                        numWiedergegebeneLinien++;
                        akkumulierteZeitTotal += akkumulierteZeit;
                        stoppuhr.Restart();
                    }
                    numAktuelleLinie++;

                    // Wenn aber die aktuelle Linie nicht komplett gezeichnet werden konnte, dann ist die Abbruchbedingung erfüllt
                    if (numAktuelleLinie > numWiedergegebeneLinien)
                    {
                        break;
                    }
                }
            }

            // Wiedergabe abgeschlossen?
            if (ControlModus == Modus.Wiedergabemodus && modusAktiv)
            {
                if (!wiedergabeUnterbrochen && numAktuelleLinie == datei.Count)
                {
                    WiedergabeStoppen();
                }
            }
        }
        #endregion
    }
}
