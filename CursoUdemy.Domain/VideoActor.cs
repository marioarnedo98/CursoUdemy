using CursoUdemy.Domain.Common;

namespace CursoUdemy.Domain
{
    public class VideoActor : BaseDomainModel
    {
        public int VideoId { get; set; }
        public int ActorId { get; set; }
    }
}
