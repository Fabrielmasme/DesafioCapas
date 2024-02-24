using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_CoderHouse.Service;
using WebApi.database;
using WebApi.models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/usuarios")]

    public class UsuarioController : Controller
    {
        private coderhouse context;
        private UsuarioService _usuarioService;

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
    }

}