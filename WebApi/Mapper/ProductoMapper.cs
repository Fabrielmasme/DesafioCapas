using WebApi.DTOs;
using WebApi.models;

namespace WebApi.Mapper
{
    public static class ProductoMapper
    {
        public static Producto MappearAProducto (ProductoDTO dto)
        {
            Producto producto = new Producto ();
            producto.Id = dto.Id;
            producto.PrecioVenta = dto.PrecioVenta;
            producto.Stock = dto.Stock;
            producto.Costo = dto.Costo;
            producto.IdUsuario = dto.IdUsuario;

            return producto;
        }

        public static ProductoDTO MappearADTO (ProductoDTO producto)
        {
            ProductoDTO dto = new ProductoDTO ();

            dto.Descripcion = dto.Descripcion;
            dto.Id = dto.Id;
            dto.PrecioVenta= dto.PrecioVenta;
            dto.Stock = dto.Stock;
            dto.Costo = dto.Costo;
            dto.IdUsuario= dto.IdUsuario;

            return dto;
        }
    }
}