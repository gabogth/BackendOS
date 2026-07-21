using MediatR;
using nest.core.dominio.RRHH.PersonalCargoExternoEntities;

namespace nest.core.aplicacion.rrhh.PersonalCargoExternos.Queries;

public record ObtenerPersonalCargoExternoPorIdQuery(long Id) : IRequest<PersonalCargoExterno>;
