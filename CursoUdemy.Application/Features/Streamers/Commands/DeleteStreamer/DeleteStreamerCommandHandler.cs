

using AutoMapper;
using CursoUdemy.Application.Contracts.Persistence;
using CursoUdemy.Application.Exceptions;
using CursoUdemy.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CursoUdemy.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandHandler : IRequestHandler<DeleteStreamerCommand>
    {

        private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteStreamerCommandHandler> _logger;

        public DeleteStreamerCommandHandler(IStreamerRepository streamerRepository, IMapper mapper, ILogger<DeleteStreamerCommandHandler> logger)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(DeleteStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerToDelete = await _streamerRepository.GetByIdAsync(request.Id);

            if (streamerToDelete == null) {
                _logger.LogError($"El id {request.Id} no existe");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }
            
            await _streamerRepository.DeleteAsync(streamerToDelete);
            _logger.LogInformation($"El {request.Id} fue borrar con exito");


        }
    }
}
