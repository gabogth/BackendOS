using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.RRHH.PersonalEstadoEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.rrhh;

public class PersonalEstadoRepository : CachedRepositoryBase<PersonalEstado, byte>, IPersonalEstadoRepository
{
    public PersonalEstadoRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }

    public async Task<PersonalEstado> ObtenerPorId(byte id) => await GetByIdAsync(id);
    public async Task<List<PersonalEstado>> ObtenerTodos() => await GetAllAsync();
    public async Task<List<PersonalEstado>> ObtenerActivos() => await GetAllAsync();
    public Task<PersonalEstado> Agregar(PersonalEstado dto) => AddAsync(dto);
    public async Task<PersonalEstado> Modificar(PersonalEstado dto)
    {
        var updated = await UpdateAsync(dto);
        return await ObtenerPorId(updated.Id);
    }
    public Task Eliminar(byte id) => DeleteAsync(id);
}
