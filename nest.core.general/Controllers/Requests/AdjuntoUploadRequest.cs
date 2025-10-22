using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using nest.core.dominio.General.AdjuntoProviderEntities;

namespace nest.core.general.Controllers.Requests
{
    public class AdjuntoUploadRequest
    {
        /// <summary>
        /// Módulo asociado al adjunto.
        /// </summary>
        [Required]
        public AdjuntoConfigProviderModuloEnum Modulo { get; set; }

        /// <summary>
        /// Archivo que se desea almacenar.
        /// </summary>
        [Required]
        public IFormFile Archivo { get; set; }
    }
}
