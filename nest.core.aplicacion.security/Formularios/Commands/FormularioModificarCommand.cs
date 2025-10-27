using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Aplicacion.Formulario;

namespace nest.core.aplicacion.security.Formularios.Commands;

public record FormularioModificarCommand(
    int Id,
    int? ParentId,
    int ModuloId,
    string Nombre,
    string NombreCorto,
    string Descripcion,
    string Controlador,
    string Action,
    string Icono,
    string ClaimType,
    short Orden,
    bool Estado
) : IRequest<Formulario>, IFormularioGenericCommand;
