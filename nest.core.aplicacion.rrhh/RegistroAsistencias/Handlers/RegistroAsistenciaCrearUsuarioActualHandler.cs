using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using nest.core.dominio.Security.Tenant;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Handlers
{
    public class RegistroAsistenciaCrearUsuarioActualHandler : RegistroAsistenciaHandlerBase, IRequestHandler<RegistroAsistenciaCrearUsuarioActualCommand, RegistroAsistencia>
    {
        private readonly IConnectionStringService connectionStringService;
        private readonly IMapper mapper;
        private readonly ILogger<RegistroAsistenciaCrearUsuarioActualHandler> logger;

        public RegistroAsistenciaCrearUsuarioActualHandler(
            IRegistroAsistenciaRepository repository,
            IHorarioRepository horarioRepository,
            IPersonalRepository personalRepository,
            IHorarioDetalleRepository horarioDetalleRepository,
            IConnectionStringService connectionStringService,
            IMapper mapper,
            ILogger<RegistroAsistenciaCrearUsuarioActualHandler> logger)
            : base(repository, horarioRepository, personalRepository, horarioDetalleRepository)
        {
            this.connectionStringService = connectionStringService;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<RegistroAsistencia> Handle(RegistroAsistenciaCrearUsuarioActualCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var registro = mapper.Map<RegistroAsistencia>(request);
                Personal actual = await personalRepository.ObtenerPorIdUsuario(connectionStringService.UserId);
                if(actual == null) throw new Exception("Tienes que tener que tener un codigo de personal asignado a tu usuario.");
                registro.EmpresaId = connectionStringService.EmpresaId ?? throw new Exception("Usuario no autenticado");
                registro.PersonalId = actual.Id;
                registro.Fecha = DateTime.Now;

                registro = await PrepararRegistroAsync(registro, actual.HorarioCabecera);
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
