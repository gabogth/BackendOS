using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General.DepartamentoEntites;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.general
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly NestDbContext context;
        private readonly IMapper mapper;
        public DepartamentoRepository(NestDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<Departamento> ObtenerPorId(int id) =>
            await context.Departamento.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<List<Departamento>> ObtenerTodos() =>
            await context.Departamento.ToListAsync();
        public async Task<List<Departamento>> ObtenerActivos() =>
            await context.Departamento.ToListAsync();
        public async Task<Departamento> Agregar(DepartamentoCrearDto entry)
        {
            var entidad = mapper.Map<Departamento>(entry);
            context.Departamento.Add(entidad);
            await context.SaveChangesAsync();
            await context.Entry(entidad).ReloadAsync();
            return entidad;
        }
        public async Task<Departamento> Modificar(int id, DepartamentoCrearDto entry)
        {
            var existente = await context.Departamento.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<Departamento>(id);
            mapper.Map(entry, existente);
            await context.SaveChangesAsync();
            await context.Entry(existente).ReloadAsync();
            return existente;
        }
        public async Task Eliminar(int id)
        {
            var existente = await context.Departamento.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<Departamento>(id);
            context.Departamento.Remove(existente);
            context.SaveChanges();
        }
    }
}
