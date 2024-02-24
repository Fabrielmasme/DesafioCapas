using WebApi.DTOs;
using WebApi.models;

namespace WebApi.Mapper
{
    public class ProductoVendidoMapper
    {
        public static ProductoVendidoDTO MappearAProductoVendidoDTO(ProductosVendido productoVendido)
        {
            ProductoVendidoDTO dto = new ProductoVendidoDTO();
            dto.Id = productoVendido.Id;
            dto.IdProducto = productoVendido.IdProducto;
            dto.Stock = productoVendido.Stock;
            dto.IdVenta = productoVendido.IdVenta;

            return dto;
        }
    }
}