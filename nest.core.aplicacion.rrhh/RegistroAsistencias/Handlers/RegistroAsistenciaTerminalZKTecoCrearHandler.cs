using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Commands;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Services.Interface;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using nest.core.dominio.RRHH.TerminalBiometricoEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Handlers
{
    public class RegistroAsistenciaTerminalZKTecoCrearHandler : IRequestHandler<RegistroAsistenciaTerminalZKTecoCrearCommand, RegistroAsistencia>
    {
        private readonly IRegistroAsistenciaRepository repository;
        private readonly IPersonalRepository personalRepository;
        private readonly ITerminalBiometricoRepository terminalBiometricoRepository;
        private readonly IMarcacionCalculoService calculoService;
        private readonly ILogger<RegistroAsistenciaTerminalZKTecoCrearHandler> logger;

        public RegistroAsistenciaTerminalZKTecoCrearHandler(
            IRegistroAsistenciaRepository repository,
            IPersonalRepository personalRepository,
            ITerminalBiometricoRepository terminalBiometricoRepository,
            IMarcacionCalculoService calculoService,
            ILogger<RegistroAsistenciaTerminalZKTecoCrearHandler> logger)
        {
            this.repository = repository;
            this.personalRepository = personalRepository;
            this.terminalBiometricoRepository = terminalBiometricoRepository;
            this.calculoService = calculoService;
            this.logger = logger;
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
                registro = await calculoService.PrepararRegistroAsync(registro, personalOk.HorarioCabecera);
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
