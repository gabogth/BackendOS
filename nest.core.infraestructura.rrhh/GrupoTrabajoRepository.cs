using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.GrupoTrabajoEntities;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.rrhh
{
    public class GrupoTrabajoRepository : CrudRepositoryBase<GrupoTrabajo, GrupoTrabajoDto, long>, IGrupoTrabajoRepository
    {
        public GrupoTrabajoRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<GrupoTrabajo> Query() => context.Set<GrupoTrabajo>()
            .AsNoTracking()
            .Include(g => g.GrupoTrabajoPersonas)
                .ThenInclude(p => p.Persona);

        public async Task<GrupoTrabajo> ObtenerPorId(long id)
        {
            return await Query().FirstOrDefaultAsync(g => g.Id == id)
                ?? throw new RegistroNoEncontradoException<GrupoTrabajo>(id.ToString());
        }

        public Task<List<GrupoTrabajo>> ObtenerTodos() => GetAllAsync();

        public Task<List<GrupoTrabajo>> ObtenerActivos() =>
            Query().Where(g => g.Estado).ToListAsync();

        public async Task<GrupoTrabajo> Agregar(GrupoTrabajoDto entry)
        {
            var grupo = mapper.Map<GrupoTrabajo>(entry.Cabecera);
            context.GrupoTrabajo.Add(grupo);
            await context.SaveChangesAsync();
            await context.Entry(grupo).ReloadAsync();

            foreach (var personaDto in entry.Personas ?? Enumerable.Empty<GrupoTrabajoPersonaCrearDto>())
            {
                var persona = mapper.Map<GrupoTrabajoPersona>(personaDto);
                persona.GrupoTrabajoId = grupo.Id;
                persona.EmpresaId = grupo.EmpresaId;
                context.GrupoTrabajoPersona.Add(persona);
            }

            await context.SaveChangesAsync();
            return await Query().FirstAsync(g => g.Id == grupo.Id);
        }

        public async Task<GrupoTrabajo> Modificar(long id, GrupoTrabajoDto entry)
        {
            var grupo = await context.GrupoTrabajo
                .Include(g => g.GrupoTrabajoPersonas)
                .FirstOrDefaultAsync(g => g.Id == id)
                ?? throw new RegistroNoEncontradoException<GrupoTrabajo>(id.ToString());

            mapper.Map(entry.Cabecera, grupo);

            var personasDb = grupo.GrupoTrabajoPersonas.ToDictionary(p => p.Id);
            var personasDto = (entry.Personas ?? new List<GrupoTrabajoPersonaCrearDto>()).ToList();

            var personasInsertar = personasDto.Where(p => !p.Id.HasValue || !personasDb.ContainsKey(p.Id.Value));
            var personasActualizar = personasDto.Where(p => p.Id.HasValue && personasDb.ContainsKey(p.Id.Value));
            var personasEliminar = personasDb.Values
                .Where(p => !personasDto.Any(dto => dto.Id.HasValue && dto.Id.Value == p.Id))
                .ToList();

            foreach (var personaDto in personasInsertar)
            {
                var persona = mapper.Map<GrupoTrabajoPersona>(personaDto);
                persona.GrupoTrabajoId = grupo.Id;
                persona.EmpresaId = grupo.EmpresaId;
                context.GrupoTrabajoPersona.Add(persona);
            }

            foreach (var personaDto in personasActualizar)
            {
                var persona = personasDb[personaDto.Id!.Value];
                mapper.Map(personaDto, persona);
                persona.EmpresaId = grupo.EmpresaId;
                persona.GrupoTrabajoId = grupo.Id;
            }

            context.GrupoTrabajoPersona.RemoveRange(personasEliminar);

            await context.SaveChangesAsync();
            return await Query().FirstAsync(g => g.Id == grupo.Id);
        }

        public Task Eliminar(long id) => DeleteAsync(id);
    }
}
