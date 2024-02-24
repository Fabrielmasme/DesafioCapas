using WebApi.DTOs;
using WebApi.models;

namespace WebApi.Mapper
{
    public class UsuarioMapper
    {
        public static Usuario MappearAVentas(UsuarioDTO dto)
        {
            Usuario usuarios = new Usuario();

            usuarios.Nombre = dto.Nombre;
            usuarios.Apellido = dto.Apellido;
            usuarios.NombreUsuario = dto.NombreUsuario;
            usuarios.Mail = dto.Mail;

            return usuarios;
        }

        public static UsuarioDTO MappearAVentasDTO(UsuarioDTO usuarios) 
        {
            UsuarioDTO dto = new UsuarioDTO();
            dto.Nombre = dto.Nombre;
            dto.Apellido = dto.Apellido;
            dto.NombreUsuario = dto.NombreUsuario;
            dto.Mail = dto.Mail;

            return dto;
        }
    }
}