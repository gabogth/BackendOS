using System;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;

namespace nest.core.aplicacion.rrhh.HorarioDetalleEventos.Commands
{
    public interface IHorarioDetalleEventoGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        long HorarioDetalleId { get; }
        HorarioDetalleEventoTipoEnum TipoEvento { get; }
        TimeOnly Hora { get; }
        int DiferenciaDia { get; }
        int VentanaMin { get; }
        int VentanaMax { get; }
    }
}
