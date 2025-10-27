using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.LicenciaConducirEntities;

namespace nest.core.aplicacion.general.LicenciasConducir.Commands
{
    public interface ILicenciaConducirGenericCommand : ICommandBase
    {
        string Nombre { get; }
        byte Nivel { get; }
    }
}
