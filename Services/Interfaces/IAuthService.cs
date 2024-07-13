using Models.Login;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAuthService
    {
        Task<Usuario> AuthenticateUser(string correo, string clave);
        Task RegisterUser(UsuarioVM  modelo);
    }
}
