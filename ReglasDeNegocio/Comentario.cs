using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasDeNegocio
{
    public class Comentario
    {
        int IdComentario { get; set; }
        int IdPost { get; set; }
        int IdUsuarioComentario { get; set; }
        DateTime Publicacion { get; set; }
        string Contenido { get; set; }

    }
}
