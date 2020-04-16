using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lyrics.Models
{
    public class Comment
    {
        [Required]
        public int Id { get; set; }

        public Lyric Lyric { get; set; }

        [Required]
        public int LyricId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }
    }
}