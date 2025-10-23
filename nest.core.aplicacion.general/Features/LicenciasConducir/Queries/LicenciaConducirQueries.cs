using MediatR;
using nest.core.dominio.General.LicenciaConducirEntities;

namespace nest.core.aplicacion.general.Features.LicenciasConducir.Queries;

public record GetLicenciasConducirQuery() : IRequest<List<LicenciaConducir>>;

public class GetLicenciasConducirQueryHandler(ILicenciaConducirRepository repository)
    : IRequestHandler<GetLicenciasConducirQuery, List<LicenciaConducir>>
{
    public Task<List<LicenciaConducir>> Handle(GetLicenciasConducirQuery request, CancellationToken cancellationToken)
        => repository.ObtenerTodos();
}

public record GetLicenciaConducirByIdQuery(byte Id) : IRequest<LicenciaConducir>;

public class GetLicenciaConducirByIdQueryHandler(ILicenciaConducirRepository repository)
    : IRequestHandler<GetLicenciaConducirByIdQuery, LicenciaConducir>
{
    public Task<LicenciaConducir> Handle(GetLicenciaConducirByIdQuery request, CancellationToken cancellationToken)
        => repository.ObtenerPorId(request.Id);
}

public record GetLicenciasConducirActivasQuery() : IRequest<List<LicenciaConducir>>;

public class GetLicenciasConducirActivasQueryHandler(ILicenciaConducirRepository repository)
    : IRequestHandler<GetLicenciasConducirActivasQuery, List<LicenciaConducir>>
{
    public Task<List<LicenciaConducir>> Handle(GetLicenciasConducirActivasQuery request, CancellationToken cancellationToken)
        => repository.ObtenerActivos();
}
