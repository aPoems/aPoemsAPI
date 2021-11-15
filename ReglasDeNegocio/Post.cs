using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasDeNegocio
{
    public class Post
    {
        int Idpost { get; set; }
        int IdUsuarioPost { get; set; }
        DateTime FechaPublicacion { get; set; }
        string Contenido { get; set; }
        int CantidadComentarios { get; set; }
        int CantidadLikes { get; set; }

    }
}
