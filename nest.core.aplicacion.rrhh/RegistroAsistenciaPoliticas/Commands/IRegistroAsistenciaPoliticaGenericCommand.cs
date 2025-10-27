using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Commands
{
    public interface IRegistroAsistenciaPoliticaGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        string Nombre { get; }
        string NombreCorto { get; }
        string Descripcion { get; }
        int MinutosTardanzaIngreso { get; }
        int MinutosExtra { get; }
        int MinutosExtraEntrada { get; }
        bool TieneCompletarHora { get; }
    }
}
