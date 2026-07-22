using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.RegistroAsistenciaAdjuntoEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.rrhh
{
    public class RegistroAsistenciaAdjuntoRepository : CrudRepositoryBase<RegistroAsistenciaAdjunto, long>, IRegistroAsistenciaAdjuntoRepository
    {
        public RegistroAsistenciaAdjuntoRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<RegistroAsistenciaAdjunto> Query() => context.RegistroAsistenciaAdjunto
            .AsNoTracking()
            .Include(x => x.RegistroAsistencia)
            .Include(x => x.Adjunto);

        public async Task<RegistroAsistenciaAdjunto> ObtenerPorId(long id) =>
            await GetByIdAsync(id) ?? throw new RegistroNoEncontradoException<RegistroAsistenciaAdjunto>(id.ToString());

        public Task<List<RegistroAsistenciaAdjunto>> ObtenerTodos() => GetAllAsync();

        public async Task<RegistroAsistenciaAdjunto> Agregar(RegistroAsistenciaAdjunto entry)
        {
            var registro = await AddAsync(entry);
            return await ObtenerPorId(registro.Id);
        }

        public async Task<RegistroAsistenciaAdjunto> Modificar(RegistroAsistenciaAdjunto entry)
        {
            await UpdateAsync(entry);
            return await ObtenerPorId(entry.Id);
        }

        public Task Eliminar(long id) => DeleteAsync(id);
        public async Task<LoadResult> ObtenerFilter(DataSourceLoadOptionsBase options, CancellationToken cancellationToken) => await DataSourceLoader.LoadAsync(Query(), options, cancellationToken);
        public async Task<LoadResult> ObtenerFilterActivos(DataSourceLoadOptionsBase options, CancellationToken cancellationToken) => await DataSourceLoader.LoadAsync(Query(), options, cancellationToken);
    }
}
