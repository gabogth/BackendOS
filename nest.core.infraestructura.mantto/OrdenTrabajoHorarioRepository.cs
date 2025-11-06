using AutoMapper;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using System.Data.Entity;

namespace nest.core.infraestructura.mantto
{
    public class OrdenTrabajoHorarioRepository : CrudRepositoryBase<OrdenTrabajoHorario, long>, IOrdenTrabajoHorarioRepository
    {
        public OrdenTrabajoHorarioRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<OrdenTrabajoHorario> Query()
        {
            return base.Query()
                .Include(x => x.OrdenTrabajoCabecera);
        }

        public Task<OrdenTrabajoHorario> ObtenerPorId(long id) => GetByIdAsync(id);

        public Task<List<OrdenTrabajoHorario>> ObtenerTodos() => GetAllAsync();
        public Task<List<OrdenTrabajoHorario>> ObtenerPorOtYRangoFechas(long OrdenTrabajoCabeceraId, DateOnly Inicio, DateOnly Fin)
        {
            return this.Query()
                .Where(x => x.OrdenTrabajoCabeceraId == OrdenTrabajoCabeceraId  && x.Fecha >= Inicio && x.Fecha <= Fin)
                .ToListAsync();
        }

        public Task<OrdenTrabajoHorario> Agregar(OrdenTrabajoHorario entity) => AddAsync(entity);

        public Task<OrdenTrabajoHorario> Modificar(OrdenTrabajoHorario entity) => UpdateAsync(entity);

        public Task Eliminar(long id) => DeleteAsync(id);
    }
}
