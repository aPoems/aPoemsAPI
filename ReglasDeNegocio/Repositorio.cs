using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasDeNegocio
{
    public interface Repositorio
    {
        int IniciarSesion(string Correo, string Contrasena);
        bool RegistrarUsuario(string Correo, string Contrasena, string NickName, DateTime FechaNacimiento);
        int ConsultarCorreo(string Correo);
        int RegistrarPost(int idUsuarioPost, DateTime fechaPublicacion, string contenido);
        void AumentarLikes(int idPost);
        List<Comentario> ConsultarComentarios(int idPost);
        List<Post> ConsultarPostGenerales();
        int RegistrarComentario(int idPost, int idUsuarioComentario, DateTime fechaPublicacion, string Contenido);
    }
}
