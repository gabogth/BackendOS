using System;
using System.Collections.Generic;
using System.Linq;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;
using nest.core.dominio.Mantto.OrdenTrabajoMantenimientoExternoEntities;
using nest.core.dominio.Transaccional;

namespace nest.core.aplicacion.mantto.OrdenTrabajo
{
    public class OrdenTrabajoMantenimientoExternoService
    {
        private readonly IOrdenTrabajoCabecera_MantenimientoExternoRepository repository;
        private readonly IOrdenTrabajoDetalleRepository detalleRepository;
        private readonly IOrdenTrabajoDetalleActivoRepository detalleActivoRepository;
        private readonly IUnitOfWork unitOfWork;

        public OrdenTrabajoMantenimientoExternoService(
            IOrdenTrabajoCabecera_MantenimientoExternoRepository repository,
            IOrdenTrabajoDetalleRepository detalleRepository,
            IOrdenTrabajoDetalleActivoRepository detalleActivoRepository,
            IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.detalleRepository = detalleRepository;
            this.detalleActivoRepository = detalleActivoRepository;
            this.unitOfWork = unitOfWork;
        }

        public Task<OrdenTrabajoCabecera> ObtenerPorId(long id) => repository.ObtenerPorId(id);

        public Task<List<OrdenTrabajoCabecera>> ObtenerTodos() => repository.ObtenerTodos();

        public Task<List<OrdenTrabajoCabecera>> ObtenerPorOrdenServicio(long ordenServicioCabeceraId) => repository.ObtenerPorOrdenServicio(ordenServicioCabeceraId);

        public async Task<OrdenTrabajoCabecera> Agregar(OrdenTrabajoCabecera_MantenimientoExternoCrearDto dto)
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                OrdenTrabajoCabecera cabecera = await repository.Agregar(dto.Cabecera);
                List<OrdenTrabajoDetalle_MantenimientoExternoCrearDto> detallesEntrada = dto.Detalles ?? new();
                if (detallesEntrada.Count > 0)
                {
                    OrdenTrabajoDetalleCrearDto[] detallesDtoArray = new OrdenTrabajoDetalleCrearDto[detallesEntrada.Count];
                    for (int i = 0; i < detallesEntrada.Count; i++)
                    {
                        OrdenTrabajoDetalleCrearDto currentDetalle = detallesEntrada[i].Detalle;
                        currentDetalle.EmpresaId = cabecera.EmpresaId;
                        currentDetalle.OrdenTrabajoCabeceraId = cabecera.Id;
                        detallesDtoArray[i] = currentDetalle;
                    }

                    OrdenTrabajoDetalle[] detalles = await detalleRepository.AgregarRange(detallesDtoArray);
                    List<OrdenTrabajoDetalleActivoCrearDto> activosCrear = new();
                    for (int i = 0; i < detallesEntrada.Count; i++)
                    {
                        OrdenTrabajoDetalleActivoCrearDto? activo = detallesEntrada[i].Activo;
                        if (activo != null)
                        {
                            activo.EmpresaId = cabecera.EmpresaId;
                            activo.OrdenTrabajoDetalleId = detalles[i].Id;
                            activosCrear.Add(activo);
                        }
                    }

                    if (activosCrear.Count > 0)
                        await detalleActivoRepository.AgregarRange(activosCrear.ToArray());
                }

                await unitOfWork.CommitAsync();
                return await repository.ObtenerPorId(cabecera.Id);
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                await unitOfWork.DisposeAsync();
            }
        }

        public async Task<OrdenTrabajoCabecera> Modificar(long id, OrdenTrabajoCabecera_MantenimientoExternoCrearDto dto)
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                OrdenTrabajoCabecera cabecera = await repository.Modificar(id, dto.Cabecera);
                cabecera = await repository.ObtenerPorId(cabecera.Id);

                OrdenTrabajoDetalle[] originalesDetalles = cabecera.OrdenTrabajoDetalles?.ToArray() ?? Array.Empty<OrdenTrabajoDetalle>();
                OrdenTrabajoDetalleActivo[] originalesActivos = cabecera.OrdenTrabajoDetalles?
                    .Where(x => x.OrdenTrabajoDetalleActivo != null)
                    .Select(x => x.OrdenTrabajoDetalleActivo)
                    .ToArray() ?? Array.Empty<OrdenTrabajoDetalleActivo>();

                List<OrdenTrabajoDetalle_MantenimientoExternoCrearDto> detallesEntrada = dto.Detalles ?? new();
                (long id, OrdenTrabajoDetalleCrearDto entry)[] detallesConIdDto = new (long, OrdenTrabajoDetalleCrearDto)[detallesEntrada.Count];
                for (int i = 0; i < detallesEntrada.Count; i++)
                {
                    OrdenTrabajoDetalle_MantenimientoExternoCrearDto current = detallesEntrada[i];
                    OrdenTrabajoDetalleCrearDto currentDetalle = current.Detalle;
                    currentDetalle.EmpresaId = cabecera.EmpresaId;
                    currentDetalle.OrdenTrabajoCabeceraId = cabecera.Id;
                    long detalleId = current.DetalleId ?? 0;
                    detallesConIdDto[i] = (detalleId, currentDetalle);
                }

                OrdenTrabajoDetalle[] detalles = await detalleRepository.FusionarRange(originalesDetalles, detallesConIdDto);

                List<(long id, OrdenTrabajoDetalleActivoCrearDto entry)> activosEntries = new();
                for (int i = 0; i < detallesEntrada.Count; i++)
                {
                    OrdenTrabajoDetalleActivoCrearDto? activo = detallesEntrada[i].Activo;
                    if (activo != null)
                    {
                        activo.EmpresaId = cabecera.EmpresaId;
                        activo.OrdenTrabajoDetalleId = detalles[i].Id;
                        long activoId = detallesEntrada[i].DetalleActivoId ?? 0;
                        activosEntries.Add((activoId, activo));
                    }
                }

                if (activosEntries.Count > 0)
                {
                    await detalleActivoRepository.FusionarRange(originalesActivos, activosEntries.ToArray());
                }
                else if (originalesActivos.Length > 0)
                {
                    long[] idsEliminar = originalesActivos.Select(x => x.Id).ToArray();
                    await detalleActivoRepository.EliminarRange(idsEliminar);
                }

                await unitOfWork.CommitAsync();
                return await repository.ObtenerPorId(cabecera.Id);
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                await unitOfWork.DisposeAsync();
            }
        }

        public Task Eliminar(long id) => repository.Eliminar(id);
    }
}
