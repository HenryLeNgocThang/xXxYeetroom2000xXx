using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xXxYeetroom2000xXx.Models;
using xXxYeetroom2000xXx.Data;

namespace xXxYeetroom2000xXx.Controllers
{
    public class Yeetroom2000Controller : Controller
    {
        private readonly YeetroomContext _db;
        public List<Post> Posts { get; set; }
        public List<Kommentar> Kommentare { get; set; }
        public IActionResult Index(YeetroomContext db)
        {
            //_db = db;
            //Viewbag hinzufügen
            ViewBag.Posts = _db.Forumeinträge.ToList<Post>();
            ViewBag.Kommentare = _db.Kommentar.ToList<Kommentar>();

            return View();
        }

        //private List<Post> GetPosts()
        //{
        //    return new List<Post>()
        //    {
        //        new Post(){ID = 0, Verfasser = "Damian", Eintrag = "Marcel stinkt!", Datum = DateTime.Now },
        //        new Post(){ID = 1, Verfasser = "Marcel", Eintrag = "Damian stinkt!", Datum = DateTime.Now.AddMinutes(1) }
        //    };
        //}

        //private List<Kommentar> GetKommentare()
        //{
        //    return new List<Kommentar>()
        //    {
        //        new Kommentar(){ID = 0, Verfasser = "Damian", Post_ID = 1, Eintrag = "Selber du Arschloch!", Datum = DateTime.Now },
        //        new Kommentar(){ID = 1, Verfasser = "Marcel", Post_ID = 0, Eintrag = "Selber du doppel-Arschloch!", Datum = DateTime.Now.AddMinutes(1) }
        //    };
        //}
    }
}
