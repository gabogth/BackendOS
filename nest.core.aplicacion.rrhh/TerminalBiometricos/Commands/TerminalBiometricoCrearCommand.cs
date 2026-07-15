using MediatR;
using nest.core.dominio.RRHH.TerminalBiometricoEntities;

namespace nest.core.aplicacion.rrhh.TerminalBiometricos.Commands;

public record TerminalBiometricoCrearCommand(
    int EmpresaId,
    string Nombre,
    string SN
) : IRequest<TerminalBiometrico>, ITerminalBiometricoGenericCommand;
