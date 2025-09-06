using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.General.LicenciaConducirEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.general
{
    public class LicenciaConducirRepository : CachedRepositoryBase<LicenciaConducir, LicenciaConducirCrearDto, byte>, ILicenciaConducirRepository
    {
        public LicenciaConducirRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }
        public async Task<LicenciaConducir> ObtenerPorId(byte id) => await GetByIdAsync(id);
        public async Task<List<LicenciaConducir>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<LicenciaConducir>> ObtenerActivos() => await GetAllAsync();
        public Task<LicenciaConducir> Agregar(LicenciaConducirCrearDto dto) => AddAsync(dto);
        public Task<LicenciaConducir> Modificar(byte id, LicenciaConducirCrearDto dto) => UpdateAsync(id, dto);
        public Task Eliminar(byte id) => DeleteAsync(id);
    }
}
