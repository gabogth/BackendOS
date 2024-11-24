using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nest.core.dominio.Security.Auth
{
    public static class FormPoliciesEnum
    {
        public const string Seguridad_Index = "aplicacion-home";
        public const string Seguridad_Formulario = "aplicacion-formulario";
        public const string Seguridad_Rol = "seguridad-rol";
        public const string Seguridad_RolUsuario = "seguridad-rol-usuario";
        public const string Seguridad_RolFormulario = "seguridad-rol-formulario";
        public const string Seguridad_Usuario = "seguridad-usuario";

        public static readonly Dictionary<string, string> Policies = new Dictionary<string, string>
        {
            { nameof(Seguridad_Index), Seguridad_Index },
            { nameof(Seguridad_Formulario), Seguridad_Formulario },
            { nameof(Seguridad_Rol), Seguridad_Rol },
            { nameof(Seguridad_RolUsuario), Seguridad_RolUsuario },
            { nameof(Seguridad_RolFormulario), Seguridad_RolFormulario },
            { nameof(Seguridad_Usuario), Seguridad_Usuario }
        };
    }
}
