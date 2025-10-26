using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.mantto
{
    public class OrdenServicioCabeceraRepository : CrudRepositoryBase<OrdenServicioCabecera, long>, IOrdenServicioCabeceraRepository
    {
        public OrdenServicioCabeceraRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<OrdenServicioCabecera> Query()
        {
            return base.Query()
                .Include(x => x.OrdenServicioTipo)
                .Include(x => x.OrdenTrabajoCabeceras);
        }

        public Task<OrdenServicioCabecera> ObtenerPorId(long id) => GetByIdAsync(id);

        public Task<List<OrdenServicioCabecera>> ObtenerTodos() => GetAllAsync();

        public Task<OrdenServicioCabecera> Agregar(OrdenServicioCabecera entity) => AddAsync(entity);

        public Task<OrdenServicioCabecera> Modificar(OrdenServicioCabecera entity) => UpdateAsync(entity);

        public Task Eliminar(long id) => DeleteAsync(id);
    }
}
