using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Commands;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using nest.core.dominio.Security.Tenant;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Handlers
{
    public class RegistroAsistenciaCrearServerDtHandler : RegistroAsistenciaHandlerBase, IRequestHandler<RegistroAsistenciaCrearServerDtCommand, RegistroAsistencia>
    {
        private readonly IMapper mapper;
        private readonly ILogger<RegistroAsistenciaCrearUsuarioActualHandler> logger;

        public RegistroAsistenciaCrearServerDtHandler(
            IRegistroAsistenciaRepository repository,
            IHorarioRepository horarioRepository,
            IPersonalRepository personalRepository,
            IHorarioDetalleRepository horarioDetalleRepository,
            IConnectionStringService connectionStringService,
            IMapper mapper,
            ILogger<RegistroAsistenciaCrearUsuarioActualHandler> logger)
            : base(repository, horarioRepository, personalRepository, horarioDetalleRepository)
        {
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<RegistroAsistencia> Handle(RegistroAsistenciaCrearServerDtCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var registro = mapper.Map<RegistroAsistencia>(request);
                registro.Fecha = DateTime.Now;
                var personal = await personalRepository.ObtenerPorId(request.PersonalId);
                registro = await PrepararRegistroAsync(registro, personal.HorarioCabecera);
                registro = await repository.Agregar(registro);
                return await repository.ObtenerPorId(registro.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al registrar asistencia para el usuario actual");
                throw;
            }
        }
    }
}
