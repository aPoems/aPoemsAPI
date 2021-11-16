using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasDeNegocio
{
    public class Post
    {
        public int Idpost { get; set; }
        public int IdUsuarioPost { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string Contenido { get; set; }
        public int CantidadComentarios { get; set; }
        public int CantidadLikes { get; set; }
        public List<Comentario> Comentarios { get; set; }
        public string Nickname { get; set; }
        Repositorio Repositorio { get; set; }
        
        public Post() { }
        public Post(Repositorio repositorio)
        {
            Repositorio = repositorio;
        }
        public bool RegistrarPost(int idUsuarioPost, string contenido)
        {
            IdUsuarioPost = idUsuarioPost;            
            FechaPublicacion = DateTime.Now;
            Contenido = contenido;
            CantidadComentarios = 0;
            CantidadLikes = 0;
            this.Idpost = Repositorio.RegistrarPost(IdUsuarioPost, FechaPublicacion, Contenido);
            return Idpost != 0;
        }
        public void AumentarLikes()
        {
            Repositorio.AumentarLikes(Idpost);
        }
        public List<Comentario> ConsultarComentarios()
        {
            Comentarios = Repositorio.ConsultarComentarios(Idpost);
            return Comentarios;
        }
    }
}
