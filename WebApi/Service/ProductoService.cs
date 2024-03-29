﻿using WebApi.database;
using WebApi.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DTOs;
using WebApi.Mapper;


namespace Proyecto_CoderHouse.Service
{
    public class ProductoService
    {
        internal static List<Producto> ListaProductos()
        {
            using (coderhouse context = new coderhouse())
            {
                List<Producto> productos = context.Productos.ToList();

                return productos;
            }
        }

        internal static Producto ObtenerProductoPorId(int id)
        {
            using (coderhouse context = new coderhouse())
            {

                Producto? productoEncontrado = context.Productos.Where(p => p.Id == id).FirstOrDefault();
                return productoEncontrado;
            }
        }


        internal bool AgregarProducto(ProductoDTO dto)
        {
            using (coderhouse context = new coderhouse())
            {
                Producto p = ProductoMapper.MappearAProducto(dto);

                context.Productos.Add(p);
                context.SaveChanges();

                return true;
            }    
        }

        internal static bool ActualizarProductoPorId(Producto producto, int id)
        {
            using (coderhouse context = new coderhouse())
            {
                Producto? productoBuscado = context.Productos.Where(p => p.Id == id).FirstOrDefault();
                productoBuscado.Descripcion = producto.Descripcion;
                productoBuscado.Costo = producto.Costo;
                productoBuscado.PrecioVenta = producto.PrecioVenta;
                productoBuscado.Stock = producto.Stock;
                productoBuscado.IdUsuario = producto.IdUsuario;

                context.Productos.Update(productoBuscado);

                context.SaveChanges();
                return true;
            }
        }

        internal static void EliminarProducto(int idProducto)
        {
            using (var context = new coderhouse())
            {
                var producto = context.Productos.Find(idProducto);

                // Eliminar las ventas relacionadas
                foreach (var venta in context.Ventas)
                {
                    context.Ventas.Remove(venta);
                }

                // Eliminar el producto
                context.Productos.Remove(producto);

                context.SaveChanges();
            }
        }

        public bool BorrarProductoPorId(int id)
        {
            using (coderhouse context = new coderhouse())
            {
                Producto? producto = context.Productos.Where(p=> p.Id == id).FirstOrDefault();
                if (producto != null)
                {
                    context.Remove(producto);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool ActualizarProductoPorId(int id, ProductoDTO productoDTO)
        {
            using (coderhouse context = new coderhouse())
            {
                Producto? producto = context.Productos.Where(p => p.Id == id).FirstOrDefault();
                if (producto != null)
                {
                    producto.PrecioVenta=productoDTO.PrecioVenta;
                    producto.Stock = productoDTO.Stock;
                    producto.Costo = productoDTO.Costo;
                    producto.Descripcion= productoDTO.Descripcion;
                    producto.IdUsuario= productoDTO.IdUsuario;

                    context.Productos.Update(producto);
                    context.SaveChanges();

                    return true;
                }
                return false;
            }
        }
    }
}