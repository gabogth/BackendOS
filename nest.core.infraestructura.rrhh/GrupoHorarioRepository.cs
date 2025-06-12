using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.RRHH.CargoEntities;
using nest.core.dominio.RRHH.GrupoHorarioEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.rrhh
{
    public class GrupoHorarioRepository : CachedRepositoryBase<GrupoHorario, GrupoHorarioCrearDto, int>, IGrupoHorarioRepository
    {
        public GrupoHorarioRepository(NestDbContext context, IMapper mapper, ICacheRepository cache)
            : base(context, mapper, cache) { }

        public async Task<GrupoHorario> ObtenerPorId(int id) => await GetByIdAsync(id);

        public async Task<List<GrupoHorario>> ObtenerTodos() => await GetAllAsync();

        public async Task<List<GrupoHorario>> ObtenerActivos() => await GetAllAsync();

        public async Task<GrupoHorario> Agregar(GrupoHorarioCrearDto entry)
        {
            var entidad = await AddAsync(entry);
            entidad.FechaCreacion = DateTime.UtcNow;
            return entidad;
        }

        public async Task<GrupoHorario> Modificar(int id, GrupoHorarioCrearDto entry)
        {
            var entidad = await UpdateAsync(id, entry);
            entidad.FechaModificacion = DateTime.UtcNow;
            return entidad;
        }

        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
