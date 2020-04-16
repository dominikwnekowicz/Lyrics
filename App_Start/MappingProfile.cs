using AutoMapper;
using Lyrics.Dtos;
using Lyrics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lyrics.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Lyric, LyricDto>();
            Mapper.CreateMap<LyricDto, Lyric>();
        }
    }
}