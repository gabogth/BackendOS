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
    public class HorarioCrearHandler : IRequestHandler<HorarioCrearCommand, HorarioCabecera>
    {
        private readonly IHorarioRepository repository;
        private readonly IHorarioDetalleRepository detalleRepository;
        private readonly IHorarioDetalleEventoRepository eventoRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<HorarioCrearHandler> logger;

        public HorarioCrearHandler(
            IHorarioRepository repository,
            IHorarioDetalleRepository detalleRepository,
            IHorarioDetalleEventoRepository eventoRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<HorarioCrearHandler> logger)
        {
            this.repository = repository;
            this.detalleRepository = detalleRepository;
            this.eventoRepository = eventoRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<HorarioCabecera> Handle(HorarioCrearCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                var horario = mapper.Map<HorarioCabecera>(request);
                horario = await repository.Agregar(horario);

                if (request.Detalles.Count > 0)
                {
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

                    var detallesGuardados = await detalleRepository.AgregarRange(detalles);

                    for (int i = 0; i < detalleCommands.Length; i++)
                    {
                        if (detalleCommands[i].Eventos.Count == 0)
                            continue;

                        var eventos = detalleCommands[i].Eventos
                            .Select(e => new HorarioDetalleEvento
                            {
                                Id = e.Id ?? 0,
                                EmpresaId = detallesGuardados[i].EmpresaId,
                                HorarioDetalleId = detallesGuardados[i].Id,
                                TipoEvento = e.TipoEvento,
                                Hora = e.Hora,
                                DiferenciaDia = e.DiferenciaDia,
                                VentanaMin = e.VentanaMin,
                                VentanaMax = e.VentanaMax
                            })
                            .ToArray();

                        await eventoRepository.AgregarRange(eventos);
                    }
                }

                await unitOfWork.CommitAsync();
                return await repository.ObtenerPorId(horario.Id);
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackAsync();
                logger.LogError(ex, "Error al crear el horario {Nombre}", request.Nombre);
                throw;
            }
            finally
            {
                await unitOfWork.DisposeAsync();
            }
        }
    }
}
