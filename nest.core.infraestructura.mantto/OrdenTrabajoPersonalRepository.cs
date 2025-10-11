using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using System.Linq;

namespace nest.core.infraestructura.mantto
{
    public class OrdenTrabajoPersonalRepository : CrudRepositoryBase<OrdenTrabajoPersonal, OrdenTrabajoPersonalCrearDto, long>, IOrdenTrabajoPersonalRepository
    {
        public OrdenTrabajoPersonalRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<OrdenTrabajoPersonal> Query()
        {
            return base.Query()
                .Include(x => x.Persona);
        }

        public async Task<OrdenTrabajoPersonal> ObtenerPorId(long id) => await GetByIdAsync(id);

        public async Task<List<OrdenTrabajoPersonal>> ObtenerPorCabecera(long ordenTrabajoCabeceraId)
        {
            return await Query()
                .Where(x => x.OrdenTrabajoCabeceraId == ordenTrabajoCabeceraId)
                .ToListAsync();
        }

        public Task<OrdenTrabajoPersonal> Agregar(OrdenTrabajoPersonalCrearDto dto) => AddAsync(dto);

        public Task<OrdenTrabajoPersonal> Modificar(long id, OrdenTrabajoPersonalCrearDto dto) => UpdateAsync(id, dto);

        public Task Eliminar(long id) => DeleteAsync(id);
    }
}
