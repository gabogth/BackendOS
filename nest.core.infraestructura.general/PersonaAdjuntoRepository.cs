using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General.PersonaAdjuntoEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.general
{
    public class PersonaAdjuntoRepository : CrudRepositoryBase<PersonaAdjunto, PersonaAdjuntoCrearDto, long>, IPersonaAdjuntoRepository
    {
        public PersonaAdjuntoRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<PersonaAdjunto> Query() => context.Set<PersonaAdjunto>()
            .AsNoTracking()
            .Include(x => x.Persona)
            .Include(x => x.Adjunto)
            .Include(x => x.AdjuntoTipo);

        public async Task<PersonaAdjunto> ObtenerPorId(long id) => await GetByIdAsync(id);
        public async Task<List<PersonaAdjunto>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<PersonaAdjunto>> ObtenerPorPersona(int personaId) =>
            await Query().Where(x => x.PersonaId == personaId).ToListAsync();
        public Task<PersonaAdjunto> Agregar(PersonaAdjuntoCrearDto entry) => AddAsync(entry);
        public Task<PersonaAdjunto> Modificar(long id, PersonaAdjuntoCrearDto entry) => UpdateAsync(id, entry);
        public Task Eliminar(long id) => DeleteAsync(id);
    }
}
