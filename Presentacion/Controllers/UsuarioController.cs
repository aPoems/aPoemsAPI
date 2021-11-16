using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReglasDeNegocio;
using Presentacion.Models;
using AccesoDatos;

namespace Presentacion.Controllers
{
    public class UsuarioController : ApiController
    {
        [Route("api/RegistrarUsuario")]
        [HttpPost]
        public RespuestaBool RegistrarUsuario([FromBody] SolicitudRegistroUsuario solicitud)
        {
            Repositorio repositorio = new AccesoDatosSQL();
            
            string correo = solicitud.Correo;
            string contraseña = solicitud.Contraseña;
            string nickname = solicitud.Nickname;
            DateTime fechaNacimiento = solicitud.FechaNacimiento;

            Usuario usuario = new Usuario(correo, contraseña, nickname, fechaNacimiento, repositorio);
            bool respuesta = usuario.RegistrarUsuario();

            RespuestaBool resp = new RespuestaBool();
            resp.Resultado = respuesta;

            return resp;
        }

        [Route("api/IniciarSesion")]
        [HttpPost]
        public RespuestaBool IniciarSesion([FromBody] SolicitudIniciarSesion solicitud)
        {
            Repositorio repositorio = new AccesoDatosSQL();

            Usuario usuario = new Usuario(repositorio);
            usuario.Correo = solicitud.Correo;
            usuario.Contraseña = solicitud.Contraseña;

            bool respuesta = usuario.IniciarSesion();

            RespuestaBool resp = new RespuestaBool();
            resp.Resultado = respuesta;

            return resp;
        }

        /*[Route("api/PublicarPost")]
        [HttpPost]
        public RespuestaBool IniciarSesion([FromBody] SolicitudIniciarSesion solicitud)
        {
            Repositorio repositorio = new AccesoDatosSQL();

            Usuario usuario = new Usuario(repositorio);
            usuario.Correo = solicitud.Correo;
            usuario.Contraseña = solicitud.Contraseña;

            bool respuesta = usuario.IniciarSesion();

            RespuestaBool resp = new RespuestaBool();
            resp.Resultado = respuesta;

            return resp;
        }*/
    }
}
