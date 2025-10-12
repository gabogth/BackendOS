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

        private async Task<List<GrupoTrabajoPersona>> ObtenerPorIdRange(List<long> ids)
        {
            return await Query().Where(p => ids.Contains(p.Id)).ToListAsync();
        }

        public Task<List<GrupoTrabajoPersona>> ObtenerTodos() => GetAllAsync();

        public Task<List<GrupoTrabajoPersona>> ObtenerPorGrupoTrabajo(long grupoTrabajoId) =>
            Query().Where(p => p.GrupoTrabajoId == grupoTrabajoId).ToListAsync();

        public async Task<GrupoTrabajoPersona> Agregar(GrupoTrabajoPersonaCrearDto entry)
        {
            var persona = await AddAsync(entry);
            return await ObtenerPorId(persona.Id);
        }

        public async Task<List<GrupoTrabajoPersona>> AgregarRange(List<GrupoTrabajoPersonaCrearDto> entries)
        {
            var registros = await AddRangeAsync(entries);
            return await ObtenerPorIdRange(registros.Select(x => x.Id).ToList());
        }

        public async Task<GrupoTrabajoPersona> Modificar(long id, GrupoTrabajoPersonaCrearDto entry)
        {
            await UpdateAsync(id, entry);
            return await ObtenerPorId(id);
        }

        public async Task<List<GrupoTrabajoPersona>> ModificarRange(List<(long id, GrupoTrabajoPersonaCrearDto entry)> entries)
        {
            var registros = await UpdateRangeAsync(entries);
            return await ObtenerPorIdRange(registros.Select(x => x.Id).ToList());
        }

        public async Task<List<GrupoTrabajoPersona>> FusionarRange(List<GrupoTrabajoPersona> original, List<(long id, GrupoTrabajoPersonaCrearDto entry)> entries)
        {
            var registros = await MergeRangeAsync(original, entries);
            return await ObtenerPorIdRange(registros.Select(x => x.Id).ToList());
        }

        public Task Eliminar(long id) => DeleteAsync(id);
        public Task EliminarRange(List<long> ids) => DeleteRangeAsync(ids);
    }
}
