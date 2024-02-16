using System;
using System.Collections.Generic;

namespace WebApi.models
{
    public partial class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }
    }
}
