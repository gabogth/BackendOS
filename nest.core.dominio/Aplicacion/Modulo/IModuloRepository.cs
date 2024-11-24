using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nest.core.dominio.Aplicacion.Modulo.Repository
{
    public interface IModuloRepository
    {
        Task<Modulo> ObtenerPorId(int id);
        Task<List<Modulo>> ObtenerTodos();
        Task<List<Modulo>> ObtenerPorUnaPropiedad(Dictionary<string, object> filtros);
        Task<Modulo> Agregar(ModuloCrearDto entry);
        Task<Modulo> Modificar(int id, ModuloCrearDto entry);
        Task Eliminar(int id);
    }
}
