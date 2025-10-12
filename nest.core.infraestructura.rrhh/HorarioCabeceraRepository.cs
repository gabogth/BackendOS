using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.rrhh
{
    public class HorarioCabeceraRepository : CrudRepositoryBase<HorarioCabecera, HorarioCabeceraCrearDto, int>, IHorarioRepository
    {
        public HorarioCabeceraRepository(NestDbContext context, IMapper mapper) : base(context, mapper) { }

        protected override IQueryable<HorarioCabecera> Query() => context.Set<HorarioCabecera>()
            .AsNoTracking()
            .Include(c => c.HorarioDetalles)
            .Include(c => c.HorarioDetalles).ThenInclude(d => d.HorarioDetalleEventos);

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
        public Task<HorarioCabecera> Agregar(HorarioCabeceraCrearDto entry) => AddAsync(entry);
        public async Task<HorarioCabecera> Modificar(int id, HorarioCabeceraCrearDto entry) => await UpdateAsync(id, entry);
        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
