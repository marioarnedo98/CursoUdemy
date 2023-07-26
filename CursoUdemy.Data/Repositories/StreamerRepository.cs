using CursoUdemy.Application.Contracts.Persistence;
using CursoUdemy.Domain;
using CursoUdemy.Infraestructure.Persistence;

namespace CursoUdemy.Infraestructure.Repositories
{
    public class StreamerRepository : RepositoryBase<Streamer>, IStreamerRepository
    {
        public StreamerRepository(StreamerDbContext context):base(context) { }
    }
}
