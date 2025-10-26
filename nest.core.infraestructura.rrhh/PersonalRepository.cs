using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.rrhh;

public class PersonalRepository : CrudRepositoryBase<Personal, int>, IPersonalRepository
{
    protected override IQueryable<Personal> Query() => context.Set<Personal>()
        .AsNoTracking()
        .Include(x => x.Superior)
        .Include(x => x.PersonalEstado)
        .Include(x => x.HorarioCabecera)
        .Include(x => x.HorarioCabecera).ThenInclude(x => x.HorarioDetalles)
        .Include(x => x.ContratoCabecera)
        .Include(x => x.ContratoCabecera).ThenInclude(x => x.Detalles)
        .Include(x => x.ContratoCabecera).ThenInclude(x => x.ContratoTipo)
        .Include(x => x.Persona)
        .Include(x => x.Persona).ThenInclude(x => x.Sexo)
        .Include(x => x.Persona).ThenInclude(x => x.LicenciaConducir)
        .Include(x => x.Persona).ThenInclude(x => x.Distrito)
        .Include(x => x.Persona).ThenInclude(x => x.DocumentoIdentidadTipo)
        .Include(x => x.RegistroAsistenciaPolitica)
        .Include(x => x.Children);
    public PersonalRepository(NestDbContext context, IMapper mapper): base(context, mapper) { }
    public async Task<Personal> ObtenerPorId(int id) => await GetByIdAsync(id);
    public async Task<List<Personal>> ObtenerTodos() => await GetAllAsync();
    public async Task<List<Personal>> ObtenerActivos() => await Query().Where(p => p.PersonalEstadoId == 1).ToListAsync();
    public async Task<Personal> Agregar(Personal entry)
    {
        var created = await AddAsync(entry);
        return await ObtenerPorId(created.Id);
    }
    public async Task<Personal> Modificar(Personal entry)
    {
        await UpdateAsync(entry);
        return await ObtenerPorId(entry.Id);
    }
    public async Task Eliminar(int id) => await DeleteAsync(id);
}
