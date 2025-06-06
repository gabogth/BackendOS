using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General.LicenciaConducirEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.general
{
    public class LicenciaConducirRepository : ILicenciaConducirRepository
    {
        private readonly NestDbContext context;
        private readonly IMapper mapper;
        public LicenciaConducirRepository(NestDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<LicenciaConducir> ObtenerPorId(byte id) =>
            await context.LicenciaConducir.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<List<LicenciaConducir>> ObtenerTodos() =>
            await context.LicenciaConducir.ToListAsync();
        public async Task<List<LicenciaConducir>> ObtenerActivos() =>
            await context.LicenciaConducir.ToListAsync();
        public async Task<LicenciaConducir> Agregar(LicenciaConducirCrearDto entry)
        {
            var entidad = mapper.Map<LicenciaConducir>(entry);
            context.LicenciaConducir.Add(entidad);
            await context.SaveChangesAsync();
            await context.Entry(entidad).ReloadAsync();
            return entidad;
        }
        public async Task<LicenciaConducir> Modificar(byte id, LicenciaConducirCrearDto entry)
        {
            var existente = await context.LicenciaConducir.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<LicenciaConducir>(id);
            mapper.Map(entry, existente);
            await context.SaveChangesAsync();
            await context.Entry(existente).ReloadAsync();
            return existente;
        }
        public async Task Eliminar(byte id)
        {
            var existente = await context.LicenciaConducir.FindAsync(id);
            if (existente == null)
                throw new RegistroNoEncontradoException<LicenciaConducir>(id);
            context.LicenciaConducir.Remove(existente);
            context.SaveChanges();
        }
    }
}
