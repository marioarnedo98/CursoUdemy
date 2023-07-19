﻿using MediatR;

namespace CursoUdemy.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideosListQuery : IRequest<List<VideosVm>>
    {
        public string _Username { get; set; } = string.Empty;

        public GetVideosListQuery(string username) {
            _Username = username ?? throw new ArgumentNullException(nameof(username));
        }
    }
}
