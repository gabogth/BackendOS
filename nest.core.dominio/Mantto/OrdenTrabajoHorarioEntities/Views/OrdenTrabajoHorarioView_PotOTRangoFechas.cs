using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities.Views
{
    public class OrdenTrabajoHorarioView_PorOTRangoFechas
    {
        public long Id { get; set; }
        public long OrdenTrabajoCabeceraId { get; set; }
        public int PersonalId { get; set; }
        public DateOnly Fecha { get; set; }
        public int HorarioCabeceraId { get; set; }
        public string NombreOt { get; set; }

    }
}
