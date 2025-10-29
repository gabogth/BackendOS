using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.RRHH.PersonalEntities;

namespace nest.core.aplicacion.rrhh.Personales.Commands
{
    public interface IPersonalGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        bool MarcaAsistencia { get; }
        long ContratoCabeceraId { get; }
        int HorarioCabeceraId { get; }
        int? SuperiorId { get; }
        byte PersonalEstadoId { get; }
        long RegistroAsistenciaPoliticaId { get; }
        int? UsuarioId { get; }
    }
}
