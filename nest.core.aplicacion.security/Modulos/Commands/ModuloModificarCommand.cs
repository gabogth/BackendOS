using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Aplicacion.Modulo;

namespace nest.core.aplicacion.security.Modulos.Commands;

public record ModuloModificarCommand(
    int Id,
    string Nombre,
    string NombreCorto,
    string Descripcion,
    string RutaImagen,
    string Action,
    string Controlador,
    bool Estado
) : IRequest<Modulo>, IModuloGenericCommand;
