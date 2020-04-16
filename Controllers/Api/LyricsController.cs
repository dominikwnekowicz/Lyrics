using AutoMapper;
using Lyrics.Dtos;
using Lyrics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lyrics.Controllers.Api
{
    public class LyricsController : ApiController
    {
        private ApplicationDbContext _context;

        public LyricsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/lyrics
        public IHttpActionResult GetLyrics()
        {
            var lyricDtos = _context.Lyrics.ToList().Select(Mapper.Map<Lyric, LyricDto>);

            return Ok(lyricDtos);
        }

        // GET /api/lyrics/1
        public IHttpActionResult GetLyric(int id)
        {
            var lyric = _context.Lyrics.SingleOrDefault(c => c.Id == id);

            if (lyric == null)
                return NotFound();

            return Ok(Mapper.Map<Lyric, LyricDto>(lyric));
        }

        // POST /api/lyrics
        [HttpPost]
        public IHttpActionResult CreateLyric(LyricDto lyricDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var lyric = Mapper.Map<LyricDto, Lyric>(lyricDto);
            _context.Lyrics.Add(lyric);
            _context.SaveChanges();

            lyricDto.Id = lyric.Id;
            return Created(new Uri(Request.RequestUri + "/" + lyric.Id), lyricDto);
        }

        // PUT /api/lyrics/1
        [HttpPut]
        public IHttpActionResult UpdateLyric(int id, LyricDto lyricDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var lyricInDb = _context.Lyrics.SingleOrDefault(c => c.Id == id);

            if (lyricInDb == null)
                return NotFound();

            Mapper.Map(lyricDto, lyricInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/lyrics/1
        [HttpDelete]
        public IHttpActionResult DeleteLyric(int id)
        {
            var lyricInDb = _context.Lyrics.SingleOrDefault(c => c.Id == id);

            if (lyricInDb == null)
                return NotFound();

            _context.Lyrics.Remove(lyricInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}