using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.LicenciaConducirEntities;

namespace nest.core.aplicacion.general.LicenciasConducir.Commands
{
    public sealed record LicenciaConducirModificarCommand(
        byte Id,
        string Nombre,
        byte Nivel
    ) : IRequest<LicenciaConducir>, ILicenciaConducirGenericCommand;
}
