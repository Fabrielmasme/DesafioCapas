using Microsoft.AspNetCore.Mvc;
using WebApi.database;
using WebApi.DTOs;
using WebApi.Mapper; // Se agrega la referencia a Mapper
using WebApi.models;
using Proyecto_CoderHouse.Service;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoVendidoController : Controller
    {
        private readonly ProductoVendidoService _productoVendidoService;

        public ProductoVendidoController(ProductoVendidoService productoVendidoService)
        {
            this._productoVendidoService = productoVendidoService;
        }

        [HttpGet("{idUsuario}")]
        public ActionResult<List<ProductoVendidoDTO>> ObtenerProductosVendidosPorUsuario(int idUsuario)
        {
            var productosVendidos = _productoVendidoService.ObtenerProductosVendidosPorUsuario(idUsuario);

            if (productosVendidos == null)
            {
                return NotFound();
            }

            var productosVendidosDTO = new List<ProductoVendidoDTO>();

            foreach (var productoVendido in productosVendidos)
            {
                productosVendidosDTO.Add(ProductoVendidoMapper.MappearAProductoVendidoDTO(productoVendido)); // Se utiliza el método MappearAProductoVendidoDTO
            }

            return Ok(productosVendidosDTO);
        }

    }
}
