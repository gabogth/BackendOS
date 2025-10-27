using System;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Patrimonial.UbicacionActivoEntities;

namespace nest.core.aplicacion.patrimonial.UbicacionActivos.Commands
{
    public interface IUbicacionActivoGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        long ActivoId { get; }
        long UbicacionTecnicaId { get; }
        string? Comentario { get; }
        long? ContratoCabeceraId { get; }
        DateTime FechaIngreso { get; }
        DateTime? FechaSalida { get; }
    }
}
