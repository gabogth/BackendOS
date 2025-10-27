using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.LicenciaConducirEntities;

namespace nest.core.aplicacion.general.LicenciasConducir.Commands
{
    public sealed record LicenciaConducirCrearCommand(
        string Nombre,
        byte Nivel
    ) : IRequest<LicenciaConducir>, ILicenciaConducirGenericCommand;
}
