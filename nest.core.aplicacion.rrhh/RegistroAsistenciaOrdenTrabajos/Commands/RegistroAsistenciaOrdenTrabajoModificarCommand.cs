using MediatR;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Commands;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Commands
{
    public record RegistroAsistenciaOrdenTrabajoModificarCommand(
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
        long? RegistroAsistenciaPoliticaId,
        long OrdenTrabajoCabeceraId
    ) : IRequest<RegistroAsistencia>, IRegistroAsistenciaGenericCommand;
}
