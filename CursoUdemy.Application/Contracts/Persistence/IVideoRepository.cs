using CursoUdemy.Domain;

namespace CursoUdemy.Application.Contracts.Persistence
{
    public interface IVideoRepository : IAsyncRepository<Video>
    {
        Task<IEnumerable<Video>> GetVideoByNombre(string nombreVideo);
    }
}
