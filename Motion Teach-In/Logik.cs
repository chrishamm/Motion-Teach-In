using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace Motion_Teach_In
{
    

    class Logik
    {
        public static void erzeuge_DB()
        {
            SQLiteConnection.CreateFile("Datenbank.sqlite");
        }
    }

}
