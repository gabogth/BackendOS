using System.ComponentModel.DataAnnotations;

namespace nest.core.security.Models.General.Requests
{
    public class AdjuntoUploadRequest
    {
        [Required]
        public IFormFile Archivo { get; set; }
    }
}
