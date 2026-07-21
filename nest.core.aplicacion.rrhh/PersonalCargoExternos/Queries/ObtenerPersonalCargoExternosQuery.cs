using MediatR;
using nest.core.dominio.RRHH.PersonalCargoExternoEntities;

namespace nest.core.aplicacion.rrhh.PersonalCargoExternos.Queries;

public record ObtenerPersonalCargoExternosQuery() : IRequest<List<PersonalCargoExterno>>;
