using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.rrhh
{
    public class RegistroAsistenciaRepository : CrudRepositoryBase<RegistroAsistencia, long>, IRegistroAsistenciaRepository
    {
        public RegistroAsistenciaRepository(NestDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<RegistroAsistencia> Query() => context.Set<RegistroAsistencia>()
            .AsNoTracking()
            .Include(x => x.Personal)
            .Include(x => x.RegistroAsistenciaPolitica)
            .Include(x => x.HorarioDetalleEvento);

        public async Task<RegistroAsistencia> ObtenerPorId(long id) =>
            await GetByIdAsync(id) ?? throw new RegistroNoEncontradoException<RegistroAsistencia>(id.ToString());
        public Task<List<RegistroAsistencia>> ObtenerTodos() => GetAllAsync();

        public async Task<List<RegistroAsistencia>> BuscarPorRangoFecha(int personalId, DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaFin < fechaInicio)
            {
                (fechaInicio, fechaFin) = (fechaFin, fechaInicio);
            }

            return await Query()
                .Where(x => x.PersonalId == personalId && x.Fecha >= fechaInicio && x.Fecha <= fechaFin)
                .OrderBy(x => x.Fecha)
                .ToListAsync();
        }
        public async Task<RegistroAsistencia> BuscarPorRangoFecha(int personalId, DateTime fechaInicio, DateTime fechaFin, HorarioDetalleEventoTipoEnum tipoMarca)
        {
            if (fechaFin < fechaInicio)
                (fechaInicio, fechaFin) = (fechaFin, fechaInicio);

            return await Query()
                .Where(x => x.PersonalId == personalId && x.Fecha >= fechaInicio && x.Fecha <= fechaFin && x.TipoEvento == tipoMarca)
                .OrderByDescending(x => x.Fecha)
                .FirstOrDefaultAsync();
        }
        public async Task<RegistroAsistencia> BuscarUltimaMarca(int personalId)
        {
            return await Query()
                .Where(x => x.PersonalId == personalId)
                .OrderByDescending(x => x.Fecha)
                .FirstOrDefaultAsync();
        }

        public async Task<RegistroAsistencia> Agregar(RegistroAsistencia entry)
        {
            var registro = await AddAsync(entry);
            return await ObtenerPorId(registro.Id);
        }

        public async Task<RegistroAsistencia> Modificar(RegistroAsistencia entry)
        {
            await UpdateAsync(entry);
            return await ObtenerPorId(entry.Id);
        }

        public Task Eliminar(long id) => DeleteAsync(id);
    }
}
