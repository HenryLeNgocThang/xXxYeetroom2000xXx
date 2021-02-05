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
            ViewBag.Posts = _db.Forumeinträge.ToList<Post>();
            ViewBag.Kommentare = _db.Kommentar.ToList<Kommentar>();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
