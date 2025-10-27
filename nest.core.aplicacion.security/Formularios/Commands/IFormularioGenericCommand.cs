using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Aplicacion.Formulario;

namespace nest.core.aplicacion.security.Formularios.Commands
{
    public interface IFormularioGenericCommand : ICommandBase
    {
        int? ParentId { get; }
        int ModuloId { get; }
        string Nombre { get; }
        string NombreCorto { get; }
        string Descripcion { get; }
        string Controlador { get; }
        string Action { get; }
        string Icono { get; }
        string ClaimType { get; }
        short Orden { get; }
        bool Estado { get; }
    }
}
