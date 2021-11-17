using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.Models
{
    public class SolicitudComentarPost
    {
        public int IdPost { get; set; }
        public int IdUsuarioComentario { get; set; }
        public string Contenido { get; set; }
    }
}