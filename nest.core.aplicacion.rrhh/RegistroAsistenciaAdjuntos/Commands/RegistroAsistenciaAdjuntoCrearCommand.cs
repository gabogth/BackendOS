using MediatR;
using nest.core.dominio.RRHH.RegistroAsistenciaAdjuntoEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Commands;

public record RegistroAsistenciaAdjuntoCrearCommand(
    long RegistroAsistenciaId,
    int EmpresaId,
    long AdjuntoId
) : IRequest<RegistroAsistenciaAdjunto>, IRegistroAsistenciaAdjuntoGenericCommand;
