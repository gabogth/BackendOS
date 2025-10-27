using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.rrhh
{
    public class HorarioCabeceraRepository : CrudRepositoryBase<HorarioCabecera, int>, IHorarioRepository
    {
        public HorarioCabeceraRepository(NestDbContext context, IMapper mapper) : base(context, mapper) { }

        protected override IQueryable<HorarioCabecera> Query() => context.Set<HorarioCabecera>()
            .AsNoTracking()
            .Include(c => c.HorarioDetalles)
            .Include(c => c.HorarioDetalles).ThenInclude(d => d.HorarioDetalleEventos);

        public async Task<HorarioCabecera> ObtenerPorId(int id) =>
            await GetByIdAsync(id) ?? throw new RegistroNoEncontradoException<HorarioCabecera>(id.ToString());
        public Task<HorarioCabecera> ObtenerPorPersonalId(int personalId) =>
            context.Personales
                .AsNoTracking()
                .Include(p => p.HorarioCabecera).ThenInclude(c => c.HorarioDetalles)
                .Include(p => p.HorarioCabecera).ThenInclude(c => c.HorarioDetalles).ThenInclude(d => d.HorarioDetalleEventos)
                .Where(p => p.Id == personalId)
                .Select(p => p.HorarioCabecera)
                .FirstOrDefaultAsync();
        public Task<List<HorarioCabecera>> ObtenerTodos() => GetAllAsync();
        public async Task<HorarioCabecera> Agregar(HorarioCabecera entry)
        {
            var horario = await AddAsync(entry);
            return await ObtenerPorId(horario.Id);
        }

        public async Task<HorarioCabecera> Modificar(HorarioCabecera entry)
        {
            await UpdateAsync(entry);
            return await ObtenerPorId(entry.Id);
        }
        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
