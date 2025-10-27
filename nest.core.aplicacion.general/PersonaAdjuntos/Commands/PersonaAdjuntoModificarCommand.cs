using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.AdjuntoTipoEntities;
using nest.core.dominio.General.PersonaAdjuntoEntities;

namespace nest.core.aplicacion.general.PersonaAdjuntos.Commands
{
    public sealed record PersonaAdjuntoModificarCommand(
        long Id,
        int EmpresaId,
        int PersonaId,
        long AdjuntoId,
        AdjuntoTipoEnum AdjuntoTipoId,
        bool EsFotoPrincipal
    ) : IRequest<PersonaAdjunto>, IPersonaAdjuntoGenericCommand;
}
