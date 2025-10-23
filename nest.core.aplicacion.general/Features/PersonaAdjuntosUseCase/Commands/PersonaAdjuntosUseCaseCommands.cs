using MediatR;
using nest.core.dominio.General.PersonaAdjuntoEntities;
using nest.core.dominio.General.PersonaEntities;
using nest.core.dominio.Transaccional;

namespace nest.core.aplicacion.general.Features.PersonaAdjuntosUseCase.Commands;

public record PersonaAdjuntoEntryDto(
    long Id,
    long AdjuntoId,
    AdjuntoTipoEnum AdjuntoTipoId,
    bool EsFotoPrincipal);

public record PersonaAdjuntosPersonaDto(
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
    byte DocumentoIdentidadTipoId);

public record CreatePersonaAdjuntosCommand(
    PersonaAdjuntosPersonaDto Persona,
    List<PersonaAdjuntoEntryDto> PersonaAdjuntos) : IRequest<Persona>;

public class CreatePersonaAdjuntosCommandHandler(
    IPersonaAdjuntosUseCaseRepository personaRepository,
    IPersonaAdjuntoRepository personaAdjuntoRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreatePersonaAdjuntosCommand, Persona>
{
    public async Task<Persona> Handle(CreatePersonaAdjuntosCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request.Persona);
        await unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var personaDto = MapPersona(request.Persona);
            Persona persona = await personaRepository.Agregar(personaDto);

            PersonaAdjuntoCrearDto[] adjuntos = request.PersonaAdjuntos
                .Select(dto => new PersonaAdjuntoCrearDto
                {
                    Id = 0,
                    PersonaId = persona.Id,
                    EmpresaId = persona.EmpresaId,
                    AdjuntoId = dto.AdjuntoId,
                    AdjuntoTipoId = dto.AdjuntoTipoId,
                    EsFotoPrincipal = dto.EsFotoPrincipal
                })
                .ToArray();

            if (adjuntos.Length > 0)
                await personaAdjuntoRepository.AgregarRange(adjuntos);

            await unitOfWork.CommitAsync(cancellationToken);
            return await personaRepository.ObtenerPorId(persona.Id);
        }
        catch
        {
            await unitOfWork.RollbackAsync(cancellationToken);
            throw;
        }
        finally
        {
            await unitOfWork.DisposeAsync();
        }
    }
}

public record UpdatePersonaAdjuntosCommand(
    int Id,
    PersonaAdjuntosPersonaDto Persona,
    List<PersonaAdjuntoEntryDto> PersonaAdjuntos) : IRequest<Persona>;

public class UpdatePersonaAdjuntosCommandHandler(
    IPersonaAdjuntosUseCaseRepository personaRepository,
    IPersonaAdjuntoRepository personaAdjuntoRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<UpdatePersonaAdjuntosCommand, Persona>
{
    public async Task<Persona> Handle(UpdatePersonaAdjuntosCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request.Persona);
        await unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var personaDto = MapPersona(request.Persona);
            Persona persona = await personaRepository.Modificar(request.Id, personaDto);
            persona = await personaRepository.ObtenerPorId(persona.Id);

            PersonaAdjunto[] originales = persona.PersonaAdjuntos?.ToArray() ?? Array.Empty<PersonaAdjunto>();

            (long id, PersonaAdjuntoCrearDto entry)[] entradas = request.PersonaAdjuntos
                .Select(dto => (dto.Id, new PersonaAdjuntoCrearDto
                {
                    Id = dto.Id,
                    PersonaId = persona.Id,
                    EmpresaId = persona.EmpresaId,
                    AdjuntoId = dto.AdjuntoId,
                    AdjuntoTipoId = dto.AdjuntoTipoId,
                    EsFotoPrincipal = dto.EsFotoPrincipal
                }))
                .ToArray();

            await personaAdjuntoRepository.FusionarRange(originales, entradas);

            await unitOfWork.CommitAsync(cancellationToken);
            return await personaRepository.ObtenerPorId(persona.Id);
        }
        catch
        {
            await unitOfWork.RollbackAsync(cancellationToken);
            throw;
        }
        finally
        {
            await unitOfWork.DisposeAsync();
        }
    }
}

public record DeletePersonaAdjuntosCommand(int Id) : IRequest<Unit>;

public class DeletePersonaAdjuntosCommandHandler(
    IPersonaAdjuntosUseCaseRepository personaRepository)
    : IRequestHandler<DeletePersonaAdjuntosCommand, Unit>
{
    public async Task<Unit> Handle(DeletePersonaAdjuntosCommand request, CancellationToken cancellationToken)
    {
        await personaRepository.Eliminar(request.Id);
        return Unit.Value;
    }
}

internal static PersonaCrearDto MapPersona(PersonaAdjuntosPersonaDto persona)
    => new()
    {
        EmpresaId = persona.EmpresaId,
        Nombres = persona.Nombres,
        ApellidoPaterno = persona.ApellidoPaterno,
        ApellidoMaterno = persona.ApellidoMaterno,
        FechaNacimiento = persona.FechaNacimiento,
        DocumentoIdentidad = persona.DocumentoIdentidad,
        Correo = persona.Correo,
        Celular = persona.Celular,
        Estado = persona.Estado,
        SexoId = persona.SexoId,
        DistritoId = persona.DistritoId,
        LicenciaConducirId = persona.LicenciaConducirId,
        DocumentoIdentidadTipoId = persona.DocumentoIdentidadTipoId
    };
