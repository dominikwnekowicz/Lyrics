using Lyrics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lyrics.ViewModels
{
    public class LyricFormViewModel
    {
        public Lyric Lyric { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
    }
}