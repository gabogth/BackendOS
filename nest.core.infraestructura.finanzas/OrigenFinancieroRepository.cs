using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Finanzas.OrigenFinancieroEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.finanzas
{
    public class OrigenFinancieroRepository : CrudRepositoryBase<OrigenFinanciero, short>, IOrigenFinancieroRepository
    {
        public OrigenFinancieroRepository(NestDbContext context, IMapper mapper) : base(context, mapper) { }
        public Task<OrigenFinanciero> ObtenerPorId(short id) => GetByIdAsync(id);
        public Task<List<OrigenFinanciero>> ObtenerTodos() => GetAllAsync();
        public async Task<List<OrigenFinanciero>> ObtenerActivos() => await Query().Where(x => x.Activo).ToListAsync();
        public Task<OrigenFinanciero> Agregar(OrigenFinanciero entry) => AddAsync(entry);
        public Task<OrigenFinanciero> Modificar(OrigenFinanciero entry) => UpdateAsync(entry);
        public Task Eliminar(short id) => DeleteAsync(id);
    }
}
