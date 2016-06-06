using System.Collections.ObjectModel;

namespace Motion_Model
{
    public class Linie : ObservableCollection<Koordinate>
    {
        private Koordinate letzteKoordinate;
        public Koordinate LetzteKoordinate
        {
            get
            {
                return letzteKoordinate;
            }
        }

        public new void Add(Koordinate item)
        {
            base.Add(item);
            letzteKoordinate = item;
        }
    }
}
