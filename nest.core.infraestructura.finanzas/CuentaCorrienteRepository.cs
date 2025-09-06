using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Finanzas.CuentaCorrienteEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.finanzas
{
    public class CuentaCorrienteRepository : CrudRepositoryBase<CuentaCorriente, CuentaCorrienteCrearDto, int>, ICuentaCorrienteRepository
    {
        public CuentaCorrienteRepository(NestDbContext context, IMapper mapper) : base(context, mapper) { }
        protected override IQueryable<CuentaCorriente> Query() => context.Set<CuentaCorriente>()
            .AsNoTracking()
            .Include(x => x.EntidadFinanciera)
            .Include(x => x.CuentaContable);
        public Task<CuentaCorriente> ObtenerPorId(int id) => GetByIdAsync(id);
        public Task<List<CuentaCorriente>> ObtenerTodos() => GetAllAsync();
        public async Task<List<CuentaCorriente>> ObtenerActivos() => await Query().Where(x => x.Activo).ToListAsync();
        public Task<CuentaCorriente> Agregar(CuentaCorrienteCrearDto entry) => AddAsync(entry);
        public Task<CuentaCorriente> Modificar(int id, CuentaCorrienteCrearDto entry) => UpdateAsync(id, entry);
        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
