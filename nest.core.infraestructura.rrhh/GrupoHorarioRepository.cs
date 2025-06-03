using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.CargoEntities;
using nest.core.dominio.RRHH.GrupoHorarioEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.rrhh
{
    public class GrupoHorarioRepository : IGrupoHorarioRepository
    {
        private readonly NestDbContext context;
        private readonly IMapper mapper;

        public GrupoHorarioRepository(NestDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<GrupoHorario> ObtenerPorId(int id)
        {
            return await context.GrupoHorarios
                .Where(g => g.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<GrupoHorario>> ObtenerTodos()
        {
            return await context.GrupoHorarios
                .ToListAsync();
        }

        public async Task<List<GrupoHorario>> ObtenerActivos()
        {
            // Como no hay campo "Activo", devolvemos todos los registros.
            return await context.GrupoHorarios
                .ToListAsync();
        }

        public async Task<GrupoHorario> Agregar(GrupoHorarioCrearDto entry)
        {
            var entidad = mapper.Map<GrupoHorario>(entry);
            entidad.FechaCreacion = DateTime.UtcNow;
            context.GrupoHorarios.Add(entidad);
            await context.SaveChangesAsync();
            await context.Entry(entidad).ReloadAsync();
            return entidad;
        }

        public async Task<GrupoHorario> Modificar(int id, GrupoHorarioCrearDto entry)
        {
            var existente = await context.GrupoHorarios.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<GrupoHorario>(id);
            mapper.Map(entry, existente);
            existente.FechaModificacion = DateTime.UtcNow;
            await context.SaveChangesAsync();
            await context.Entry(existente).ReloadAsync();
            return existente;
        }

        public async Task Eliminar(int id)
        {
            var existente = await context.GrupoHorarios.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<Cargo>(id);
            context.GrupoHorarios.Remove(existente);
            context.SaveChanges();
        }
    }
}
