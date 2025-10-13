using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.mantto
{
    public class OrdenTrabajoCabeceraRepository : CrudRepositoryBase<OrdenTrabajoCabecera, OrdenTrabajoCabeceraCrearDto, long>, IOrdenTrabajoCabeceraRepository
    {
        public OrdenTrabajoCabeceraRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<OrdenTrabajoCabecera> Query()
        {
            return base.Query()
                .Include(x => x.OrdenServicioCabecera)
                .Include(x => x.OrdenTrabajoCabeceraPadre)
                .Include(x => x.GrupoTrabajo)
                .Include(x => x.OrdenTrabajoDetalles)
                .Include(x => x.OrdenTrabajoDetalles).ThenInclude(x => x.Labor)
                .Include(x => x.OrdenTrabajoDetalles).ThenInclude(x => x.UbicacionTecnica);
        }

        public async Task<OrdenTrabajoCabecera> ObtenerPorId(long id) => await GetByIdAsync(id);

        public async Task<List<OrdenTrabajoCabecera>> ObtenerTodos() => await GetAllAsync();

        public async Task<List<OrdenTrabajoCabecera>> ObtenerPorOrdenServicio(long ordenServicioCabeceraId)
        {
            return await Query()
                .Where(x => x.OrdenServicioCabeceraId == ordenServicioCabeceraId)
                .ToListAsync();
        }

        public Task<OrdenTrabajoCabecera> Agregar(OrdenTrabajoCabeceraCrearDto dto) => AddAsync(dto);

        public Task<OrdenTrabajoCabecera> Modificar(long id, OrdenTrabajoCabeceraCrearDto dto) => UpdateAsync(id, dto);

        public Task Eliminar(long id) => DeleteAsync(id);
    }
}
