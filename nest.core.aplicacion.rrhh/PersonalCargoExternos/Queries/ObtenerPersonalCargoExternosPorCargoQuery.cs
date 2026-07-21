using MediatR;
using nest.core.dominio.RRHH.PersonalCargoExternoEntities;

namespace nest.core.aplicacion.rrhh.PersonalCargoExternos.Queries;

public record ObtenerPersonalCargoExternosPorCargoQuery(int CargoId) : IRequest<List<PersonalCargoExterno>>;
