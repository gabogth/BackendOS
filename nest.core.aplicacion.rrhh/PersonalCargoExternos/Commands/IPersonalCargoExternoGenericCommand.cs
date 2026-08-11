using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.rrhh.PersonalCargoExternos.Commands
{
    public interface IPersonalCargoExternoGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        int PersonalId { get; }
        int CargoId { get; }
        decimal? CostoHombre { get; }
    }
}
