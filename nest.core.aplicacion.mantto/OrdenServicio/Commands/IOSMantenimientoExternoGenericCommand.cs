using nest.core.aplicacion.mantto.OrdenServicioCabeceras.Commands;
using nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Commands;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.mantto.OrdenServicio.Commands
{
    public interface IOSMantenimientoExternoGenericCommand: ICommandBase
    {
        public OrdenServicioCabeceraCrearCommand Cabecera { get; }
        public OrdenServicioMantenimientoExternoCrearCommand Externo { get; }
    }
}
