﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using xXxYeetroom2000xXx.Models;
using xXxYeetroom2000xXx.Data;
using System.Text.RegularExpressions;

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

        public IActionResult Index() // Methodenname == Viewname
        {
            // ViewBag == beutel für Daten | ViewBag ist nur für "Index"
            ViewBag.Posts = sortedPosts(_db.Post.ToList<Post>());
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
                } else
                {
                    post.Link = ConvertYoutubeLinkToEmbeddedLink(post.Link);
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

        private string ConvertYoutubeLinkToEmbeddedLink(string uri)
        {
            string YoutubeLinkRegex = "(?:.+?)?(?:\\/v\\/|watch\\/|\\?v=|\\&v=|youtu\\.be\\/|\\/v=|^youtu\\.be\\/)([a-zA-Z0-9_-]{11})+";
            Regex regexExtractId = new Regex(YoutubeLinkRegex, RegexOptions.Compiled);
            string[] validAuthorities = { "youtube.com", "www.youtube.com", "youtu.be", "www.youtu.be" };

            try
            {
                string authority = new UriBuilder(uri).Uri.Authority.ToLower();
                string embedLink = "https://www.youtube.com/embed/";

                // Check if the url is a youtube url
                if (validAuthorities.Contains(authority))
                {
                    // Extract the id
                    var regRes = regexExtractId.Match(uri);
                    if (regRes.Success)
                    {
                        // Return new embed link
                        return embedLink + regRes.Groups[1].Value;
                    }
                } else
                {
                    return uri;
                }
            }
            catch { }

            return null;
        }
    }
}
