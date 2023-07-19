﻿
using AutoMapper;
using CursoUdemy.Application.Features.Videos.Queries.GetVideosList;
using CursoUdemy.Domain;

namespace CursoUdemy.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Video, VideosVm>();
        }
    }
}
