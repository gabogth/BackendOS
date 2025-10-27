using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Aplicacion.Modulo;

namespace nest.core.aplicacion.security.Modulos.Commands
{
    public interface IModuloGenericCommand : ICommandBase
    {
        string Nombre { get; }
        string NombreCorto { get; }
        string Descripcion { get; }
        string RutaImagen { get; }
        string Action { get; }
        string Controlador { get; }
        bool Estado { get; }
    }
}
