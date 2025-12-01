using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaOrdenTrabajoEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Handlers
{
    public class RegistroAsistenciaOrdenTrabajoModificarHandler : IRequestHandler<RegistroAsistenciaOrdenTrabajoModificarCommand, RegistroAsistencia>
    {
        private readonly IRegistroAsistencia_OrdenTrabajoRepository registroAsistenciaRepository;
        private readonly IRegistroAsistenciaOrdenTrabajoRepository registroOrdenTrabajoRepository;
        private readonly IOrdenTrabajoCabeceraRepository ordenTrabajoCabeceraRepository;
        private readonly IMapper mapper;
        private readonly ILogger<RegistroAsistenciaOrdenTrabajoModificarHandler> logger;

        public RegistroAsistenciaOrdenTrabajoModificarHandler(
            IRegistroAsistencia_OrdenTrabajoRepository registroAsistenciaRepository,
            IRegistroAsistenciaOrdenTrabajoRepository registroOrdenTrabajoRepository,
            IOrdenTrabajoCabeceraRepository ordenTrabajoCabeceraRepository,
            IMapper mapper,
            ILogger<RegistroAsistenciaOrdenTrabajoModificarHandler> logger)
        {
            this.registroAsistenciaRepository = registroAsistenciaRepository;
            this.registroOrdenTrabajoRepository = registroOrdenTrabajoRepository;
            this.ordenTrabajoCabeceraRepository = ordenTrabajoCabeceraRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<RegistroAsistencia> Handle(RegistroAsistenciaOrdenTrabajoModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var registro = mapper.Map<RegistroAsistencia>(request);
                registro = await registroAsistenciaRepository.Modificar(registro);

                var ordenTrabajo = await ordenTrabajoCabeceraRepository.ObtenerPorId(request.OrdenTrabajoCabeceraId);
                var relacion = new RegistroAsistenciaOrdenTrabajo
                {
                    EmpresaId = registro.EmpresaId,
                    Id = registro.Id,
                    OrdenTrabajoCabeceraId = ordenTrabajo.Id
                };
                if (ordenTrabajo == null)
                    await registroOrdenTrabajoRepository.Agregar(relacion);
                else
                    await registroOrdenTrabajoRepository.Modificar(relacion);
                return await registroAsistenciaRepository.ObtenerPorId(registro.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al modificar la asistencia vinculada a orden de trabajo {Id}", request.Id);
                throw;
            }
        }
    }
}
