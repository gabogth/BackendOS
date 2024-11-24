using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nest.core.infrastructura.utils.Excepciones
{
    public class LoginFailedUserNameException : Exception
    {
        public LoginFailedUserNameException(): base("Usuario incorrecto.")
        {
            
        }
    }
    public class LoginFailedPasswordException : Exception
    {
        public LoginFailedPasswordException() : base("Contraseña incorrecta.")
        {

        }
    }
}
