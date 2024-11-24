using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nest.core.dominio.Aplicacion.Formulario
{
    public class FormularioCrearDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int ModuloId { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }
        public string Controlador { get; set; }
        public string Action { get; set; }
        public string Icono { get; set; }
        public string ClaimType { get; set; }
        public short Orden { get; set; }
        public bool Estado { get; set; }
    }
}
