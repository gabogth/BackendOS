using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.RRHH.CargoEntities;

namespace nest.core.aplicacion.rrhh.Cargos.Commands;

public record CargoCrearCommand(
    string Nombre,
    bool Estado
) : IRequest<Cargo>, ICargoGenericCommand;
