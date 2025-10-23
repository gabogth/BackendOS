using MediatR;
using nest.core.dominio.General.DepartamentoEntites;

namespace nest.core.aplicacion.general.Features.Departamentos.Commands;

public record DepartamentoWriteDto(string Nombre, int PaisId);

public record CreateDepartamentoCommand(string Nombre, int PaisId) : IRequest<Departamento>;

public class CreateDepartamentoCommandHandler(IDepartamentoRepository repository)
    : IRequestHandler<CreateDepartamentoCommand, Departamento>
{
    public Task<Departamento> Handle(CreateDepartamentoCommand request, CancellationToken cancellationToken)
    {
        var dto = new DepartamentoCrearDto
        {
            Nombre = request.Nombre,
            PaisId = request.PaisId
        };
        return repository.Agregar(dto);
    }
}

public record UpdateDepartamentoCommand(int Id, string Nombre, int PaisId) : IRequest<Departamento>;

public class UpdateDepartamentoCommandHandler(IDepartamentoRepository repository)
    : IRequestHandler<UpdateDepartamentoCommand, Departamento>
{
    public Task<Departamento> Handle(UpdateDepartamentoCommand request, CancellationToken cancellationToken)
    {
        var dto = new DepartamentoCrearDto
        {
            Nombre = request.Nombre,
            PaisId = request.PaisId
        };
        return repository.Modificar(request.Id, dto);
    }
}

public record DeleteDepartamentoCommand(int Id) : IRequest<Unit>;

public class DeleteDepartamentoCommandHandler(IDepartamentoRepository repository)
    : IRequestHandler<DeleteDepartamentoCommand, Unit>
{
    public async Task<Unit> Handle(DeleteDepartamentoCommand request, CancellationToken cancellationToken)
    {
        await repository.Eliminar(request.Id);
        return Unit.Value;
    }
}
