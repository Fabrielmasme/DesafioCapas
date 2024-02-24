using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_CoderHouse.Service;
using WebApi.database;
using WebApi.DTOs;
using WebApi.models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : Controller
    {
        private readonly coderhouse context;
        private readonly UsuarioService _usuarioService;

        public UsuarioController(coderhouse coderHouse, UsuarioService usuarioService)
        {
            this.context = coderHouse;
            this._usuarioService = usuarioService;
        }

        [HttpGet]
        public List<Usuario> ObtenerListadoDeUsuarios()
        {
            return _usuarioService.ObtenerTodosLosUsuarios();
        }

        [HttpGet("{nombreUsuario}")]
        public ActionResult<Usuario> GetUsuarioPorNombreUsuario(string nombreUsuario)
        {
            var usuario = UsuarioService.ObtenerUsuarioPorNombreUsuario(nombreUsuario);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }


        [HttpPut("{id}")]
        public IActionResult ActualizarUsuario(int id, UsuarioDTO usuarioDTO)
        {
            if (id != usuarioDTO.Id)
            {
                return BadRequest();
            }

            var usuario = new Usuario
            {
                Id = usuarioDTO.Id,
                Nombre = usuarioDTO.Nombre,
                NombreUsuario = usuarioDTO.NombreUsuario,
                Apellido = usuarioDTO.Apellido,
                Mail = usuarioDTO.Mail
            };

            var usuarioActualizado = UsuarioService.ActualizarUsuario(usuario);
            if (usuarioActualizado == null)
            {
                return NotFound();
            }
            return Ok(usuarioActualizado);
        }

    }
}