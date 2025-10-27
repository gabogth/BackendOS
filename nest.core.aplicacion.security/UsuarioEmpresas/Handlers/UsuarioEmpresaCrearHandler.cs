using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.UsuarioEmpresas.Commands;
using nest.core.dominio.Security.UsuarioEmpresa;

namespace nest.core.aplicacion.security.UsuarioEmpresas.Handlers
{
    public sealed class UsuarioEmpresaCrearHandler : IRequestHandler<UsuarioEmpresaCrearCommand, UsuarioEmpresa>
    {
        private readonly IUsuarioEmpresaRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<UsuarioEmpresaCrearHandler> logger;

        public UsuarioEmpresaCrearHandler(
            IUsuarioEmpresaRepository repository,
            IMapper mapper,
            ILogger<UsuarioEmpresaCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<UsuarioEmpresa> Handle(UsuarioEmpresaCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<UsuarioEmpresa>(request);
                return await repository.Agregar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al crear la relación usuario-empresa para el usuario {Usuario}", request.UsuarioId);
                throw;
            }
        }
    }
}
