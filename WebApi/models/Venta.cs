using System;
using System.Collections.Generic;

namespace WebApi.models
{
    public class Venta
    {
        public int? Id { get; set; }
        public string? Comentarios { get; set; }
        public int? IdUsuario { get; set; }
    }
}
