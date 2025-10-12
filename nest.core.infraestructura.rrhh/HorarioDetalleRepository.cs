using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.rrhh
{
    public class HorarioDetalleRepository : IHorarioDetalleRepository
    {
        private readonly NestDbContext context;
        private readonly IMapper mapper;

        public HorarioDetalleRepository(NestDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        private IQueryable<HorarioDetalle> Query() => context.HorarioDetalles
            .AsNoTracking()
            .Include(x => x.HorarioDetalleEventos);

        public Task<HorarioDetalle?> ObtenerPorId(long id) => Query()
            .FirstOrDefaultAsync(x => x.Id == id);

        public Task<List<HorarioDetalle>> ObtenerPorCabeceraId(int horarioCabeceraId) => Query()
            .Where(x => x.HorarioCabeceraId == horarioCabeceraId)
            .OrderBy(x => x.Item)
            .ToListAsync();

        public Task<List<HorarioDetalle>> ObtenerTodos() => Query()
            .OrderBy(x => x.HorarioCabeceraId)
            .ThenBy(x => x.Item)
            .ToListAsync();

        public async Task<HorarioDetalle> Agregar(int horarioCabeceraId, HorarioDetalleCrearDto entidad)
        {
            var detalle = mapper.Map<HorarioDetalle>(entidad);
            detalle.HorarioCabeceraId = horarioCabeceraId;
            context.HorarioDetalles.Add(detalle);
            await context.SaveChangesAsync();

            await context.Entry(detalle).Collection(x => x.HorarioDetalleEventos).LoadAsync();
            return detalle;
        }

        public async Task<HorarioDetalle> Modificar(long id, HorarioDetalleCrearDto entidad)
        {
            var detalle = await context.HorarioDetalles
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new RegistroNoEncontradoException<HorarioDetalle>(id.ToString());

            mapper.Map(entidad, detalle);
            await context.SaveChangesAsync();
            await context.Entry(detalle).Collection(x => x.HorarioDetalleEventos).LoadAsync();
            return detalle;
        }

        public async Task Eliminar(long id)
        {
            var detalle = await context.HorarioDetalles
                .Include(x => x.HorarioDetalleEventos)
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new RegistroNoEncontradoException<HorarioDetalle>(id.ToString());

            context.HorarioDetalleEventos.RemoveRange(detalle.HorarioDetalleEventos);
            context.HorarioDetalles.Remove(detalle);
            await context.SaveChangesAsync();
        }
    }
}
