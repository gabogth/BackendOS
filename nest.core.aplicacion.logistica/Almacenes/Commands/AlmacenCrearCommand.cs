using MediatR;
using nest.core.dominio.Logistica.AlmacenEN;

namespace nest.core.aplicacion.logistica.Almacenes.Commands;

public record AlmacenCrearCommand(
    int EmpresaId,
    string Nombre,
    string NombreCorto,
    int DistritoId,
    string Direccion,
    decimal Latitud,
    decimal Longitud,
    bool Activo
) : IRequest<Almacen>, IAlmacenGenericCommand;
