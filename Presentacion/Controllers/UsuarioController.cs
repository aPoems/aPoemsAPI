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
            int idUsuaio = usuario.IdUsuario;

            RespuestaBool resp = new RespuestaBool();
            resp.Resultado = respuesta;
            resp.IdUsuarioInicioSesion = idUsuaio;

            return resp;
        }        

        [Route("api/VerPost")]
        [HttpPost]
        public RespuestaVerPost VerPost([FromBody] SolicitudVerPost solicitud)
        {
            Repositorio repositorio = new AccesoDatosSQL();

            Usuario usuario = new Usuario(repositorio);

            List<Post> respuesta = usuario.ConsultarPostGenerales();

            RespuestaVerPost resp = new RespuestaVerPost();
            resp.Resultado = respuesta;

            return resp;
        }

        [Route("api/PublicarPost")]
        [HttpPost]
        public RespuestaBool PublicarPost([FromBody] SolicitudPublicarPost solicitud)
        {
            Repositorio repositorio = new AccesoDatosSQL();

            Usuario usuario = new Usuario(repositorio);
            usuario.IdUsuario = solicitud.IdUsuario;

            bool respuesta = usuario.CrearPost(solicitud.Contenido);

            RespuestaBool resp = new RespuestaBool();
            resp.Resultado = respuesta;

            return resp;
        }

        [Route("api/LikePost")]
        [HttpPost]
        public RespuestaLikePost LikePost([FromBody] SolicitudLikePost solicitud)
        {
            Repositorio repositorio = new AccesoDatosSQL();

            Post post = new Post(repositorio);
            post.Idpost = solicitud.IdPost;

            post.AumentarLikes();

            RespuestaLikePost resp = new RespuestaLikePost();
            resp.Respuesta = "Hecho";

            return resp;
        }

        [Route("api/ComentarPost")]
        [HttpPost]
        public RespuestaBool ComentarPost([FromBody] SolicitudComentarPost solicitud)
        {
            Repositorio repositorio = new AccesoDatosSQL();

            Usuario usuario = new Usuario(repositorio);
            usuario.IdUsuario = solicitud.IdUsuarioComentario;

            bool respuesta = usuario.CrearComentario(solicitud.IdPost, solicitud.Contenido);

            RespuestaBool resp = new RespuestaBool();
            resp.Resultado = respuesta;

            return resp;
        }

        [Route("api/VerComentarios")]
        [HttpPost]
        public RespuestaVerComentarios VerComentarios([FromBody] SolicitudVerComentarios solicitud)
        {
            Repositorio repositorio = new AccesoDatosSQL();

            Post post = new Post(repositorio);
            post.Idpost = solicitud.IdPost;

            List<Comentario> respuesta = post.ConsultarComentarios();

            RespuestaVerComentarios resp = new RespuestaVerComentarios();
            resp.Resultado = respuesta;

            return resp;
        }
    }
}
