using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;

namespace nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Commands
{
    public record OrdenTrabajoPersonalCrearCommand(
        long Id,
        int EmpresaId,
        long OrdenTrabajoCabeceraId,
        int PersonaId,
        bool EsLider
    ) : IRequest<OrdenTrabajoPersonal>, ICommandBase;
}
