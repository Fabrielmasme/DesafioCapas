using WebApi.database;
using WebApi.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CoderHouse.Service
{
    internal class ProductoVendidoService
    {
        internal static List<ProductosVendido> ListaProductosVendidos()
        {
            using (coderhouse context = new coderhouse())
            {
                List<ProductosVendido> productosVendidos = context.ProductosVendidos.ToList();

                return productosVendidos;
            }
        }

        internal static ProductosVendido ObtenerProductoVendidoPorId(int id)
        {
            using (coderhouse context = new coderhouse())
            {

                ProductosVendido? productoVendido = context.ProductosVendidos.Where(p => p.Id == id).FirstOrDefault();
                return productoVendido;
            }
        }

        internal static bool AgregarProductoVendido(ProductosVendido productoVendidos)
        {
            using (coderhouse context = new coderhouse())
            {
                context.ProductosVendidos.Add(productoVendidos);

                context.SaveChanges();

                return true;
            }
        }

        internal static bool ActualizarProductoVendidoPorId(ProductosVendido productoVendidos, int id)
        {
            using (coderhouse context = new coderhouse())
            {
                ProductosVendido? productoVendido = context.ProductosVendidos.Where(p => p.Id == id).FirstOrDefault();

                productoVendido.IdProducto =productoVendido.IdProducto;
                productoVendido.IdVenta = productoVendido.IdVenta;
                productoVendido.Stock = productoVendido.Stock;

                context.ProductosVendidos.Update(productoVendido);

                context.SaveChanges();
                return true;
            }
        }

        internal static void EliminarProductoVendido(int id)
        {
            using (var context = new coderhouse())
            {

                var productoVendido = context.ProductosVendidos.Find(id);

                if (productoVendido == null)
                {
                    return;
                }

                context.ProductosVendidos.Remove(productoVendido);

                context.SaveChanges();
            }
        }

    }
}