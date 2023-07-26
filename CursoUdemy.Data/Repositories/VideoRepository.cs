using CursoUdemy.Application.Contracts.Persistence;
using CursoUdemy.Domain;
using CursoUdemy.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CursoUdemy.Infraestructure.Repositories
{
    internal class VideoRepository : RepositoryBase<Video>, IVideoRepository
    {
        public VideoRepository(StreamerDbContext context) : base(context)
        {

        }
        public async Task<Video> GetVideoByNombre(string nombreVideo)
        {
            return await _context.Videos!.Where(v => v.Nombre == nombreVideo).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Video>> GetVideoByUsername(string username)
        {
            return  await _context.Videos!.Where(v => v.CreatedBy == username).ToListAsync();
        }
    }
}
