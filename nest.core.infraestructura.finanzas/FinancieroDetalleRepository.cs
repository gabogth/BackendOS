using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Finanzas.FinancieroDetalleEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.finanzas
{
    public class FinancieroDetalleRepository : CrudRepositoryBase<FinancieroDetalle, long>, IFinancieroDetalleRepository
    {
        public FinancieroDetalleRepository(NestDbContext context, IMapper mapper) : base(context, mapper) { }

        protected override IQueryable<FinancieroDetalle> Query() => context.Set<FinancieroDetalle>()
            .AsNoTracking()
            .Include(x => x.FinancieroCabecera)
            .Include(x => x.Tercero)
            .Include(x => x.DocumentoTipo)
            .Include(x => x.CuentaCorriente);

        public async Task<FinancieroDetalle> ObtenerPorId(long id)
        {
            var entity = await GetByIdAsync(id);
            return entity ?? throw new RegistroNoEncontradoException<FinancieroDetalle>(id.ToString());
        }

        public Task<List<FinancieroDetalle>> ObtenerTodos() => GetAllAsync();

        public Task<List<FinancieroDetalle>> ObtenerPorCabecera(long cabeceraId) =>
            Query().Where(x => x.FinancieroCabeceraId == cabeceraId).ToListAsync();

        public Task<FinancieroDetalle> Agregar(FinancieroDetalle entidad)
        {
            entidad.Id = 0;
            return AddAsync(entidad);
        }

        public async Task<FinancieroDetalle> Modificar(FinancieroDetalle entidad)
        {
            if (await TieneExtension(entidad.Id))
                throw new Exception($"El detalle {entidad.Id} no puede modificarse por tener extensiones");
            return await UpdateAsync(entidad);
        }

        public async Task Eliminar(long id)
        {
            if (await TieneExtension(id))
                throw new Exception($"El detalle {id} no puede eliminarse por tener extensiones");
            await DeleteAsync(id);
        }

        private async Task<bool> TieneExtension(long detalleId)
        {
            return await context.FinancieroLogistica.AnyAsync(x => x.FinancieroDetalleId == detalleId)
                || await context.FinancieroOrdenServicio.AnyAsync(x => x.FinancieroDetalleId == detalleId);
        }
    }
}
