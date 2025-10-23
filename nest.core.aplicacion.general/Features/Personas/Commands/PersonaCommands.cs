using MediatR;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.aplicacion.general.Features.Personas.Commands;

public record CreatePersonaCommand(
    int EmpresaId,
    string Nombres,
    string ApellidoPaterno,
    string ApellidoMaterno,
    DateTime FechaNacimiento,
    string DocumentoIdentidad,
    string Correo,
    string Celular,
    bool Estado,
    byte SexoId,
    int DistritoId,
    byte? LicenciaConducirId,
    byte DocumentoIdentidadTipoId) : IRequest<Persona>;

public class CreatePersonaCommandHandler(IPersonaRepository repository)
    : IRequestHandler<CreatePersonaCommand, Persona>
{
    public Task<Persona> Handle(CreatePersonaCommand request, CancellationToken cancellationToken)
    {
        var dto = new PersonaCrearDto
        {
            EmpresaId = request.EmpresaId,
            Nombres = request.Nombres,
            ApellidoPaterno = request.ApellidoPaterno,
            ApellidoMaterno = request.ApellidoMaterno,
            FechaNacimiento = request.FechaNacimiento,
            DocumentoIdentidad = request.DocumentoIdentidad,
            Correo = request.Correo,
            Celular = request.Celular,
            Estado = request.Estado,
            SexoId = request.SexoId,
            DistritoId = request.DistritoId,
            LicenciaConducirId = request.LicenciaConducirId,
            DocumentoIdentidadTipoId = request.DocumentoIdentidadTipoId
        };
        return repository.Agregar(dto);
    }
}

public record UpdatePersonaCommand(
    int Id,
    int EmpresaId,
    string Nombres,
    string ApellidoPaterno,
    string ApellidoMaterno,
    DateTime FechaNacimiento,
    string DocumentoIdentidad,
    string Correo,
    string Celular,
    bool Estado,
    byte SexoId,
    int DistritoId,
    byte? LicenciaConducirId,
    byte DocumentoIdentidadTipoId) : IRequest<Persona>;

public class UpdatePersonaCommandHandler(IPersonaRepository repository)
    : IRequestHandler<UpdatePersonaCommand, Persona>
{
    public Task<Persona> Handle(UpdatePersonaCommand request, CancellationToken cancellationToken)
    {
        var dto = new PersonaCrearDto
        {
            EmpresaId = request.EmpresaId,
            Nombres = request.Nombres,
            ApellidoPaterno = request.ApellidoPaterno,
            ApellidoMaterno = request.ApellidoMaterno,
            FechaNacimiento = request.FechaNacimiento,
            DocumentoIdentidad = request.DocumentoIdentidad,
            Correo = request.Correo,
            Celular = request.Celular,
            Estado = request.Estado,
            SexoId = request.SexoId,
            DistritoId = request.DistritoId,
            LicenciaConducirId = request.LicenciaConducirId,
            DocumentoIdentidadTipoId = request.DocumentoIdentidadTipoId
        };
        return repository.Modificar(request.Id, dto);
    }
}

public record DeletePersonaCommand(int Id) : IRequest<Unit>;

public class DeletePersonaCommandHandler(IPersonaRepository repository)
    : IRequestHandler<DeletePersonaCommand, Unit>
{
    public async Task<Unit> Handle(DeletePersonaCommand request, CancellationToken cancellationToken)
    {
        await repository.Eliminar(request.Id);
        return Unit.Value;
    }
}
