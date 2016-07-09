using System.Collections;
using System.Drawing;

namespace Motion_Model
{
    public class Koordinate
    {
        internal Linie linie;       // Referenz auf die Linie, die diese Koordinate (ggf.) enthält

        public int X;               // X-Koordinate
        public int Y;               // Y-Koordinate
        public int Zeit;            // Dauer der Bewegung vom letzten Punkt aus gesehen in ms

        public Linie Linie
        {
            get { return linie; }
        }

        public bool IstEndpunkt
        {
            get { return (linie != null && linie.LetzteKoordinate == this); }
        }

        public bool IstStartpunkt
        {
            get { return (linie != null && linie.Count > 0 && linie[0] == this); }
        }

        public Koordinate(int x, int y, int zeit)
        {
            X = x;
            Y = y;
            Zeit = zeit;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Koordinate))
            {
                return false;
            }

            Koordinate other = (Koordinate)obj;
            return other == this;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Zeit.GetHashCode();
        }

        public static bool operator ==(Koordinate a, Koordinate b)
        {
            if ((object)a == null && (object)b == null)
            {
                return true;
            }
            if ((object)a == null || (object)b == null)
            {
                return false;
            }
            return (a.X == b.X && a.Y == b.Y && a.Zeit == b.Zeit);
        }

        public static bool operator !=(Koordinate a, Koordinate b)
        {
            return !(a == b);
        }

        public static bool operator ==(Koordinate a, Point b)
        {
            if ((object)a == null && (object)b == null)
            {
                return true;
            }
            if ((object)a == null || (object)b == null)
            {
                return false;
            }
            return (a.X == b.X && a.Y == b.Y);
        }
        
        public static bool operator !=(Koordinate a, Point b)
        {
            return !(a == b);
        }
    }
}
