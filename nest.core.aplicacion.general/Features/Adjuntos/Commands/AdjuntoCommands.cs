using MediatR;
using nest.core.dominio.General.AdjuntoEntities;
using nest.core.dominio.General.AdjuntoProviderEntities;

namespace nest.core.aplicacion.general.Features.Adjuntos.Commands;

public record CreateAdjuntoCommand(AdjuntoConfigProviderModuloEnum Modulo, AdjuntoUploadDto Archivo) : IRequest<Adjunto>;

public class CreateAdjuntoCommandHandler : IRequestHandler<CreateAdjuntoCommand, Adjunto>
{
    private readonly IAdjuntoRepository repository;
    private readonly IAdjuntoConfigProviderRepository configRepository;
    private readonly Dictionary<AdjuntoProviderEnum, IAdjuntoStorageService> storageServices;

    public CreateAdjuntoCommandHandler(
        IAdjuntoRepository repository,
        IAdjuntoConfigProviderRepository configRepository,
        IEnumerable<IAdjuntoStorageService> storageServices)
    {
        this.repository = repository;
        this.configRepository = configRepository;
        this.storageServices = storageServices.ToDictionary(service => service.Provider);
    }

    public async Task<Adjunto> Handle(CreateAdjuntoCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request.Archivo);
        ArgumentNullException.ThrowIfNull(request.Archivo.Content);
        try
        {
            var config = await configRepository.ObtenerPorId(request.Modulo);
            var storage = ResolveStorage(config.AdjuntoProvider);
            EnsureContentType(request.Archivo);
            var uploadResult = await storage.UploadAsync(request.Archivo.Content, request.Archivo.FileName, request.Archivo.ContentType, config.Container, config.MainPath, cancellationToken);
            var dto = new AdjuntoCrearDto
            {
                FileName = request.Archivo.FileName,
                ContentType = request.Archivo.ContentType,
                Size = request.Archivo.Size,
                AdjuntoProvider = config.AdjuntoProvider,
                Container = uploadResult.Container,
                FullPath = uploadResult.FullPath,
                NombreGenerado = uploadResult.NombreGenerado
            };
            return await repository.Agregar(dto);
        }
        finally
        {
            request.Archivo.Content.Dispose();
        }
    }

    private IAdjuntoStorageService ResolveStorage(AdjuntoProviderEnum provider)
    {
        if (!storageServices.TryGetValue(provider, out var storageService))
            throw new InvalidOperationException($"No se encontró un almacenamiento configurado para el proveedor {provider}.");
        return storageService;
    }

    private static void EnsureContentType(AdjuntoUploadDto archivo)
    {
        if (string.IsNullOrWhiteSpace(archivo.ContentType))
            archivo.ContentType = "application/octet-stream";
    }
}

public record UpdateAdjuntoCommand(long Id, AdjuntoConfigProviderModuloEnum Modulo, AdjuntoUploadDto Archivo) : IRequest<Adjunto>;

public class UpdateAdjuntoCommandHandler : IRequestHandler<UpdateAdjuntoCommand, Adjunto>
{
    private readonly IAdjuntoRepository repository;
    private readonly IAdjuntoConfigProviderRepository configRepository;
    private readonly Dictionary<AdjuntoProviderEnum, IAdjuntoStorageService> storageServices;

    public UpdateAdjuntoCommandHandler(
        IAdjuntoRepository repository,
        IAdjuntoConfigProviderRepository configRepository,
        IEnumerable<IAdjuntoStorageService> storageServices)
    {
        this.repository = repository;
        this.configRepository = configRepository;
        this.storageServices = storageServices.ToDictionary(service => service.Provider);
    }

    public async Task<Adjunto> Handle(UpdateAdjuntoCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request.Archivo);
        ArgumentNullException.ThrowIfNull(request.Archivo.Content);
        try
        {
            var actual = await repository.ObtenerPorId(request.Id);
            var config = await configRepository.ObtenerPorId(request.Modulo);
            var storage = ResolveStorage(config.AdjuntoProvider);
            EnsureContentType(request.Archivo);
            var uploadResult = await storage.UploadAsync(request.Archivo.Content, request.Archivo.FileName, request.Archivo.ContentType, config.Container, config.MainPath, cancellationToken);
            await ResolveStorage(actual.AdjuntoProvider).DeleteAsync(actual.Container, actual.FullPath, cancellationToken);
            var dto = new AdjuntoCrearDto
            {
                FileName = request.Archivo.FileName,
                ContentType = request.Archivo.ContentType,
                Size = request.Archivo.Size,
                AdjuntoProvider = config.AdjuntoProvider,
                Container = uploadResult.Container,
                FullPath = uploadResult.FullPath,
                NombreGenerado = uploadResult.NombreGenerado
            };
            return await repository.Modificar(request.Id, dto);
        }
        finally
        {
            request.Archivo.Content.Dispose();
        }
    }

    private IAdjuntoStorageService ResolveStorage(AdjuntoProviderEnum provider)
    {
        if (!storageServices.TryGetValue(provider, out var storageService))
            throw new InvalidOperationException($"No se encontró un almacenamiento configurado para el proveedor {provider}.");
        return storageService;
    }

    private static void EnsureContentType(AdjuntoUploadDto archivo)
    {
        if (string.IsNullOrWhiteSpace(archivo.ContentType))
            archivo.ContentType = "application/octet-stream";
    }
}

public record DeleteAdjuntoCommand(long Id) : IRequest<Unit>;

public class DeleteAdjuntoCommandHandler : IRequestHandler<DeleteAdjuntoCommand, Unit>
{
    private readonly IAdjuntoRepository repository;
    private readonly Dictionary<AdjuntoProviderEnum, IAdjuntoStorageService> storageServices;

    public DeleteAdjuntoCommandHandler(
        IAdjuntoRepository repository,
        IEnumerable<IAdjuntoStorageService> storageServices)
    {
        this.repository = repository;
        this.storageServices = storageServices.ToDictionary(service => service.Provider);
    }

    public async Task<Unit> Handle(DeleteAdjuntoCommand request, CancellationToken cancellationToken)
    {
        var actual = await repository.ObtenerPorId(request.Id);
        await repository.Eliminar(request.Id);
        await ResolveStorage(actual.AdjuntoProvider).DeleteAsync(actual.Container, actual.FullPath, cancellationToken);
        return Unit.Value;
    }

    private IAdjuntoStorageService ResolveStorage(AdjuntoProviderEnum provider)
    {
        if (!storageServices.TryGetValue(provider, out var storageService))
            throw new InvalidOperationException($"No se encontró un almacenamiento configurado para el proveedor {provider}.");
        return storageService;
    }
}
