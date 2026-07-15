using MediatR;
using nest.core.dominio.RRHH.TerminalBiometricoEntities;

namespace nest.core.aplicacion.rrhh.TerminalBiometricos.Queries;

public record ObtenerTerminalBiometricoPorIdQuery(int Id) : IRequest<TerminalBiometrico>;
