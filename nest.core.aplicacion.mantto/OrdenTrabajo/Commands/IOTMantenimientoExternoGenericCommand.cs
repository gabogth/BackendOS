using System.Collections.Generic;
using nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Commands;
using nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Commands;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.mantto.OrdenTrabajo.Commands
{
    public interface IOTMantenimientoExternoGenericCommand : ICommandBase
    {
        OrdenTrabajoCabeceraCrearCommand Cabecera { get; }

        List<OrdenTrabajoMantenimientoExternoDetalleRegistro> Detalles { get; }

        List<OrdenTrabajoPersonalCrearCommand> Personas { get; }
    }
}
