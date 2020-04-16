using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lyrics.Models
{
    public class Lyric
    {
        [Required]
        public int Id { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Title { get; set; }
    }
}