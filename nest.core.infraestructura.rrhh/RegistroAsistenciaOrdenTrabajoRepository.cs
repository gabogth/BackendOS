using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.RegistroAsistenciaOrdenTrabajoEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.rrhh
{
    public class RegistroAsistenciaOrdenTrabajoRepository : CrudRepositoryBase<RegistroAsistenciaOrdenTrabajo, long>, IRegistroAsistenciaOrdenTrabajoRepository
    {
        public RegistroAsistenciaOrdenTrabajoRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<RegistroAsistenciaOrdenTrabajo> Query()
        {
            return this.Query()
            .AsNoTracking()
            .Include(x => x.RegistroAsistencia)
            .Include(x => x.OrdenTrabajoCabecera);
        }

        public Task<RegistroAsistenciaOrdenTrabajo> ObtenerPorId(long id) => GetByIdAsync(id);

        public Task<List<RegistroAsistenciaOrdenTrabajo>> ObtenerTodos() => GetAllAsync();

        public async Task<RegistroAsistenciaOrdenTrabajo> Agregar(RegistroAsistenciaOrdenTrabajo entry)
        {
            var registro = await AddAsync(entry);
            return registro;
        }

        public async Task<RegistroAsistenciaOrdenTrabajo> Modificar(RegistroAsistenciaOrdenTrabajo entry)
        {
            await UpdateAsync(entry);
            return await ObtenerPorId(entry.Id);
        }

        public Task Eliminar(long id) => DeleteAsync(id);
        public async Task<LoadResult> ObtenerFilter(DataSourceLoadOptionsBase options, CancellationToken cancellationToken) => await DataSourceLoader.LoadAsync(context.Set<RegistroAsistenciaOrdenTrabajo>().AsNoTracking(), options, cancellationToken);
        public async Task<LoadResult> ObtenerFilterActivos(DataSourceLoadOptionsBase options, CancellationToken cancellationToken) => await DataSourceLoader.LoadAsync(context.Set<RegistroAsistenciaOrdenTrabajo>().AsNoTracking(), options, cancellationToken);
    }
}
