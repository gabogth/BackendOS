using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Features.AdjuntoConfigProviders.Commands;
using nest.core.aplicacion.general.Features.AdjuntoConfigProviders.Queries;
using nest.core.dominio;
using nest.core.dominio.General.AdjuntoProviderEntities;

namespace nest.core.general.Controllers
{
    /// <summary>
    /// Gestiona la configuración de proveedores de adjuntos.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AdjuntoConfigProviderController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<AdjuntoConfigProviderController> logger;

        public AdjuntoConfigProviderController(IMediator mediator, ILogger<AdjuntoConfigProviderController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        /// <summary>
        /// Obtiene todas las configuraciones registradas.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<AdjuntoConfigProvider>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<AdjuntoConfigProvider>>> ObtenerTodos()
        {
            try
            {
                var data = await mediator.Send(new GetAdjuntoConfigProvidersQuery());
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Obtiene una configuración por su identificador.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AdjuntoConfigProvider), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<AdjuntoConfigProvider>> ObtenerPorId(AdjuntoConfigProviderModuloEnum id)
        {
            try
            {
                var data = await mediator.Send(new GetAdjuntoConfigProviderByIdQuery(id));
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Obtiene las configuraciones activas.
        /// </summary>
        [HttpGet("activos")]
        [ProducesResponseType(typeof(List<AdjuntoConfigProvider>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<List<AdjuntoConfigProvider>>> ObtenerActivos()
        {
            try
            {
                var data = await mediator.Send(new GetAdjuntoConfigProvidersActivosQuery());
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Registra una nueva configuración.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(AdjuntoConfigProvider), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<AdjuntoConfigProvider>> Agregar([FromBody] CreateAdjuntoConfigProviderCommand command)
        {
            try
            {
                var data = await mediator.Send(command);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Actualiza una configuración existente.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AdjuntoConfigProvider), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<AdjuntoConfigProvider>> Modificar(AdjuntoConfigProviderModuloEnum id, [FromBody] UpdateAdjuntoConfigProviderCommand command)
        {
            try
            {
                var data = await mediator.Send(command with { Id = id });
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Elimina una configuración.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult> Eliminar(AdjuntoConfigProviderModuloEnum id)
        {
            try
            {
                await mediator.Send(new DeleteAdjuntoConfigProviderCommand(id));
                return Ok(true);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
