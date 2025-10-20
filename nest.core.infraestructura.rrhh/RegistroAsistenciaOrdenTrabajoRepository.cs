using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.RegistroAsistenciaOrdenTrabajoEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.rrhh
{
    public class RegistroAsistenciaOrdenTrabajoRepository : CrudRepositoryBase<RegistroAsistenciaOrdenTrabajo, RegistroAsistenciaOrdenTrabajoCrearDto, long>, IRegistroAsistenciaOrdenTrabajoRepository
    {
        public RegistroAsistenciaOrdenTrabajoRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<RegistroAsistenciaOrdenTrabajo> Query() => context.Set<RegistroAsistenciaOrdenTrabajo>()
            .AsNoTracking()
            .Include(x => x.RegistroAsistencia)
            .Include(x => x.OrdenTrabajoCabecera);

        public async Task<RegistroAsistenciaOrdenTrabajo> ObtenerPorId(long id) =>
            await GetByIdAsync(id) ?? throw new RegistroNoEncontradoException<RegistroAsistenciaOrdenTrabajo>(id.ToString());

        public Task<List<RegistroAsistenciaOrdenTrabajo>> ObtenerTodos() => GetAllAsync();

        public async Task<RegistroAsistenciaOrdenTrabajo> Agregar(RegistroAsistenciaOrdenTrabajoCrearDto entry)
        {
            var registro = await AddAsync(entry);
            return await ObtenerPorId(registro.Id);
        }

        public async Task<RegistroAsistenciaOrdenTrabajo> Modificar(long id, RegistroAsistenciaOrdenTrabajoCrearDto entry)
        {
            entry.Id = id;
            await UpdateAsync(id, entry);
            return await ObtenerPorId(id);
        }

        public Task Eliminar(long id) => DeleteAsync(id);
    }
}
