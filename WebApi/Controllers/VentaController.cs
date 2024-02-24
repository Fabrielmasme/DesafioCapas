using Microsoft.AspNetCore.Mvc;
using WebApi.database;
using WebApi.DTOs;
using WebApi.models;
using Proyecto_CoderHouse.Service;
using WebApi.Mapper;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : Controller
    {
        private readonly VentaService _ventaService;

        public VentaController(VentaService ventaService)
        {
            this._ventaService = ventaService;
        }

        [HttpGet]
        public List<Venta> ObtenerTodasLasVentas()
        {
            VentaService ventaService = new VentaService();
            return ventaService.ListaVenta();
        }


        [HttpGet("{id}")]
        public ActionResult<Venta> ObtenerVentaPorId(int id)
        {
            var venta = VentaService.ObtenerVentaPorId(id);
            if (venta == null)
            {
                return NotFound();
            }
            return Ok(venta);
        }

        [HttpPost]
        public IActionResult AgregarVenta(VentasDTO ventaDTO)
        {
            var venta = VentaMapper.MappearAVentas(ventaDTO);
            VentaService.AgregarVenta(venta);
            return CreatedAtAction(nameof(ObtenerVentaPorId), new { id = venta.Id }, venta);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarVenta(int id, VentasDTO ventaDTO)
        {
            if (id != ventaDTO.Id)
            {
                return BadRequest();
            }

            var venta = VentaMapper.MappearAVentas(ventaDTO);
            VentaService.ActualizarVentaPorId(venta, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarVenta(int id)
        {
            VentaService.EliminarVenta(id);
            return NoContent();
        }
    }
}