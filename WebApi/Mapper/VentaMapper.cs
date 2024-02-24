using WebApi.DTOs;
using WebApi.models;

namespace WebApi.Mapper
{
    public class VentaMapper
    {
        public static Venta MappearAVentas(VentasDTO dto)
        {
            Venta ventas = new Venta();
            ventas.Comentarios= dto.Comentarios;
            ventas.IdUsuario = dto.IdUsuario;

            return ventas;
        }

        public static VentasDTO MappearAVentasDTO(VentasDTO ventas)
        {
            VentasDTO dto = new VentasDTO();
            dto.Comentarios = dto.Comentarios;
            dto.IdUsuario = dto.IdUsuario;

            return dto;
        }
    }
}