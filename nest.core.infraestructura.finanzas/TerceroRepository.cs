using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Finanzas.ClienteEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.finanzas
{
    public class TerceroRepository : CrudRepositoryBase<Tercero, TerceroCrearDto, int>, ITerceroRepository
    {
        public TerceroRepository(NestDbContext context, IMapper mapper) : base(context, mapper) { }
        protected override IQueryable<Tercero> Query() => context.Set<Tercero>()
            .AsNoTracking()
            .Include(x => x.DocumentoIdentidadTipoFinanciero)
            .Include(x => x.CuentaContablePorCobrar)
            .Include(x => x.CuentaContablePorPagar)
            .Include(x => x.Persona);
        public Task<Tercero> ObtenerPorId(int id) => GetByIdAsync(id);
        public Task<List<Tercero>> ObtenerTodos() => GetAllAsync();
        public Task<Tercero> Agregar(TerceroCrearDto entry) => AddAsync(entry);
        public Task<Tercero> Modificar(int id, TerceroCrearDto entry) => UpdateAsync(id, entry);
        public Task Eliminar(int id) => DeleteAsync(id);
    }
}
