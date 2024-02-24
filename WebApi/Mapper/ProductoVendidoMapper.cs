using WebApi.DTOs;
using WebApi.models;

namespace WebApi.Mapper
{
    public static class ProductoVendidoMapper
    {
        public static ProductosVendido MappearAProductoVendido(ProductoVendidoDTO dto)
        {
            ProductosVendido productoVendido = new ProductosVendido();
            productoVendido.IdProducto = dto.IdProducto;
            productoVendido.Stock = dto.Stock;
            productoVendido.IdVenta = dto.IdVenta;

            return productoVendido;
        }

        public static ProductoVendidoDTO MappearAProductoVendidoDTO(ProductoVendidoDTO productoVendido)
        {
            ProductoVendidoDTO dto = new ProductoVendidoDTO();
            dto.IdProducto = dto.IdProducto;
            dto.Stock = dto.Stock;
            dto.IdVenta = dto.IdVenta;

            return dto;
        }
    }
}
