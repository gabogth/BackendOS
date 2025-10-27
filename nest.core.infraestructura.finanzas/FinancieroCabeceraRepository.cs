using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.finanzas
{
    public class FinancieroCabeceraRepository : CrudRepositoryBase<FinancieroCabecera, long>, IFinancieroCabeceraRepository
    {
        public FinancieroCabeceraRepository(NestDbContext context, IMapper mapper) : base(context, mapper) { }

        protected override IQueryable<FinancieroCabecera> Query() => context.Set<FinancieroCabecera>()
            .AsNoTracking()
            .Include(x => x.PuntoFinanciero)
            .Include(x => x.OrigenFinanciero)
            .Include(x => x.TerceroGen)
            .Include(x => x.DocumentoTipoGen);

        public async Task<FinancieroCabecera> ObtenerPorId(long id)
        {
            var entity = await GetByIdAsync(id);
            return entity ?? throw new RegistroNoEncontradoException<FinancieroCabecera>(id.ToString());
        }

        public Task<List<FinancieroCabecera>> ObtenerTodos() => GetAllAsync();

        public Task<FinancieroCabecera> Agregar(FinancieroCabecera entidad) => AddAsync(entidad);

        public Task<FinancieroCabecera> Modificar(FinancieroCabecera entidad) => UpdateAsync(entidad);

        public Task Eliminar(long id) => DeleteAsync(id);
    }
}
