using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.rrhh
{
    public class HorarioDetalleRepository : CrudRepositoryBase<HorarioDetalle, HorarioDetalleCrearDto, long>, IHorarioDetalleRepository
    {
        public HorarioDetalleRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<HorarioDetalle> Query() =>
            context.Set<HorarioDetalle>()
                .AsNoTracking()
                .Include(detalle => detalle.HorarioDetalleEventos);

        public Task<HorarioDetalle?> ObtenerPorId(long id) => GetByIdAsync(id);

        public Task<List<HorarioDetalle>> ObtenerPorCabeceraId(int horarioCabeceraId) =>
            Query().Where(detalle => detalle.HorarioCabeceraId == horarioCabeceraId).ToListAsync();

        public Task<List<HorarioDetalle>> ObtenerTodos() => GetAllAsync();

        public async Task<HorarioDetalle> Agregar(int horarioCabeceraId, HorarioDetalleCrearDto entidad)
        {
            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                var detalle = mapper.Map<HorarioDetalle>(entidad);
                detalle.HorarioCabeceraId = horarioCabeceraId;
                context.HorarioDetalles.Add(detalle);
                await context.SaveChangesAsync();
                await context.Entry(detalle).ReloadAsync();

                foreach (var eventoDto in entidad.Eventos ?? Enumerable.Empty<HorarioDetalleEventoCrearDto>())
                {
                    var evento = mapper.Map<HorarioDetalleEvento>(eventoDto);
                    evento.HorarioDetalleId = detalle.Id;
                    evento.HorarioDetalle = detalle;
                    context.HorarioDetalleEventos.Add(evento);
                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
                return await GetByIdAsync(detalle.Id) ?? detalle;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<HorarioDetalle> Modificar(long id, HorarioDetalleCrearDto entidad)
        {
            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                var detalle = await context.HorarioDetalles
                    .Include(d => d.HorarioDetalleEventos)
                    .FirstOrDefaultAsync(d => d.Id == id)
                    ?? throw new RegistroNoEncontradoException<HorarioDetalle>(id.ToString());

                mapper.Map(entidad, detalle);

                var eventosActuales = detalle.HorarioDetalleEventos.ToDictionary(e => e.Id);
                var eventosDto = (entidad.Eventos ?? new List<HorarioDetalleEventoCrearDto>()).ToList();

                var eventosInsertar = eventosDto.Where(e => !e.Id.HasValue || !eventosActuales.ContainsKey(e.Id.Value));
                var eventosActualizar = eventosDto.Where(e => e.Id.HasValue && eventosActuales.ContainsKey(e.Id.Value));
                var eventosEliminar = detalle.HorarioDetalleEventos
                    .Where(e => !eventosDto.Any(dto => dto.Id.HasValue && dto.Id.Value == e.Id))
                    .ToList();

                foreach (var eventoDto in eventosInsertar)
                {
                    var evento = mapper.Map<HorarioDetalleEvento>(eventoDto);
                    evento.HorarioDetalleId = detalle.Id;
                    evento.HorarioDetalle = detalle;
                    context.HorarioDetalleEventos.Add(evento);
                }

                foreach (var eventoDto in eventosActualizar)
                {
                    var evento = eventosActuales[eventoDto.Id!.Value];
                    mapper.Map(eventoDto, evento);
                }

                context.HorarioDetalleEventos.RemoveRange(eventosEliminar);

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
                return await GetByIdAsync(detalle.Id) ?? detalle;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public Task Eliminar(long id) => DeleteAsync(id);
    }
}
