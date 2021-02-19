using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xXxYeetroom2000xXx.Models
{
    public class Kommentar //Tabelle Kommentar
    {
        //Eigenschaften haben den selben Namen wie die Spalten in der DB
        public int ID { get; set; }
        public int Post_ID { get; set; }
        public string Verfasser { get; set; }
        public DateTime Datum { get; set; }
        public string Eintrag { get; set; }

    }
}
