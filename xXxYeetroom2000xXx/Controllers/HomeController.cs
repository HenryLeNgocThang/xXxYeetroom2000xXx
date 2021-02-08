using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using xXxYeetroom2000xXx.Models;
using xXxYeetroom2000xXx.Data;

namespace xXxYeetroom2000xXx.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly YeetroomContext _db;

        public List<Post> Posts { get; set; }
        public List<Kommentar> Kommentare { get; set; }
        public HomeController(ILogger<HomeController> logger, YeetroomContext db)
        {
            _db = db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Posts = _db.Post.ToList<Post>();
            ViewBag.Kommentare = _db.Kommentar.ToList<Kommentar>();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateKommentar([Bind("Verfasser,Eintrag,Post_ID")] Kommentar kommentar)
        {
            if (ModelState.IsValid)
            {
                _db.Add(kommentar);
                if (kommentar.Eintrag == null)
                {
                    kommentar.Eintrag = "";
                }
                if (kommentar.Verfasser == null)
                {
                    kommentar.Verfasser = "Anonym";
                }
                kommentar.Datum = DateTime.Now;
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost([Bind("Verfasser,Eintrag,Link")] Post post)
        {
            if (ModelState.IsValid)
            {
                _db.Add(post);
                if(post.Link == null)
                {
                    post.Link = "";
                }
                if(post.Eintrag == null)
                {
                    post.Eintrag = "";
                }
                if(post.Verfasser == null)
                {
                    post.Verfasser = "Anonym";
                }
                post.Datum = DateTime.Now;
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
