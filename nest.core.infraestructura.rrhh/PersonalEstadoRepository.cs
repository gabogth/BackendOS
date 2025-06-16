using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.RRHH.PersonalEstadoEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.rrhh
{
    public class PersonalEstadoRepository : CachedRepositoryBase<PersonalEstado, PersonalEstadoCrearDto, byte>, IPersonalEstadoRepository
    {
        public PersonalEstadoRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }

        public async Task<PersonalEstado> ObtenerPorId(byte id) => await GetByIdAsync(id);
        public async Task<List<PersonalEstado>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<PersonalEstado>> ObtenerActivos() => await GetAllAsync();
        public Task<PersonalEstado> Agregar(PersonalEstadoCrearDto dto) => AddAsync(dto);
        public Task<PersonalEstado> Modificar(byte id, PersonalEstadoCrearDto dto) => UpdateAsync(id, dto);
        public Task Eliminar(byte id) => DeleteAsync(id);
    }
}
