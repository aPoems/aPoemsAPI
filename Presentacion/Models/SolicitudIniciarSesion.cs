﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.Models
{
    public class SolicitudIniciarSesion
    {
        public string Correo { get; set; }
        public string Contraseña { get; set; }
    }
}