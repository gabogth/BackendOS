using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General.PersonaEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.general
{
    public class PersonaRepository : CrudRepositoryBase<Persona, PersonaCrearDto, int>, IPersonaRepository
    {
        public PersonaRepository(NestDbContext context, IMapper mapper): base(context, mapper) { }
        protected override IQueryable<Persona> Query() => context.Set<Persona>()
            .AsNoTracking()
            .Include(x => x.LicenciaConducir)
            .Include(x => x.DocumentoIdentidadTipo)
            .Include(x => x.Sexo);
        public async Task<Persona> ObtenerPorId(int id) => await GetByIdAsync(id);
        public async Task<List<Persona>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<Persona>> ObtenerActivos() => await Query().Where(p => p.Estado).ToListAsync();
        public async Task<Persona> Agregar(PersonaCrearDto entry) => await AddAsync(entry);
        public async Task<Persona> Modificar(int id, PersonaCrearDto entry) => await UpdateAsync(id, entry);
        public async Task Eliminar(int id) => await DeleteAsync(id);
    }
}
