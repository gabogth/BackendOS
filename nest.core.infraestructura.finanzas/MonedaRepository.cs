using AutoMapper;
using nest.core.dominio.Finanzas.MonedaEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.finanzas
{
    public class MonedaRepository : CrudRepositoryBase<Moneda, MonedaCrearDto, int>, IMonedaRepository
    {
        public MonedaRepository(NestDbContext context, IMapper mapper) : base(context, mapper) { }
        public Task<Moneda> ObtenerPorId(int id) => GetByIdAsync(id);
        public Task<List<Moneda>> ObtenerTodos() => GetAllAsync();
        public Task<Moneda> Agregar(MonedaCrearDto entry) => AddAsync(entry);
        public Task<Moneda> Modificar(int id, MonedaCrearDto entry) => UpdateAsync(id, entry);
        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
