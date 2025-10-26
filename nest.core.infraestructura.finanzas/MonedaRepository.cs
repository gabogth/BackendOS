using AutoMapper;
using nest.core.dominio.Finanzas.MonedaEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.finanzas
{
    public class MonedaRepository : CrudRepositoryBase<Moneda, int>, IMonedaRepository
    {
        public MonedaRepository(NestDbContext context, IMapper mapper) : base(context, mapper) { }

        public Task<Moneda> ObtenerPorId(int id) => GetByIdAsync(id);

        public Task<List<Moneda>> ObtenerTodos() => GetAllAsync();

        public Task<Moneda> Agregar(Moneda entry) => AddAsync(entry);

        public Task<Moneda> Modificar(Moneda entry) => UpdateAsync(entry);

        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
