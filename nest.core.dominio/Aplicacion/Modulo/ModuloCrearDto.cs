using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nest.core.dominio.Aplicacion.Modulo
{
    public class ModuloCrearDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }
        public string RutaImagen { get; set; }
        public bool Estado { get; set; }
    }
}
