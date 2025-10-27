using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.Horarios.Commands;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;
using nest.core.dominio.Transaccional;

namespace nest.core.aplicacion.rrhh.Horarios.Handlers
{
    public class HorarioModificarHandler : IRequestHandler<HorarioModificarCommand, HorarioCabecera>
    {
        private readonly IHorarioRepository repository;
        private readonly IHorarioDetalleRepository detalleRepository;
        private readonly IHorarioDetalleEventoRepository eventoRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<HorarioModificarHandler> logger;

        public HorarioModificarHandler(
            IHorarioRepository repository,
            IHorarioDetalleRepository detalleRepository,
            IHorarioDetalleEventoRepository eventoRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<HorarioModificarHandler> logger)
        {
            this.repository = repository;
            this.detalleRepository = detalleRepository;
            this.eventoRepository = eventoRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<HorarioCabecera> Handle(HorarioModificarCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                var horario = mapper.Map<HorarioCabecera>(request);
                horario = await repository.Modificar(horario);
                var horarioCompleto = await repository.ObtenerPorId(horario.Id);

                var detalleCommands = request.Detalles.ToArray();
                var detalles = detalleCommands
                    .Select(d => new HorarioDetalle
                    {
                        Id = d.Id ?? 0,
                        EmpresaId = horario.EmpresaId,
                        HorarioCabeceraId = horario.Id,
                        DiaSemana = d.DiaSemana
                    })
                    .ToArray();

                var detallesActualizados = await detalleRepository.FusionarRange(horarioCompleto.HorarioDetalles.ToArray(), detalles);

                for (int i = 0; i < detalleCommands.Length; i++)
                {
                    var eventosCommand = detalleCommands[i].Eventos;
                    var detalleOriginal = detallesActualizados[i];

                    var eventos = eventosCommand
                        .Select(e => new HorarioDetalleEvento
                        {
                            Id = e.Id ?? 0,
                            EmpresaId = detalleOriginal.EmpresaId,
                            HorarioDetalleId = detalleOriginal.Id,
                            TipoEvento = e.TipoEvento,
                            Hora = e.Hora,
                            DiferenciaDia = e.DiferenciaDia,
                            VentanaMin = e.VentanaMin,
                            VentanaMax = e.VentanaMax
                        })
                        .ToArray();

                    await eventoRepository.FusionarRange(detalleOriginal.HorarioDetalleEventos.ToArray(), eventos);
                }

                await unitOfWork.CommitAsync();
                return await repository.ObtenerPorId(horario.Id);
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackAsync();
                logger.LogError(ex, "Error al modificar el horario {Id}", request.Id);
                throw;
            }
            finally
            {
                await unitOfWork.DisposeAsync();
            }
        }
    }
}
