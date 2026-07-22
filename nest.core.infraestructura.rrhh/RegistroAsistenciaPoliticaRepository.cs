using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.rrhh;

public class RegistroAsistenciaPoliticaRepository : CrudRepositoryBase<RegistroAsistenciaPolitica, long>, IRegistroAsistenciaPoliticaRepository
{
    public RegistroAsistenciaPoliticaRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<RegistroAsistenciaPolitica> ObtenerPorId(long id) =>
        await GetByIdAsync(id) ?? throw new RegistroNoEncontradoException<RegistroAsistenciaPolitica>(id.ToString());

    public async Task<List<RegistroAsistenciaPolitica>> ObtenerTodos() => await GetAllAsync();

    public Task<RegistroAsistenciaPolitica> Agregar(RegistroAsistenciaPolitica entry) => AddAsync(entry);

    public async Task<RegistroAsistenciaPolitica> Modificar(RegistroAsistenciaPolitica entry)
    {
        await UpdateAsync(entry);
        return await ObtenerPorId(entry.Id);
    }

    public Task Eliminar(long id) => DeleteAsync(id);
    public async Task<LoadResult> ObtenerFilter(DataSourceLoadOptionsBase options, CancellationToken cancellationToken) => await DataSourceLoader.LoadAsync(Query(), options, cancellationToken);
    public async Task<LoadResult> ObtenerFilterActivos(DataSourceLoadOptionsBase options, CancellationToken cancellationToken) => await DataSourceLoader.LoadAsync(Query(), options, cancellationToken);
}
