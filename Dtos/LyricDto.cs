using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lyrics.Dtos
{
    public class LyricDto
    {
        public int Id { get; set; }

        public int GenreId { get; set; }

        public string Text { get; set; }

        public string Title { get; set; }
    }
}