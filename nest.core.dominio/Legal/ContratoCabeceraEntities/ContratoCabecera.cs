using nest.core.dominio.Corporativo;
using nest.core.dominio.Legal.ContratoTipoEntities;
using nest.core.dominio.RRHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nest.core.dominio.Legal.ContratoCabeceraEntities
{
    public class ContratoCabecera
    {
        public int Id { get; set; }
        public byte ContratoTipoId { get; set; }
        public int Numero { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public bool Estado { get; set; }
        public string Observacion { get; set; }
        public string Resumen { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public ContratoTipo ContratoTipo { get; set; }
    }
}
