using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.UsuarioEmpresas.Commands;
using nest.core.dominio.Security.UsuarioEmpresa;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.aplicacion.security.UsuarioEmpresas.Handlers
{
    public sealed class UsuarioEmpresaModificarHandler : IRequestHandler<UsuarioEmpresaModificarCommand, UsuarioEmpresa>
    {
        private readonly IUsuarioEmpresaRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<UsuarioEmpresaModificarHandler> logger;

        public UsuarioEmpresaModificarHandler(
            IUsuarioEmpresaRepository repository,
            IMapper mapper,
            ILogger<UsuarioEmpresaModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<UsuarioEmpresa> Handle(UsuarioEmpresaModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existing = await repository.ObtenerPorId(request.Id)
                    ?? throw new RegistroNoEncontradoException<UsuarioEmpresa>(request.Id);

                var entity = mapper.Map(request, existing);
                return await repository.Modificar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al modificar la relación usuario-empresa {Id}", request.Id);
                throw;
            }
        }
    }
}
