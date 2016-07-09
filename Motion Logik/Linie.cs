using System;
using System.Collections.ObjectModel;

namespace Motion_Model
{
    public class Linie : ObservableCollection<Koordinate>
    {
        private Koordinate letzteKoordinate;
        public Koordinate LetzteKoordinate
        {
            get { return letzteKoordinate; }
        }

        public new void Add(Koordinate item)
        {
            if (item != null)
            {
                item.linie = this;
                base.Add(item);
                letzteKoordinate = item;
            }
        }

        public void LinieAnhängen(Linie linie)
        {
            foreach (Koordinate koord in linie)
            {
                Add(koord);
            }
        }
    }
}
