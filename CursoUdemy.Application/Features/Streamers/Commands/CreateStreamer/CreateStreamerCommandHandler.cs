using AutoMapper;
using CursoUdemy.Application.Contracts.Infraestructure;
using CursoUdemy.Application.Contracts.Persistence;
using CursoUdemy.Application.Models;
using CursoUdemy.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CursoUdemy.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
    {
        private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateStreamerCommandHandler> _logger;

        public CreateStreamerCommandHandler(IStreamerRepository streamerRepository, IMapper mapper, ILogger<CreateStreamerCommandHandler> logger)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerEntity = _mapper.Map<Streamer>(request);

            var newStreamer = await _streamerRepository.AddAsync(streamerEntity);
            _logger.LogInformation($"Streamer {newStreamer.Id} fue creado correctamente");

          

            return newStreamer.Id;


        }
    }
}
