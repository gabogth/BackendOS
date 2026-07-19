using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Commands;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using nest.core.dominio.RRHH.TerminalBiometricoEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Handlers
{
    public class RegistroAsistenciaTerminalZKTecoCrearHandler : RegistroAsistenciaHandlerBase, IRequestHandler<RegistroAsistenciaTerminalZKTecoCrearCommand, RegistroAsistencia>
    {
        private readonly ILogger<RegistroAsistenciaTerminalZKTecoCrearHandler> logger;
        private readonly ITerminalBiometricoRepository terminalBiometricoRepository;

        public RegistroAsistenciaTerminalZKTecoCrearHandler(
            IRegistroAsistenciaRepository repository,
            IHorarioRepository horarioRepository,
            IPersonalRepository personalRepository,
            IHorarioDetalleRepository horarioDetalleRepository,
            ITerminalBiometricoRepository terminalBiometricoRepository,
            IMapper mapper,
            ILogger<RegistroAsistenciaTerminalZKTecoCrearHandler> logger)
            : base(repository, horarioRepository, personalRepository, horarioDetalleRepository)
        {
            this.logger = logger;
            this.terminalBiometricoRepository = terminalBiometricoRepository;
        }

        public async Task<RegistroAsistencia> Handle(RegistroAsistenciaTerminalZKTecoCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var personal = await personalRepository.ObtenerPorDocumentoIdentidad(request.DocumentoTipo, request.DocumentoNumero);
                var personalOk = await personalRepository.ObtenerPorId(personal.Id);
                var terminalBiometrico = await terminalBiometricoRepository.ObtenerPorSerialNumber(request.SerialNumber);
                RegistroAsistencia registro = new RegistroAsistencia
                {
                    EmpresaId = personalOk.EmpresaId,
                    Fecha = request.Fecha,
                    PersonalId = personalOk.Id,
                    TerminalBiometricoId = terminalBiometrico.Id
                };
                registro = await PrepararRegistroAsync(registro, personalOk.HorarioCabecera);
                registro = await repository.Agregar(registro);
                return await repository.ObtenerPorId(registro.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error al registrar asistencia para el personal {request.DocumentoTipo}: {request.DocumentoNumero}");
                throw;
            }
        }
    }
}
