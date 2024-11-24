using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nest.core.dominio.Aplicacion.Formulario
{
    public interface IFormularioRepository
    {
        Task<Formulario> ObtenerPorId(int id);
        Task<List<Formulario>> ObtenerPorModuloId(int moduloId);
        Task<List<Formulario>> ObtenerTodos();
        Task<List<Formulario>> ObtenerPorUnaPropiedad(Dictionary<string, object> filtros);
        Task<List<Formulario>> ObtenerPorRolId(string roleId);
        Task<Formulario> Agregar(FormularioCrearDto entry);
        Task<Formulario> Modificar(int id, FormularioCrearDto entry);
        Task Eliminar(int id);
    }
}
