using System;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenServicioCabeceras.Commands
{
    public interface IOrdenServicioCabeceraGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        short OrdenServicioTipoId { get; }
        string CodigoOrdenInterna { get; }
        string CodigoReferencial { get; }
        string Descripcion { get; }
        bool Activo { get; }
        DateTime FechaInicial { get; }
        DateTime FechaFinal { get; }
        DateTime FechaEntrega { get; }
    }
}
