using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Commands
{
    public interface IRegistroAsistenciaGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        int PersonalId { get; }
        DateTime Fecha { get; }
        DateOnly FechaJornal { get; }
        HorarioDetalleEventoTipoEnum TipoEvento { get; }
        bool EsTardanza { get; }
        int DiferenciaMinutos { get; }
        decimal? Latitud { get; }
        decimal? Longitud { get; }
        long? HorarioDetalleEventoId { get; }
        long? RegistroAsistenciaPoliticaId { get; }
    }
}
