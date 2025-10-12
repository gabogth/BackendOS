using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.rrhh
{
    public class HorarioDetalleEventoRepository : IHorarioDetalleEventoRepository
    {
        private readonly NestDbContext context;
        private readonly IMapper mapper;

        public HorarioDetalleEventoRepository(NestDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        private IQueryable<HorarioDetalleEvento> Query() => context.HorarioDetalleEventos
            .AsNoTracking();

        public Task<HorarioDetalleEvento?> ObtenerPorId(long id) => Query()
            .FirstOrDefaultAsync(x => x.Id == id);

        public Task<List<HorarioDetalleEvento>> ObtenerPorHorarioDetalleId(long horarioDetalleId) => Query()
            .Where(x => x.HorarioDetalleId == horarioDetalleId)
            .OrderBy(x => x.Hora)
            .ToListAsync();

        public Task<List<HorarioDetalleEvento>> ObtenerTodos() => Query()
            .OrderBy(x => x.HorarioDetalleId)
            .ThenBy(x => x.Hora)
            .ToListAsync();

        public async Task<HorarioDetalleEvento> Agregar(long horarioDetalleId, HorarioDetalleEventoCrearDto entidad)
        {
            var evento = mapper.Map<HorarioDetalleEvento>(entidad);
            evento.HorarioDetalleId = horarioDetalleId;
            context.HorarioDetalleEventos.Add(evento);
            await context.SaveChangesAsync();
            await context.Entry(evento).ReloadAsync();
            return evento;
        }

        public async Task<HorarioDetalleEvento> Modificar(long id, HorarioDetalleEventoCrearDto entidad)
        {
            var evento = await context.HorarioDetalleEventos.FindAsync(id)
                ?? throw new RegistroNoEncontradoException<HorarioDetalleEvento>(id.ToString());

            mapper.Map(entidad, evento);
            await context.SaveChangesAsync();
            await context.Entry(evento).ReloadAsync();
            return evento;
        }

        public async Task Eliminar(long id)
        {
            var evento = await context.HorarioDetalleEventos.FindAsync(id)
                ?? throw new RegistroNoEncontradoException<HorarioDetalleEvento>(id.ToString());

            context.HorarioDetalleEventos.Remove(evento);
            await context.SaveChangesAsync();
        }
    }
}
