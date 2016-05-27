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
        #region Fixe Werte
        private static readonly int PunktDurchmesser = 5;   // Durchmesser für gezeichnete Punkte

        private static readonly int Loeschhoehe = 5;        // Breite des zu löschenden Rechtecks im Löschmodus
        private static readonly int Loeschbreite = 6;       // Höhe des zu löschenden Rechtecks im Löschmodus
        #endregion

        public Zeichenfläche()
        {
            InitializeComponent();
        }

        private void Zeichenfläche_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;

            datei = new Datei();            // datei darf nie null werden
            datei.CollectionChanged += Datei_CollectionChanged;
            stoppuhr = new Stopwatch();     // Zum Messen der zeitlichen Dimension beim Zeichnen
        }

        #region Zustand des Controls
        public enum Modus
        {
            Zeichenmodus,       // Neue Bewegungen können aufgezeichnet werden
            Loeschmodus,        // Bereits eingegebene Bewegungen können per Radiergummi gelöscht werden
            Wiedergabemodus     // Bereits eingegebene Bewegungen werden abgespielt
        }

        private Modus aktuellerModus;
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
                    case Modus.Loeschmodus:
                        Cursor = new Cursor(GetType(), "Resources.gummi.cur");
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
        private bool modusAktiv;     // Ist der gewählte Modus gerade aktiv?

        public delegate void ModusGeaendertEvent(object sender, Modus alterModus, Modus neuerModus);
        public event ModusGeaendertEvent ModusGeaendert;
        #endregion

        #region Bindung an die Dateikomponente
        private Datei datei;
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
                Refresh();

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
            if (ControlModus == Modus.Zeichenmodus)
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
            else if (ControlModus == Modus.Loeschmodus)
            {
                modusAktiv = true;
            }
        }

        // Event wird ausgelöst wenn die Maus losgelassen wird
        private void Zeichenfläche_MouseUp(object sender, MouseEventArgs e)
        {
            if (modusAktiv)
            {
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
                case Modus.Zeichenmodus:
                    // Ist die letzte Koordinate ungleich der aktuelle Koordinate?
                    if (zeichnendeLinie.LetzteKoordinate != e.Location)
                    {
                        // Nein - neue Koordinate erzeugen und aufnehmen
                        zeichnendeLinie.Add(new Koordinate(e.X, e.Y, (int)stoppuhr.ElapsedMilliseconds));
                        stoppuhr.Restart();

                        // Neuen Block zeichnen
                        Invalidate();
                    }
                    break;

                case Modus.Loeschmodus:
                    // Der Löschmodus soll alle Punkte im enthaltenen Rechteck löschen, was von der Dateiklasse erledigt wird
                    if (datei.LoescheBei(e.X, e.Y, Loeschhoehe, Loeschbreite))
                    {
                        // Aus Performancegründen wird das Control nur bei Änderungen des Inhalts neu gezeichnet
                        Invalidate();
                    }
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
        // Standarddarstellung der Punkte
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

            // Verbindungslinien zwischen den einzelnen Punkten zeichnen
            Koordinate letzteKoordinate;
            foreach (Linie l in datei)
            {
                letzteKoordinate = null;
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

                    // Verbindungen zwischen Punkten mit grauer Linie zeichnen
                    if (letzteKoordinate != null)
                    {
                        e.Graphics.DrawLine((l == markierteLinie) ? markierterLinienPinsel : linienPinsel, letzteKoordinate.X, letzteKoordinate.Y, k.X, k.Y);
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

                    // Punkte als Kreise zeichnen
                    e.Graphics.FillEllipse((l == markierteLinie) ? markierterPunktPinsel : punktPinsel,
                        k.X - PunktDurchmesser / 2, k.Y - PunktDurchmesser / 2, PunktDurchmesser, PunktDurchmesser);
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
