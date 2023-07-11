using CursoUdemy.Domain.Common;

namespace CursoUdemy.Domain
{
    public class Director : BaseDomainModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
