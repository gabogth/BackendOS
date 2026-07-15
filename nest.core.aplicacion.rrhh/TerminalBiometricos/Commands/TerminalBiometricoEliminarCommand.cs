using MediatR;
using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.rrhh.TerminalBiometricos.Commands;

public record TerminalBiometricoEliminarCommand(int Id) : IRequest<Unit>, ICommandBase;
