using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Commands;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Handlers
{
    public class RegistroAsistenciaCrearHandler : RegistroAsistenciaHandlerBase, IRequestHandler<RegistroAsistenciaCrearCommand, RegistroAsistencia>
    {
        private readonly IMapper mapper;
        private readonly ILogger<RegistroAsistenciaCrearHandler> logger;

        public RegistroAsistenciaCrearHandler(
            IRegistroAsistenciaRepository repository,
            IHorarioRepository horarioRepository,
            IPersonalRepository personalRepository,
            IHorarioDetalleRepository horarioDetalleRepository,
            IMapper mapper,
            ILogger<RegistroAsistenciaCrearHandler> logger)
            : base(repository, horarioRepository, personalRepository, horarioDetalleRepository)
        {
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<RegistroAsistencia> Handle(RegistroAsistenciaCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var registro = mapper.Map<RegistroAsistencia>(request);
                registro = await PrepararRegistroAsync(registro);
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
