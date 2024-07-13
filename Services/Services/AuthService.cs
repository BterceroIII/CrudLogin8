using Data;
using Models.Login;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models.ViewModels;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _appDbContext;

        public AuthService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Models.Login.Usuario> AuthenticateUser(string correo, string clave)
        {
            return await _appDbContext.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == correo && u.Clave == clave);
        }

        public async Task RegisterUser(UsuarioVM modelo)
        {
            if (modelo.Clave != modelo.ConfirClave)
            {
                throw new ArgumentException("Las contraseñas no coinciden");
            }

            Usuario usuario = new Usuario
            {
               Nombre = modelo.Nombre,
               Apellido = modelo.Apellido,
               Correo = modelo.Correo,
               Clave = modelo.Clave
            };

            await _appDbContext.Usuarios.AddAsync(usuario);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
