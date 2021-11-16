using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReglasDeNegocio;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace AccesoDatos
{
    public class AccesoDatosSQL : Repositorio
    {
        SqlConnection ObjCn;
        public AccesoDatosSQL()
        {
            ObjCn = new SqlConnection(ConfigurationManager.AppSettings["CADENA_CONEXION"]);
        }        
        public void AumentarLikes(int idPost)
        {
            SqlCommand ObjCmd = new SqlCommand("uspAumentarLikes", ObjCn);
            ObjCmd.CommandType = CommandType.StoredProcedure;
            ObjCmd.Parameters.AddWithValue("@IdPost", idPost);
            ObjCn.Open();
            ObjCmd.ExecuteNonQuery();
            ObjCn.Close();
        }

        public List<Comentario> ConsultarComentarios(int idPost)
        {
            SqlCommand ObjCmd = new SqlCommand("uspConsultarComentarios", ObjCn);
            ObjCmd.CommandType = CommandType.StoredProcedure;
            ObjCmd.Parameters.AddWithValue("@IdPost", idPost);
            ObjCn.Open();
            SqlDataReader Dr = ObjCmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(Dr);

            List<Comentario> comentarios = new List<Comentario>();

            foreach (DataRow row in dt.Rows)
            {
                Comentario comentario = new Comentario();
                comentario.IdPost = Convert.ToInt32(row[0].ToString());
                comentario.IdUsuarioComentario = Convert.ToInt32(row[1].ToString());
                comentario.Publicacion= Convert.ToDateTime(row[2].ToString());
                comentario.Contenido = row[3].ToString();
                comentario.Nickname = row[4].ToString();

                comentarios.Add(comentario);
            }

            ObjCn.Close();
            return comentarios;
        }

        public int ConsultarCorreo(string Correo)
        {
            SqlCommand ObjCmd = new SqlCommand("uspConsultarCredencialesRegistro", ObjCn);
            ObjCmd.CommandType = CommandType.StoredProcedure;
            ObjCmd.Parameters.AddWithValue("@Correo", Correo);
            ObjCn.Open();
            SqlDataReader Dr = ObjCmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(Dr);
            ObjCn.Close();

            if (dt.Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(dt.Rows[0][0].ToString());
            }            
        }

        public List<Post> ConsultarPostGenerales()
        {
            SqlCommand ObjCmd = new SqlCommand("uspConsultarPostGenerales", ObjCn);
            ObjCmd.CommandType = CommandType.StoredProcedure;
            ObjCn.Open();
            SqlDataReader Dr = ObjCmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(Dr);

            List<Post> posts = new List<Post>();

            foreach (DataRow row in dt.Rows)
            {
                Post post = new Post();
                post.Idpost = Convert.ToInt32(row[0].ToString());
                post.IdUsuarioPost = Convert.ToInt32(row[1].ToString());
                post.FechaPublicacion = Convert.ToDateTime(row[2].ToString());
                post.Contenido = row[3].ToString();
                post.CantidadLikes = Convert.ToInt32(row[4].ToString());
                post.CantidadComentarios = Convert.ToInt32(row[5].ToString());
                post.Nickname = row[6].ToString();

                posts.Add(post);
            }

            ObjCn.Close();
            return posts;
        }

        public int IniciarSesion(string Correo, string Contrasena)
        {
            SqlCommand ObjCmd = new SqlCommand("uspConsultarCredencialesInicioSesion", ObjCn);
            ObjCmd.CommandType = CommandType.StoredProcedure;
            ObjCmd.Parameters.AddWithValue("@Correo", Correo);
            ObjCmd.Parameters.AddWithValue("@Contraseña", Contrasena);
            ObjCn.Open();
            SqlDataReader Dr = ObjCmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(Dr);
            ObjCn.Close();

            if (dt.Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(dt.Rows[0][0].ToString());
            }
        }

        public int RegistrarComentario(int idPost, int idUsuarioComentario, DateTime fechaPublicacion, string Contenido)
        {
            SqlCommand ObjCmd = new SqlCommand("uspRegistrarComentario", ObjCn);
            ObjCmd.CommandType = CommandType.StoredProcedure;
            ObjCmd.Parameters.AddWithValue("@IdPost", idPost);
            ObjCmd.Parameters.AddWithValue("@IdUsuarioComentario", idUsuarioComentario);
            ObjCmd.Parameters.AddWithValue("@FechaPublicacion", fechaPublicacion);
            ObjCmd.Parameters.AddWithValue("@Contenido", Contenido);
            ObjCn.Open();
            SqlDataReader Dr = ObjCmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(Dr);
            ObjCn.Close();

            if (dt.Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(dt.Rows[0][0].ToString());
            }
        }

        public int RegistrarPost(int idUsuarioPost, DateTime fechaPublicacion, string contenido)
        {
            SqlCommand ObjCmd = new SqlCommand("uspRegistrarPost", ObjCn);
            ObjCmd.CommandType = CommandType.StoredProcedure;
            ObjCmd.Parameters.AddWithValue("@IdUsuarioPost", idUsuarioPost);
            ObjCmd.Parameters.AddWithValue("@FechaPublicacion", fechaPublicacion);
            ObjCmd.Parameters.AddWithValue("@Contenido", contenido);
            ObjCn.Open();
            SqlDataReader Dr = ObjCmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(Dr);
            ObjCn.Close();

            if (dt.Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(dt.Rows[0][0].ToString());
            }
        }

        public bool RegistrarUsuario(string Correo, string Contrasena, string NickName, DateTime FechaNacimiento)
        {
            SqlCommand ObjCmd = new SqlCommand("uspRegistrarUsuario", ObjCn);
            ObjCmd.CommandType = CommandType.StoredProcedure;
            ObjCmd.Parameters.AddWithValue("@Correo", Correo);
            ObjCmd.Parameters.AddWithValue("@Contraseña", Contrasena);
            ObjCmd.Parameters.AddWithValue("@NickName", NickName);
            ObjCmd.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
            ObjCn.Open();
            ObjCmd.ExecuteNonQuery();
            ObjCn.Close();
            return true;
        }
    }
}
