using nest.core.dominio.General.AdjuntoTipoEntities;

namespace nest.core.aplicacion.general.PersonaUseCases.Commands
{
    public sealed record PersonaAdjuntoItemCommand(
        long? Id,
        long AdjuntoId,
        AdjuntoTipoEnum AdjuntoTipoId,
        bool EsFotoPrincipal
    );
}
