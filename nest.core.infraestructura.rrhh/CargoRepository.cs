using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.CargoEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;
using System.Data.Entity;

namespace nest.core.infraestructura.rrhh
{
    public class CargoRepository : ICargoRepository
    {
        private readonly NestDbContext context;
        private readonly IMapper mapper;

        public CargoRepository(NestDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Cargo> ObtenerPorId(int id)
        {
            return await context.Cargos.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Cargo>> ObtenerTodos()
        {
            return await context.Cargos.ToListAsync();
        }

        public async Task<List<Cargo>> ObtenerActivos()
        {
            return await context.Cargos.Where(c => c.Estado).ToListAsync();
        }

        public async Task<Cargo> Agregar(CargoCrearDto entry)
        {
            Cargo entryFine = mapper.Map<Cargo>(entry);
            context.Cargos.Add(entryFine);
            await context.SaveChangesAsync();
            await context.Entry(entryFine).ReloadAsync();
            return entryFine;
        }

        public async Task<Cargo> Modificar(int id, CargoCrearDto entry)
        {
            var existente = await context.Cargos.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<Cargo>(id);
            mapper.Map(entry, existente);
            await context.SaveChangesAsync();
            await context.Entry(existente).ReloadAsync();
            return existente;
        }

        public async Task Eliminar(int id)
        {
            int registrosAfectados = await context.Cargos.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (registrosAfectados < 1)
                throw new RegistroNoEncontradoException<Cargo>(id);
            context.SaveChanges();
        }
    }
}
