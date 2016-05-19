using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motion_Teach_In
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
