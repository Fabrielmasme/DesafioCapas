using System;
using System.Collections.Generic;

namespace WebApi.models
{
    public partial class ProductosVendido
    {
        public int Id { get; set; }
        public int? IdProducto { get; set; }
        public int? Stock { get; set; }
        public int? IdVenta { get; set; }

        public virtual Producto Producto { get; set; }
    }
}