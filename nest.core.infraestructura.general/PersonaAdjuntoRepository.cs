using System;
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
        public Task<PersonaAdjunto> Agregar(PersonaAdjuntoCrearDto entry)
        {
            if (entry is null)
                throw new ArgumentNullException(nameof(entry));

            entry.EmpresaId = context.EmpresaId ?? entry.EmpresaId;
            return AddAsync(entry);
        }

        public async Task<PersonaAdjunto[]> AgregarRange(PersonaAdjuntoCrearDto[] entries)
        {
            if (entries is null)
                throw new ArgumentNullException(nameof(entries));

            for (int i = 0; i < entries.Length; i++)
                entries[i].EmpresaId = context.EmpresaId ?? entries[i].EmpresaId;

            PersonaAdjunto[] results = await AddRangeAsync(entries);
            List<PersonaAdjunto> completed = await GetByIdsAsync(results.Select(x => x.Id).ToList());
            return GetOrderedArrayFrom(completed, results);
        }
        public Task<PersonaAdjunto> Modificar(long id, PersonaAdjuntoCrearDto entry)
        {
            if (entry is null)
                throw new ArgumentNullException(nameof(entry));

            entry.EmpresaId = context.EmpresaId ?? entry.EmpresaId;
            return UpdateAsync(id, entry);
        }
        public async Task<PersonaAdjunto[]> FusionarRange(PersonaAdjunto[] originalEntities, (long id, PersonaAdjuntoCrearDto entry)[] entries)
        {
            if (entries is null)
                throw new ArgumentNullException(nameof(entries));

            for (int i = 0; i < entries.Length; i++)
                entries[i].entry.EmpresaId = context.EmpresaId ?? entries[i].entry.EmpresaId;

            PersonaAdjunto[] results = await MergeRangeAsync(originalEntities, entries);
            List<PersonaAdjunto> completed = await GetByIdsAsync(results.Select(x => x.Id).ToList());
            return GetOrderedArrayFrom(completed, results);
        }
        public Task Eliminar(long id) => DeleteAsync(id);
        public Task EliminarRange(long[] ids) => DeleteRangeAsync(ids);
    }
}
