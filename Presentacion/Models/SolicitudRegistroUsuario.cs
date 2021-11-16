using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.Models
{
    public class SolicitudRegistroUsuario
    {
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Nickname { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}