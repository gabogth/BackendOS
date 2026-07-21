using MediatR;
using nest.core.dominio.RRHH.PersonalCargoExternoEntities;

namespace nest.core.aplicacion.rrhh.PersonalCargoExternos.Commands;

public record PersonalCargoExternoCrearCommand(
    int EmpresaId,
    int PersonalId,
    int CargoId
) : IRequest<PersonalCargoExterno>, IPersonalCargoExternoGenericCommand;
