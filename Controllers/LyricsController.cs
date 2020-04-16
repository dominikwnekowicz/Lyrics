using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lyrics.Models;
using Lyrics.ViewModels;

namespace Lyrics.Controllers
{
    public class LyricsController : Controller
    {
        private ApplicationDbContext _context;

        public LyricsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Lyrics
        public ActionResult Index()
        {
            var lyrics = _context.Lyrics.ToList();

            return View(lyrics);
        }

        public ActionResult New()
        {
            var viewModel = new LyricFormViewModel
            {
                Genres = _context.Genres.ToList().OrderBy(g => g.Name)
            };

            return View("LyricForm", viewModel);
        }

        [HttpPost]
        public ActionResult Comment(Comment comment)
        {
            return null;
        }

        [HttpPost]
        public ActionResult Save(Lyric lyric)
        {
            try
            {
                var lyricInDb = _context.Lyrics.Single(l => l.Id == lyric.Id);

                lyricInDb.Title = lyric.Title;
                lyricInDb.Text = lyric.Text;
            }
            catch
            {
                _context.Lyrics.Add(lyric);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Lyrics");
        }

        public ActionResult Details(int id)
        {
            var lyric = _context.Lyrics.Single(l => l.Id == id);

            return View(lyric);
        }
    }
}