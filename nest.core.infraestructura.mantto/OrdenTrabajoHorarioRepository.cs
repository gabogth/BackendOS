using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

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
                .Include(x => x.OrdenTrabajoCabecera)
                .AsNoTracking()
                .AsSplitQuery();
        }

        protected IQueryable<OrdenTrabajoHorario> QueryFull()
        {
            return base.Query()
                .Include(x => x.OrdenTrabajoCabecera)
                .Include(x => x.HorarioCabecera)
                    .ThenInclude(x => x.HorarioDetalles)
                        .ThenInclude(x => x.HorarioDetalleEventos)
                .AsNoTracking()
                .AsSplitQuery();
        }

        public Task<OrdenTrabajoHorario> ObtenerPorId(long id) => GetByIdAsync(id);

        public Task<List<OrdenTrabajoHorario>> ObtenerTodos() => GetAllAsync();
        public Task<List<OrdenTrabajoHorario>> ObtenerPorOtYRangoFechas(long OrdenTrabajoCabeceraId, DateOnly Inicio, DateOnly Fin)
        {
            return base.Query()
                .Include(x => x.OrdenTrabajoCabecera)
                .Include(x => x.HorarioCabecera).ThenInclude(x => x.HorarioDetalles).ThenInclude(x => x.HorarioDetalleEventos)
                .AsNoTracking()
                .AsSplitQuery()
                .Where(x => x.OrdenTrabajoCabeceraId == OrdenTrabajoCabeceraId  && x.Fecha >= Inicio && x.Fecha <= Fin)
                .ToListAsync();
        }

        public Task<OrdenTrabajoHorario> ObtenerPorPersonalYFecha(int personaId, DateTime fecha)
        {
            var estadosActivo = new[] { OrdenTrabajoEstado.Activo, OrdenTrabajoEstado.EnProceso };
            DateOnly fechaMarca = DateOnly.FromDateTime(fecha);
            return this.QueryFull()
                .Where(o => estadosActivo.Contains(o.OrdenTrabajoCabecera.Estado)) // que esten activos
                .Where(o => o.PersonalId == personaId) // que contengan a la persona y que tenga horario asignado
                .Where(o => o.Fecha == fechaMarca) // que la fecha coincida
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();
        }

        public Task<OrdenTrabajoHorario> Agregar(OrdenTrabajoHorario entity) => AddAsync(entity);

        public Task<OrdenTrabajoHorario> Modificar(OrdenTrabajoHorario entity) => UpdateAsync(entity);

        public Task Eliminar(long id) => DeleteAsync(id);
    }
}
