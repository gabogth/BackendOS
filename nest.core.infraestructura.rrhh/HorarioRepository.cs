using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.rrhh
{
    public class HorarioRepository : CrudRepositoryBase<HorarioCabecera, HorarioDto, int>, IHorarioRepository
    {
        public HorarioRepository(NestDbContext context, IMapper mapper) : base(context, mapper) { }

        protected override IQueryable<HorarioCabecera> Query() => context.Set<HorarioCabecera>()
            .AsNoTracking()
            .Include(h => h.HorarioDetalles)
                .ThenInclude(d => d.HorarioDetalleEventos);

        public Task<HorarioCabecera> ObtenerPorId(int id) => GetByIdAsync(id);
        public Task<HorarioCabecera> ObtenerPorPersonalId(int personalId) =>
            context.Personales
                .AsNoTracking()
                .Include(p => p.HorarioCabecera).ThenInclude(c => c.HorarioDetalles)
                .Include(p => p.HorarioCabecera).ThenInclude(c => c.HorarioDetalles).ThenInclude(d => d.HorarioDetalleEventos)
                .Where(p => p.Id == personalId)
                .Select(p => p.HorarioCabecera)
                .FirstOrDefaultAsync();
        public Task<List<HorarioCabecera>> ObtenerTodos() => GetAllAsync();

        public async Task<HorarioCabecera> Agregar(HorarioDto entry)
        {
            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                var cabecera = mapper.Map<HorarioCabecera>(entry.Cabecera);
                context.HorarioCabeceras.Add(cabecera);
                await context.SaveChangesAsync();
                await context.Entry(cabecera).ReloadAsync();

                foreach (var detalleDto in entry.Detalles)
                {
                    var detalle = mapper.Map<HorarioDetalle>(detalleDto);
                    detalle.HorarioCabeceraId = cabecera.Id;
                    context.HorarioDetalles.Add(detalle);

                    foreach (var eventoDto in detalleDto.Eventos ?? Enumerable.Empty<HorarioDetalleEventoCrearDto>())
                    {
                        var evento = mapper.Map<HorarioDetalleEvento>(eventoDto);
                        evento.HorarioDetalle = detalle;
                        context.HorarioDetalleEventos.Add(evento);
                    }
                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
                return await GetByIdAsync(cabecera.Id);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<HorarioCabecera> Modificar(int id, HorarioDto entry)
        {
            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                var cabecera = await context.HorarioCabeceras
                    .Include(h => h.HorarioDetalles)
                        .ThenInclude(d => d.HorarioDetalleEventos)
                    .FirstOrDefaultAsync(h => h.Id == id)
                    ?? throw new RegistroNoEncontradoException<HorarioCabecera>(id.ToString());

                mapper.Map(entry.Cabecera, cabecera);
                var detalleDb = cabecera.HorarioDetalles.ToDictionary(x => x.Item);

                var insert = entry.Detalles.Where(ft => !detalleDb.ContainsKey(ft.Item));
                var update = entry.Detalles.Where(ft => detalleDb.ContainsKey(ft.Item));
                var delete = cabecera.HorarioDetalles.Where(db => !entry.Detalles.Any(ft => ft.Item == db.Item));

                //Insertar nuevos detalles
                foreach (var detalleDto in insert)
                {
                    var detalle = mapper.Map<HorarioDetalle>(detalleDto);
                    detalle.HorarioCabeceraId = cabecera.Id;
                    context.HorarioDetalles.Add(detalle);

                    foreach (var eventoDto in detalleDto.Eventos ?? Enumerable.Empty<HorarioDetalleEventoCrearDto>())
                    {
                        var evento = mapper.Map<HorarioDetalleEvento>(eventoDto);
                        evento.HorarioDetalle = detalle;
                        context.HorarioDetalleEventos.Add(evento);
                    }
                }

                //Modificar detalles existentes
                foreach (var detalleDto in update)
                {
                    var detalle = detalleDb[detalleDto.Item];
                    mapper.Map(detalleDto, detalle);

                    var eventosActuales = detalle.HorarioDetalleEventos.ToDictionary(e => e.Id);
                    var eventosDto = (detalleDto.Eventos ?? new List<HorarioDetalleEventoCrearDto>()).ToList();

                    var eventosInsertar = eventosDto
                        .Where(e => !e.Id.HasValue || !eventosActuales.ContainsKey(e.Id.Value));
                    var eventosActualizar = eventosDto
                        .Where(e => e.Id.HasValue && eventosActuales.ContainsKey(e.Id.Value));
                    var eventosEliminar = detalle.HorarioDetalleEventos
                        .Where(e => !eventosDto.Any(dto => dto.Id.HasValue && dto.Id.Value == e.Id));

                    context.HorarioDetalleEventos.RemoveRange(eventosEliminar);

                    foreach (var eventoDto in eventosInsertar)
                    {
                        var evento = mapper.Map<HorarioDetalleEvento>(eventoDto);
                        evento.HorarioDetalleId = detalle.Id;
                        evento.HorarioDetalle = detalle;
                        context.HorarioDetalleEventos.Add(evento);
                    }

                    foreach (var eventoDto in eventosActualizar)
                        mapper.Map(eventoDto, eventosActuales[eventoDto.Id!.Value]);

                    
                }

                //Eliminar detalles que ya no existen
                context.HorarioDetalles.RemoveRange(delete);


                await context.SaveChangesAsync();
                await transaction.CommitAsync();
                return await GetByIdAsync(cabecera.Id);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
