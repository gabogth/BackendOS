using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Finanzas.EntidadFinancieraEntities;

namespace nest.core.aplicacion.finanzas.EntidadFinanciera.Commands
{
    public sealed record EntidadFinancieraCrearCommand(
        int EmpresaId,
        string Nombre,
        string NombreCorto,
        bool Activo,
        bool EsEfectivo
    ) : IRequest<EntidadFinanciera>, IEntidadFinancieraGenericCommand;
}
