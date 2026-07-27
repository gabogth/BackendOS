using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Commands;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Services.Interface;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Handlers
{
    public class RegistroAsistenciaCrearHandler : IRequestHandler<RegistroAsistenciaCrearCommand, RegistroAsistencia>
    {
        private readonly IRegistroAsistenciaRepository repository;
        private readonly IPersonalRepository personalRepository;
        private readonly IMarcacionCalculoService calculoService;
        private readonly IMapper mapper;
        private readonly ILogger<RegistroAsistenciaCrearHandler> logger;

        public RegistroAsistenciaCrearHandler(
            IRegistroAsistenciaRepository repository,
            IPersonalRepository personalRepository,
            IMarcacionCalculoService calculoService,
            IMapper mapper,
            ILogger<RegistroAsistenciaCrearHandler> logger)
        {
            this.repository = repository;
            this.personalRepository = personalRepository;
            this.calculoService = calculoService;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<RegistroAsistencia> Handle(RegistroAsistenciaCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var registro = mapper.Map<RegistroAsistencia>(request);
                var personal = await personalRepository.ObtenerPorId(request.PersonalId);
                registro = await calculoService.PrepararRegistroAsync(registro, personal.HorarioCabecera);
                registro = await repository.Agregar(registro);
                return await repository.ObtenerPorId(registro.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al registrar asistencia para el personal {PersonalId}", request.PersonalId);
                throw;
            }
        }
    }
}
