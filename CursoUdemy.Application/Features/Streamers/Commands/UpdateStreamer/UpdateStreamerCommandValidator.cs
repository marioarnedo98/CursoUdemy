
using FluentValidation;

namespace CursoUdemy.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandValidator : AbstractValidator<UpdateStreamerCommand>
    {
        public UpdateStreamerCommandValidator()
        {
            RuleFor(p => p.Nombre).NotNull().WithMessage("El valor {Nombre} no puede ser nulo");
            RuleFor(p => p.Url).NotNull().WithMessage("El valor {Url} no puede ser nulo");
        }
    }
}
