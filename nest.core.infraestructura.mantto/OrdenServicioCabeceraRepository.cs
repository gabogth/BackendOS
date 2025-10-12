using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.mantto
{
    public class OrdenServicioCabeceraRepository : CrudRepositoryBase<OrdenServicioCabecera, OrdenServicioCabeceraCrearDto, long>, IOrdenServicioCabeceraRepository
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

        public Task<OrdenServicioCabecera> Agregar(OrdenServicioCabeceraCrearDto dto) => AddAsync(dto);

        public Task<OrdenServicioCabecera> Modificar(long id, OrdenServicioCabeceraCrearDto dto) => UpdateAsync(id, dto);

        public Task Eliminar(long id) => DeleteAsync(id);
    }
}
