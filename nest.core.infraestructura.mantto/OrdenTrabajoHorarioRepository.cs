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
        public Task<List<OrdenTrabajoHorario>> ObtenerPorIds(List<long> ids) => GetByIdsAsync(ids);

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

        public async Task<OrdenTrabajoHorario> ObtenerPorPersonalYFecha(int personaId, DateTime fecha)
        {
            DateOnly fechaMarca = DateOnly.FromDateTime(fecha);
            var candidatos = await ObtenerCandidatosPorPersonalYFecha(personaId, fecha);
            return candidatos.FirstOrDefault(x => x.Fecha == fechaMarca);
        }

        public async Task<List<OrdenTrabajoHorario>> ObtenerCandidatosPorPersonalYFecha(int personaId, DateTime fecha)
        {
            var estadosActivo = new[] { OrdenTrabajoEstado.Activo, OrdenTrabajoEstado.EnProceso };
            DateOnly fechaMarca = DateOnly.FromDateTime(fecha);
            DateOnly fechaAnterior = fechaMarca.AddDays(-1);

            var candidatos = await QueryFull()
                .Where(o => estadosActivo.Contains(o.OrdenTrabajoCabecera.Estado))
                .Where(o => o.PersonalId == personaId)
                .Where(o => o.Fecha == fechaMarca || o.Fecha == fechaAnterior)
                .ToListAsync();

            if (candidatos.Count <= 1)
                return candidatos;

            var ids = candidatos.Select(x => x.Id).ToList();
            var auditoriasCreacion = await context
                .Set<Dictionary<string, object>>("OrdenTrabajoHorarioAudit")
                .Where(x => ids.Contains(EF.Property<long>(x, "Id")))
                .Where(x => EF.Property<string>(x, "AuditAccion") == EntityState.Added.ToString())
                .Select(x => new
                {
                    Id = EF.Property<long>(x, "Id"),
                    AuditFecha = EF.Property<DateTime>(x, "AuditFecha")
                })
                .ToListAsync();

            var fechaCreacionPorId = auditoriasCreacion
                .GroupBy(x => x.Id)
                .ToDictionary(x => x.Key, x => x.Max(a => a.AuditFecha));

            // Solo una asignación puede prevalecer para el personal en cada fecha base.
            // Id conserva un desempate determinista para registros históricos sin auditoría.
            return candidatos
                .GroupBy(x => x.Fecha)
                .Select(grupo => grupo
                    .OrderByDescending(x => fechaCreacionPorId.GetValueOrDefault(x.Id, DateTime.MinValue))
                    .ThenByDescending(x => x.Id)
                    .First())
                .ToList();
        }

        public Task<OrdenTrabajoHorario> Agregar(OrdenTrabajoHorario entity) => AddAsync(entity);
        public async Task<OrdenTrabajoHorario[]> Merge(OrdenTrabajoHorario[] current, OrdenTrabajoHorario[] new_entries) => await this.MergeRangeAsync(current, new_entries);

        public Task<OrdenTrabajoHorario> Modificar(OrdenTrabajoHorario entity) => UpdateAsync(entity);

        public Task Eliminar(long id) => DeleteAsync(id);
    }
}
