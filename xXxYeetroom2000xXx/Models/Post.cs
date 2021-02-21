﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xXxYeetroom2000xXx.Models
{
    /// <summary>
    /// Represents model of the "Post"-table in the database. Instances are used for operating on the data before commiting the data to the database. Types and identifiers of the properties/fields have to match the columns to allow proper transfer from model to database.
    /// </summary>
    public class Post
    {
        public int ID { get; set; } 
        public string Verfasser { get; set; }
        public DateTime Datum { get; set; }
        public string Eintrag { get; set; }
        public string Link { get; set; }
    }
}
