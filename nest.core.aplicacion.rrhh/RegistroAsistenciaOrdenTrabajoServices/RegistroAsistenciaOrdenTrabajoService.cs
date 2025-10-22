using nest.core.aplicacion.rrhh.RegistroAsistenciaServices;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaOrdenTrabajoEntities;
using nest.core.dominio.Security.Tenant;
using nest.core.dominio.Transaccional;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajoServices
{
    public class RegistroAsistenciaOrdenTrabajoService : RegistroAsistenciaService
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IRegistroAsistenciaOrdenTrabajoRepository regOt;
        protected readonly IOrdenTrabajoCabeceraRepository ordenTrabajoCabeceraRepository;
        public RegistroAsistenciaOrdenTrabajoService(IRegistroAsistencia_OrdenTrabajoRepository repository, IHorarioRepository horarioRepository, IPersonalRepository personalRepository, IHorarioDetalleRepository horarioDetalleRepository, IConnectionStringService connectionStringService, IUnitOfWork unitOfWork, IRegistroAsistenciaOrdenTrabajoRepository regOt, IOrdenTrabajoCabeceraRepository ordenTrabajoCabeceraRepository) 
            : base(repository, horarioRepository, personalRepository, horarioDetalleRepository, connectionStringService)
        {
            this.unitOfWork = unitOfWork;
            this.regOt = regOt;
            this.ordenTrabajoCabeceraRepository = ordenTrabajoCabeceraRepository;
        }
        public override async Task<RegistroAsistencia> Agregar(RegistroAsistenciaCrearDto entry)
        {
            await this.unitOfWork.BeginTransactionAsync();
            try
            {
                OrdenTrabajoCabecera ot = await this.ordenTrabajoCabeceraRepository.ObtenerPorPersonaFechaInicialFechaFinal(entry.PersonalId, entry.Fecha);
                if(ot == null)
                    throw new Exception($"No existe una orden de trabajo asignada para el personal en la fecha {entry.Fecha.ToString("yyyy-MM-dd HH:mm:ss")}.");
                RegistroAsistencia registro = await base.Agregar(entry);
                RegistroAsistenciaOrdenTrabajoCrearDto regOtDto = new RegistroAsistenciaOrdenTrabajoCrearDto
                {
                    EmpresaId = registro.EmpresaId,
                    Id = registro.Id,
                    OrdenTrabajoCabeceraId = ot.Id
                };
                await regOt.Agregar(regOtDto);
                return await repository.ObtenerPorId(registro.Id);
            }
            catch (Exception)
            {
                await this.unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                await this.unitOfWork.DisposeAsync();
            }
        }
        public async Task<RegistroAsistencia> ModificarOt(long id, RegistroAsistencia_OrdenTrabajoCrearDto entry)
        {
            await this.unitOfWork.BeginTransactionAsync();
            try
            {
                RegistroAsistencia registro = await base.Modificar(id, entry);
                RegistroAsistenciaOrdenTrabajoCrearDto regOtDto = new RegistroAsistenciaOrdenTrabajoCrearDto
                {
                    EmpresaId = registro.EmpresaId,
                    Id = registro.Id,
                    OrdenTrabajoCabeceraId = entry.OrdenTrabajoCabeceraId
                };
                await regOt.Modificar(id, regOtDto);
                return await repository.ObtenerPorId(registro.Id);
            }
            catch (Exception)
            {
                await this.unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                await this.unitOfWork.DisposeAsync();
            }
        }
    }
}
