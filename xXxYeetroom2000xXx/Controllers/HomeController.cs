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
    /// <summary>
    /// A controller is responsible for controlling the way that a user interacts with an MVC application. It contains logic to produce input- and output-data by communicating bidirectional with the view- and the model-layer.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Reference to field of DbContext.
        /// </summary>
        private readonly YeetroomContext _db;

        /// <summary>
        /// Transition Object between the "Post"-entity of DbContext and the corresponding list-typed value of ViewBag
        /// </summary>
        public List<Post> Posts { get; set; }
        /// <summary>
        /// Transition Object between the "Kommentar"-entity of DbContext and the corresponding list-typed value of ViewBag
        /// </summary>
        public List<Kommentar> Kommentare { get; set; }
        /// <summary>
        /// This applications only controller (in general: given applications main controller).
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="db"></param>
        public HomeController(ILogger<HomeController> logger, YeetroomContext db)
        {
            _db = db;
            _logger = logger;
        }

        /// <summary>
        /// Method called when the routings destination is "Index"(also: default routing destination)
        /// </summary>
        /// <returns>
        /// Instance of ViewResult
        /// </returns>
        public IActionResult Index() // Identifier same as corresponding views filename.
        {

            // ViewBag is a wrapper for ViewData. ViewData is a dicionary with string keys and generic values, 
            // which by default gets initialized when the controller gets activated. 
            // The purpose of ViewData is to transfer data from a given controller to a corresponding view.
            ViewBag.Posts = sortedPosts(_db.Post.ToList<Post>());
            ViewBag.Kommentare = _db.Kommentar.ToList<Kommentar>();

            return View();
        }

        /// <summary>
        /// Adds kommentar as entity to corresponding DbSet, saves changes to database and loads Index if changed model status is valid to commit. Otherwise only loads Index.
        /// </summary>
        /// <param name="kommentar"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult CreatePost()
        {
            return View();
        }

        /// <summary>
        /// Adds post as entity to corresponding DbSet, saves changes to database and loads Index if changed model status is valid to commit. Otherwise only loads Index.
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Processes handling of occuring errors.
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Method to order posts descending by date (bubble sort).
        /// </summary>
        /// <param name="posts"></param>
        /// <returns></returns>
        private List<Post> sortedPosts(List<Post> posts)
        {
            var sortedPosts = posts.ToList();

            for (int i = 0; i < posts.Count; i++)
            {
                for (int j = 0; j < posts.Count - 1; j++)
                {
                    if (sortedPosts[j].Datum < sortedPosts[j + 1].Datum)
                    {
                        var tempPost = sortedPosts[j + 1];
                        sortedPosts[j + 1] = sortedPosts[j];
                        sortedPosts[j] = tempPost;
                    }
                }
            }

            return sortedPosts;
        }
    }
}
