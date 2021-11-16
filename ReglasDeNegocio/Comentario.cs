using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasDeNegocio
{
    public class Comentario
    {
        public int IdComentario { get; set; }
        public int IdPost { get; set; }
        public int IdUsuarioComentario { get; set; }
        public DateTime Publicacion { get; set; }
        public string Contenido { get; set; }
        public string Nickname { get; set; }
        Repositorio Repositorio { get; set; }

        public Comentario(){    }
        public Comentario(Repositorio repositorio)
        {
            this.Repositorio = repositorio;
        }
        public bool RegistarComentario(int idPost, int idUsuarioComentario, string contenido)
        {
            IdPost = idPost;
            IdUsuarioComentario = idUsuarioComentario;
            Publicacion = DateTime.Now;
            Contenido = contenido;
            IdComentario = Repositorio.RegistrarComentario(IdPost, IdUsuarioComentario, Publicacion, Contenido);
            return IdComentario != 0;
        }
    }
}
