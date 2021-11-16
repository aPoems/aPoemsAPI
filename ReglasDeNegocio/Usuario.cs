using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasDeNegocio
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Nickname { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Repositorio Repositorio { get; set; }

        public Usuario(Repositorio repositorio)
        {
            this.Repositorio = repositorio;
        }
        public Usuario(string correo, string contraseña, string nickname, DateTime fechaNacimiento, Repositorio repositorio)
        {
            this.Correo = correo;
            this.Contraseña = contraseña;
            this.Nickname = nickname;
            this.FechaNacimiento = fechaNacimiento;
            this.Repositorio = repositorio;
        }
        public bool IniciarSesion()
        {
            IdUsuario = Repositorio.IniciarSesion(Correo, Contraseña);
            return IdUsuario != 0;
        }
        public int ConsultaIDCorreo()
        {
            return Repositorio.ConsultarCorreo(Correo);
        }
        public bool RegistrarUsuario ()
        {
            if (DateTime.Today.AddTicks(-FechaNacimiento.Ticks).Year - 1 <= 18)
            {
                return false;
            }
            else
            {
                if (ConsultaIDCorreo() == 0) 
                {
                    bool registro = Repositorio.RegistrarUsuario(Correo, Contraseña, Nickname, FechaNacimiento);
                    this.IdUsuario = ConsultaIDCorreo();
                    return registro;
                }
                else
                {
                    return false;
                }
            }
        }
        public List<Post> ConsultarPostGenerales()
        {
            return Repositorio.ConsultarPostGenerales();
        }
        public bool CrearPost(string contenido)
        {
            Post post = new Post(Repositorio);
            return post.RegistrarPost(IdUsuario, contenido);
        }
        public bool CrearComentario(int idPost, string contenido)
        {
            Comentario comentario = new Comentario(Repositorio);
            return comentario.RegistarComentario(idPost, IdUsuario, contenido);
        }
    }
}
