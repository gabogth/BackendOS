using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using nest.core.dominio.RRHH.TerminalBiometricoEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.rrhh;

public class TerminalBiometricoRepository : CrudRepositoryBase<TerminalBiometrico, int>, ITerminalBiometricoRepository
{
    public TerminalBiometricoRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<TerminalBiometrico> ObtenerPorId(int id) =>
        await GetByIdAsync(id) ?? throw new RegistroNoEncontradoException<TerminalBiometrico>(id.ToString());

    public async Task<List<TerminalBiometrico>> ObtenerTodos() => await GetAllAsync();

    public async Task<LoadResult> ObtenerFilter(DataSourceLoadOptionsBase options, CancellationToken cancellationToken) => await DataSourceLoader.LoadAsync(Query(), options, cancellationToken);

    public async Task<LoadResult> ObtenerFilterActivos(DataSourceLoadOptionsBase options, CancellationToken cancellationToken) => await DataSourceLoader.LoadAsync(Query(), options, cancellationToken);

    public Task<TerminalBiometrico> Agregar(TerminalBiometrico entry) => AddAsync(entry);

    public async Task<TerminalBiometrico> Modificar(TerminalBiometrico entry)
    {
        await UpdateAsync(entry);
        return await ObtenerPorId(entry.Id);
    }

    public Task Eliminar(int id) => DeleteAsync(id);
}
