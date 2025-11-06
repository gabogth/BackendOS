using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Commands;
using nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Commands;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajo.Commands
{
    public record OrdenTrabajoMantenimientoExternoRegistroCommand : IOTMantenimientoExternoGenericCommand
    {
        [Required]
        public OrdenTrabajoCabeceraCrearCommand Cabecera { get; init; } = default!;

        [MinLength(1)]
        public List<OrdenTrabajoMantenimientoExternoDetalleRegistro> Detalles { get; init; } = new();

        [MinLength(1)]
        public List<OrdenTrabajoPersonalCrearCommand> Personas { get; init; } = new();
    }

    public sealed record OrdenTrabajoMantenimientoExternoDetalleRegistro
    {
        [Required]
        public OrdenTrabajoDetalleUpsertCommand Detalle { get; init; } = new();

        [Required]
        public OrdenTrabajoMantenimientoExternoDetalleActivoRegistro Activo { get; init; } = new();
    }

    public sealed record OrdenTrabajoDetalleUpsertCommand
    {
        public long Id { get; init; }

        [Range(0, int.MaxValue)]
        public int EmpresaId { get; init; }

        [Range(0, long.MaxValue)]
        public long OrdenTrabajoCabeceraId { get; init; }

        [Range(1, long.MaxValue)]
        public long UbicacionTecnicaId { get; init; }

        [Range(1, int.MaxValue)]
        public int LaborId { get; init; }

        [Range(0, int.MaxValue)]
        public int HorasProyectadas { get; init; }

        [Range(0, int.MaxValue)]
        public int HorasEjecutadas { get; init; }

        public string? Descripcion { get; init; }

        [Required]
        public OrdenTrabajoDetalleEstado Estado { get; init; }
    }

    public sealed record OrdenTrabajoMantenimientoExternoDetalleActivoRegistro
    {
        public long Id { get; init; }

        [Range(0, int.MaxValue)]
        public int EmpresaId { get; init; }

        [Range(0, long.MaxValue)]
        public long OrdenTrabajoDetalleId { get; init; }

        [Range(1, long.MaxValue)]
        public long ActivoId { get; init; }
    }
}
