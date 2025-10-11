using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.rrhh
{
    public class GrupoTrabajoPersonaRepository : CrudRepositoryBase<GrupoTrabajoPersona, GrupoTrabajoPersonaCrearDto, long>, IGrupoTrabajoPersonaRepository
    {
        public GrupoTrabajoPersonaRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<GrupoTrabajoPersona> Query() => context.Set<GrupoTrabajoPersona>()
            .AsNoTracking()
            .Include(p => p.Persona)
            .Include(p => p.GrupoTrabajo);

        public async Task<GrupoTrabajoPersona> ObtenerPorId(long id)
        {
            return await Query().FirstOrDefaultAsync(p => p.Id == id)
                ?? throw new RegistroNoEncontradoException<GrupoTrabajoPersona>(id.ToString());
        }

        public Task<List<GrupoTrabajoPersona>> ObtenerTodos() => GetAllAsync();

        public Task<List<GrupoTrabajoPersona>> ObtenerPorGrupoTrabajo(long grupoTrabajoId) =>
            Query().Where(p => p.GrupoTrabajoId == grupoTrabajoId).ToListAsync();

        public async Task<GrupoTrabajoPersona> Agregar(GrupoTrabajoPersonaCrearDto entry)
        {
            var persona = await AddAsync(entry);
            return await ObtenerPorId(persona.Id);
        }

        public async Task<GrupoTrabajoPersona> Modificar(long id, GrupoTrabajoPersonaCrearDto entry)
        {
            await UpdateAsync(id, entry);
            return await ObtenerPorId(id);
        }

        public Task Eliminar(long id) => DeleteAsync(id);
    }
}
