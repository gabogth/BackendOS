using MediatR;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistencias.Commands
{
    public record RegistroAsistenciaModificarCommand(
        long Id,
        int EmpresaId,
        int PersonalId,
        DateTime Fecha,
        DateOnly FechaJornal,
        HorarioDetalleEventoTipoEnum TipoEvento,
        bool EsTardanza,
        int DiferenciaMinutos,
        decimal? Latitud,
        decimal? Longitud,
        long? HorarioDetalleEventoId,
        long? RegistroAsistenciaPoliticaId
    ) : IRequest<RegistroAsistencia>, IRegistroAsistenciaGenericCommand;
}
