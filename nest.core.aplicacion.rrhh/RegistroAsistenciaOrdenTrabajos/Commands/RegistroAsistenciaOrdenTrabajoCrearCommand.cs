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
        decimal? Latitud,
        decimal? Longitud,
        long AdjuntoId
    ) : IRequest<RegistroAsistencia>, IRegistroAsistenciaGenericCommand;
}
