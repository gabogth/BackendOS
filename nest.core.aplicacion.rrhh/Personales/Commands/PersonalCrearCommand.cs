using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.RRHH.PersonalEntities;

namespace nest.core.aplicacion.rrhh.Personales.Commands;

public record PersonalCrearCommand(
    int EmpresaId,
    int Id,
    bool MarcaAsistencia,
    long ContratoCabeceraId,
    int HorarioCabeceraId,
    int? SuperiorId,
    byte PersonalEstadoId,
    long RegistroAsistenciaPoliticaId,
    int? UsuarioId
) : IRequest<Personal>, IPersonalGenericCommand;
