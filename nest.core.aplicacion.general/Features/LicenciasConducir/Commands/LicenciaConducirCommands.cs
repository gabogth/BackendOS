using MediatR;
using nest.core.dominio.General.LicenciaConducirEntities;

namespace nest.core.aplicacion.general.Features.LicenciasConducir.Commands;

public record CreateLicenciaConducirCommand(string Nombre, byte Nivel) : IRequest<LicenciaConducir>;

public class CreateLicenciaConducirCommandHandler(ILicenciaConducirRepository repository)
    : IRequestHandler<CreateLicenciaConducirCommand, LicenciaConducir>
{
    public Task<LicenciaConducir> Handle(CreateLicenciaConducirCommand request, CancellationToken cancellationToken)
    {
        var dto = new LicenciaConducirCrearDto
        {
            Nombre = request.Nombre,
            Nivel = request.Nivel
        };
        return repository.Agregar(dto);
    }
}

public record UpdateLicenciaConducirCommand(byte Id, string Nombre, byte Nivel) : IRequest<LicenciaConducir>;

public class UpdateLicenciaConducirCommandHandler(ILicenciaConducirRepository repository)
    : IRequestHandler<UpdateLicenciaConducirCommand, LicenciaConducir>
{
    public Task<LicenciaConducir> Handle(UpdateLicenciaConducirCommand request, CancellationToken cancellationToken)
    {
        var dto = new LicenciaConducirCrearDto
        {
            Nombre = request.Nombre,
            Nivel = request.Nivel
        };
        return repository.Modificar(request.Id, dto);
    }
}

public record DeleteLicenciaConducirCommand(byte Id) : IRequest<Unit>;

public class DeleteLicenciaConducirCommandHandler(ILicenciaConducirRepository repository)
    : IRequestHandler<DeleteLicenciaConducirCommand, Unit>
{
    public async Task<Unit> Handle(DeleteLicenciaConducirCommand request, CancellationToken cancellationToken)
    {
        await repository.Eliminar(request.Id);
        return Unit.Value;
    }
}
