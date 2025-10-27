using MediatR;
using System;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;

namespace nest.core.aplicacion.mantto.OrdenServicioCabeceras.Commands
{
    public sealed record OrdenServicioCabeceraCrearCommand(
        int EmpresaId,
        short OrdenServicioTipoId,
        string CodigoOrdenInterna,
        string CodigoReferencial,
        string Descripcion,
        bool Activo,
        DateTime FechaInicial,
        DateTime FechaFinal,
        DateTime FechaEntrega
    ) : IRequest<OrdenServicioCabecera>, IOrdenServicioCabeceraGenericCommand;
}
