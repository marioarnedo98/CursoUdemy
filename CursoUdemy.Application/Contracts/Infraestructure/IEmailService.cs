
using CursoUdemy.Application.Models;

namespace CursoUdemy.Application.Contracts.Infraestructure
{
    public interface IEmailService
    {
        Task<bool> sendEmail(Email email);
    }
}
