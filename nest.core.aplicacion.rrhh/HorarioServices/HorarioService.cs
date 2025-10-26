using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;
using nest.core.dominio.Transaccional;

namespace nest.core.aplicacion.rrhh.HorarioServices
{
    public class HorarioService
    {
        private readonly IHorarioRepository repository;
        private readonly IHorarioDetalleRepository horarioDetalleRepository;
        private readonly IHorarioDetalleEventoRepository horarioDetalleEventoRepository;
        private readonly IUnitOfWork unitOfWork;
        public HorarioService(IHorarioRepository repository, IHorarioDetalleRepository horarioDetalleRepository, IUnitOfWork unitOfWork, IHorarioDetalleEventoRepository horarioDetalleEventoRepository)
        {
            this.repository = repository;
            this.horarioDetalleRepository = horarioDetalleRepository;
            this.unitOfWork = unitOfWork;
            this.horarioDetalleEventoRepository = horarioDetalleEventoRepository;
        }
        public Task<HorarioCabecera> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<HorarioCabecera>> ObtenerTodos() => repository.ObtenerTodos();
        public async Task<HorarioCabecera> Agregar(HorarioDto entry)
        {
            await this.unitOfWork.BeginTransactionAsync();
            try
            {
                HorarioCabecera horarioCabecera = await repository.Agregar(entry.Cabecera);
                entry.Detalles.ForEach(p =>
                {
                    p.HorarioCabeceraId = horarioCabecera.Id;
                    p.EmpresaId = horarioCabecera.EmpresaId;
                });
                HorarioDetalleCrearDto[] detallesDtoArray = entry.Detalles.ToArray();
                HorarioDetalle[] detallesEntities = detallesDtoArray
                    .Select(d => new HorarioDetalle
                    {
                        Id = d.Id ?? 0,
                        EmpresaId = d.EmpresaId,
                        HorarioCabeceraId = d.HorarioCabeceraId,
                        DiaSemana = d.DiaSemana,
                        HorarioDetalleEventos = new List<HorarioDetalleEvento>()
                    })
                    .ToArray();

                HorarioDetalle[] detalles = await this.horarioDetalleRepository.AgregarRange(detallesEntities);
                for (int i = 0; i < detallesDtoArray.Length; i++)
                {
                    HorarioDetalle currentDetalle = detalles[i];
                    HorarioDetalleEventoCrearDto[] currentEventosDto = detallesDtoArray[i].Eventos.ToArray();
                    HorarioDetalleEvento[] currentEventos = currentEventosDto
                        .Select(e => new HorarioDetalleEvento
                        {
                            Id = e.Id ?? 0,
                            EmpresaId = e.EmpresaId,
                            HorarioDetalleId = currentDetalle.Id,
                            TipoEvento = e.TipoEvento,
                            Hora = e.Hora,
                            DiferenciaDia = e.DiferenciaDia,
                            VentanaMin = e.VentanaMin,
                            VentanaMax = e.VentanaMax
                        })
                        .ToArray();

                    for (int j = 0; j < currentEventosDto.Length; j++)
                    {
                        currentEventosDto[j].HorarioDetalleId = currentDetalle.Id;
                        currentEventosDto[j].EmpresaId = currentDetalle.EmpresaId;
                    }
                    HorarioDetalleEvento[] detallesEventos = await this.horarioDetalleEventoRepository.AgregarRange(currentEventos);
                }
                await this.unitOfWork.CommitAsync();
                return await repository.ObtenerPorId(horarioCabecera.Id);
            }
            catch (Exception)
            {
                await this.unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                await this.unitOfWork.DisposeAsync();
            }
        }

        public async Task<HorarioCabecera> Modificar(int id, HorarioDto entry)
        {
            await this.unitOfWork.BeginTransactionAsync();
            try
            {
                HorarioCabecera horarioCabecera = await repository.Modificar(id, entry.Cabecera);
                horarioCabecera = await repository.ObtenerPorId(horarioCabecera.Id);
                entry.Detalles.ForEach(p =>
                {
                    p.HorarioCabeceraId = horarioCabecera.Id;
                    p.EmpresaId = horarioCabecera.EmpresaId;
                });
                HorarioDetalleCrearDto[] detallesDtoArray = entry.Detalles.ToArray();
                HorarioDetalle[] detallesEntities = detallesDtoArray
                    .Select(d => new HorarioDetalle
                    {
                        Id = d.Id ?? 0,
                        EmpresaId = d.EmpresaId,
                        HorarioCabeceraId = d.HorarioCabeceraId,
                        DiaSemana = d.DiaSemana,
                        HorarioDetalleEventos = new List<HorarioDetalleEvento>()
                    })
                    .ToArray();

                HorarioDetalle[] detalles = await this.horarioDetalleRepository.FusionarRange(horarioCabecera.HorarioDetalles.ToArray(), detallesEntities);
                for (int i = 0; i < detallesDtoArray.Length; i++)
                {
                    HorarioDetalle currentDetalle = detalles[i];
                    HorarioDetalleEventoCrearDto[] currentEventosDto = detallesDtoArray[i].Eventos.ToArray();
                    for (int j = 0; j < currentEventosDto.Length; j++)
                    {
                        currentEventosDto[j].HorarioDetalleId = currentDetalle.Id;
                        currentEventosDto[j].EmpresaId = currentDetalle.EmpresaId;
                    }
                    HorarioDetalleEvento[] eventosEntities = currentEventosDto
                        .Select(e => new HorarioDetalleEvento
                        {
                            Id = e.Id ?? 0,
                            EmpresaId = e.EmpresaId,
                            HorarioDetalleId = currentDetalle.Id,
                            TipoEvento = e.TipoEvento,
                            Hora = e.Hora,
                            DiferenciaDia = e.DiferenciaDia,
                            VentanaMin = e.VentanaMin,
                            VentanaMax = e.VentanaMax
                        })
                        .ToArray();

                    HorarioDetalleEvento[] detallesEventos = await this.horarioDetalleEventoRepository.FusionarRange(currentDetalle.HorarioDetalleEventos.ToArray(), eventosEntities);
                }
                await this.unitOfWork.CommitAsync();
                return await repository.ObtenerPorId(horarioCabecera.Id);
            }
            catch (Exception)
            {
                await this.unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                await this.unitOfWork.DisposeAsync();
            }
        }
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
