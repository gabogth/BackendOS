using System;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Commands
{
    public interface IOrdenTrabajoCabeceraGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        long OrdenServicioCabeceraId { get; }
        string Nombre { get; }
        string? Descripcion { get; }
        DateTime FechaInicio { get; }
        DateTime FechaCompromiso { get; }
        DateTime? FechaFin { get; }
        long? GrupoTrabajoId { get; }
        long? OrdenTrabajoCabeceraPadreId { get; }
        OrdenTrabajoEstado Estado { get; }
    }
}
