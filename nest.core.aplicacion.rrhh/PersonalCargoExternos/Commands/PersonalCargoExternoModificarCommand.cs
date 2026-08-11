using MediatR;
using nest.core.dominio.RRHH.PersonalCargoExternoEntities;

namespace nest.core.aplicacion.rrhh.PersonalCargoExternos.Commands;

public record PersonalCargoExternoModificarCommand(
    long Id,
    int EmpresaId,
    int PersonalId,
    int CargoId,
    decimal? CostoHombre
) : IRequest<PersonalCargoExterno>, IPersonalCargoExternoGenericCommand;
