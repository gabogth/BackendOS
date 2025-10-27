using MediatR;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Commands;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Commands
{
    public record RegistroAsistenciaOrdenTrabajoCrearCommand(
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
