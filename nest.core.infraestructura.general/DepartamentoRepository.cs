using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.General.DepartamentoEntites;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.general
{
    public class DepartamentoRepository : CachedRepositoryBase<Departamento, DepartamentoCrearDto, int>, IDepartamentoRepository
    {
        public DepartamentoRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache) { }
        public async Task<Departamento> ObtenerPorId(int id) => await GetByIdAsync(id);
        public async Task<List<Departamento>> ObtenerTodos() => await GetAllAsync();
        public async Task<Departamento> Agregar(DepartamentoCrearDto dto) => await AddAsync(dto);
        public async Task<Departamento> Modificar(int id, DepartamentoCrearDto dto) => await UpdateAsync(id, dto);
        public async Task Eliminar(int id) => await DeleteAsync(id);
    }
}
