using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasDeNegocio
{
    public interface Repositorio
    {
        bool IniciarSesion(string Correo, string Contrasena);
        bool RegistrarUsuario(string Correo, string Contrasena, string NickName, DateTime FechaNacimiento);
        bool ConsultarCorreo(string Correo);
    }
}
