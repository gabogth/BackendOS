using nest.core.dominio.General.AdjuntoEntities;
using nest.core.dominio.General.AdjuntoProviderEntities;

namespace nest.core.aplicacion.general.AdjuntoServices
{
    public class AdjuntoService
    {
        private readonly IAdjuntoRepository repository;
        private readonly IAdjuntoConfigProviderRepository configRepository;
        private readonly Dictionary<AdjuntoProviderEnum, IAdjuntoStorageService> storageServices;

        public AdjuntoService(IAdjuntoRepository repository,
                              IAdjuntoConfigProviderRepository configRepository,
                              IEnumerable<IAdjuntoStorageService> storageServices)
        {
            this.repository = repository;
            this.configRepository = configRepository;
            this.storageServices = storageServices.ToDictionary(service => service.Provider);
        }

        public Task<Adjunto> ObtenerPorId(long id) => repository.ObtenerPorId(id);
        public Task<List<Adjunto>> ObtenerTodos() => repository.ObtenerTodos();

        public async Task<Adjunto> Agregar(AdjuntoConfigProviderModuloEnum modulo, AdjuntoUploadDto archivo, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(archivo);
            ArgumentNullException.ThrowIfNull(archivo.Content);
            try
            {
                var config = await configRepository.ObtenerPorId(modulo);
                Console.WriteLine($"Configuración obtenida: {config.Nombre}, Proveedor: {config.AdjuntoProvider}, Contenedor: {config.Container}, Ruta Principal: {config.MainPath}");
                var storage = ResolveStorage(config.AdjuntoProvider);
                Console.WriteLine($"Servicio de almacenamiento resuelto para el proveedor: {config.AdjuntoProvider}");
                EnsureContentType(archivo);
                var uploadResult = await storage.UploadAsync(archivo.Content, archivo.FileName, archivo.ContentType, config.Container, config.MainPath, cancellationToken);
                Console.WriteLine($"Archivo subido: Contenedor: {uploadResult.Container}, Ruta Completa: {uploadResult.FullPath}, Nombre Generado: {uploadResult.NombreGenerado}");
                var dto = new AdjuntoCrearDto
                {
                    FileName = archivo.FileName,
                    ContentType = archivo.ContentType,
                    Size = archivo.Size,
                    AdjuntoProvider = config.AdjuntoProvider,
                    Container = uploadResult.Container,
                    FullPath = uploadResult.FullPath,
                    NombreGenerado = uploadResult.NombreGenerado
                };
                Console.WriteLine($"Registrando con esta Informacion: {dto.ToString()}");
                return await repository.Agregar(dto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error durante la carga del archivo: {ex.Message}");
                throw;
            }
            finally
            {
                archivo.Content.Dispose();
            }
        }

        public async Task<Adjunto> Modificar(long id, AdjuntoConfigProviderModuloEnum modulo, AdjuntoUploadDto archivo, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(archivo);
            ArgumentNullException.ThrowIfNull(archivo.Content);
            try
            {
                var actual = await repository.ObtenerPorId(id);
                var config = await configRepository.ObtenerPorId(modulo);
                var storage = ResolveStorage(config.AdjuntoProvider);
                EnsureContentType(archivo);
                var uploadResult = await storage.UploadAsync(archivo.Content, archivo.FileName, archivo.ContentType, config.Container, config.MainPath, cancellationToken);
                await ResolveStorage(actual.AdjuntoProvider).DeleteAsync(actual.Container, actual.FullPath, cancellationToken);
                var dto = new AdjuntoCrearDto
                {
                    FileName = archivo.FileName,
                    ContentType = archivo.ContentType,
                    Size = archivo.Size,
                    AdjuntoProvider = config.AdjuntoProvider,
                    Container = uploadResult.Container,
                    FullPath = uploadResult.FullPath,
                    NombreGenerado = uploadResult.NombreGenerado
                };
                return await repository.Modificar(id, dto);
            }
            finally
            {
                archivo.Content.Dispose();
            }
        }

        public async Task Eliminar(long id, CancellationToken cancellationToken = default)
        {
            var actual = await repository.ObtenerPorId(id);
            await repository.Eliminar(id);
            var storage = ResolveStorage(actual.AdjuntoProvider);
            await storage.DeleteAsync(actual.Container, actual.FullPath, cancellationToken);
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
}
