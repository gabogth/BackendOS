using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Commands;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Handlers
{
    public class RegistroAsistenciaModificarHandler : IRequestHandler<RegistroAsistenciaModificarCommand, RegistroAsistencia>
    {
        private readonly IRegistroAsistenciaRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<RegistroAsistenciaModificarHandler> logger;

        public RegistroAsistenciaModificarHandler(IRegistroAsistenciaRepository repository, IMapper mapper, ILogger<RegistroAsistenciaModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<RegistroAsistencia> Handle(RegistroAsistenciaModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var registro = mapper.Map<RegistroAsistencia>(request);
                registro = await repository.Modificar(registro);
                return await repository.ObtenerPorId(registro.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al modificar el registro de asistencia {Id}", request.Id);
                throw;
            }
        }
    }
}
