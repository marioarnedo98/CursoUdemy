﻿
using CursoUdemy.Domain.Common;

namespace CursoUdemy.Domain
{
    public class Streamer : BaseDomainModel
    {
        public string? Nombre { get; set; }

        public string? Url { get; set; }

        public ICollection<Video>? Videos { get; set; }
    }
}
