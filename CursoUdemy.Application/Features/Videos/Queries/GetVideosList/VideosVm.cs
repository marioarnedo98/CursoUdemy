using CursoUdemy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoUdemy.Application.Features.Videos.Queries.GetVideosList
{
    public class VideosVm
    {
        public string? Nombre { get; set; }

        public int StreamerId { get; set; }
    }
}
