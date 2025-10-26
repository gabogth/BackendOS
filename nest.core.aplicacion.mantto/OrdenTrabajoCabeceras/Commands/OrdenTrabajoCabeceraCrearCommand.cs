using MediatR;
using System;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Commands
{
    public sealed record OrdenTrabajoCabeceraCrearCommand(
        int EmpresaId,
        long OrdenServicioCabeceraId,
        string Nombre,
        string? Descripcion,
        DateTime FechaInicio,
        DateTime FechaCompromiso,
        DateTime? FechaFin,
        long? GrupoTrabajoId,
        long? OrdenTrabajoCabeceraPadreId,
        OrdenTrabajoEstado Estado
    ) : IRequest<OrdenTrabajoCabecera>, ICommandBase;
}
