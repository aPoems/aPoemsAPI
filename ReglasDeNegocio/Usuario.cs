using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasDeNegocio
{
    public class Usuario
    {
        int IdUsuario { get; set; }
        string Correo { get; set; }
        string Contraseña { get; set; }
        string Nickname { get; set; }
        DateTime FechaNacimiento { get; set; }
        Repositorio Repositorio { get; set; }


        public bool IniciarSesion(string Correo, string Contrasena)
        {
            
            return Repositorio.IniciarSesion(Correo, Contrasena);

        }
        public bool ConsultaCorreo(string Correo)
        {
            return Repositorio.ConsultarCorreo(Correo);
        }
        public bool RegistrarUsuario (string Correo, string Contrasena, string NickName, DateTime FechaNacimiento)
        {
            if (DateTime.Today.AddTicks(-FechaNacimiento.Ticks).Year - 1 <= 18)
            {
                return false;
            }

            else
            {
                if (ConsultaCorreo(Correo) == false) 
                { 
                    return Repositorio.RegistrarUsuario(Correo, Contrasena, NickName, FechaNacimiento);
                }
                else
                {
                    return false;
                }
            }

        }
       
    }
}
