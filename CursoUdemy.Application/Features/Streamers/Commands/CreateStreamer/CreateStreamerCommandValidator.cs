using FluentValidation;

namespace CursoUdemy.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandValidator : AbstractValidator<CreateStreamerCommand>
    {
        public CreateStreamerCommandValidator()
        {
            RuleFor(p => p.Nombre).NotEmpty().WithMessage("{Nombre} no puede estar en blanco").NotNull().MaximumLength(50).WithMessage("{Nombre} no puede ser mayor de 50 caracteres");

            RuleFor(p => p.Url).NotEmpty().WithMessage("{Url} no puede ir vacío");

        }
    }
}
