using WebApi.database;
using WebApi.models;

namespace Proyecto_CoderHouse.Service
{
    public static class UsuarioService
    {
        internal static List<Usuario> ObtenerTodosLosUsuarios()
        {
            using (coderhouse context = new coderhouse())
            {
                List<Usuario> usuarios = context.Usuarios.ToList();

                return usuarios;
            }

        }

        internal static Usuario ObtenerUsuarioPorId(int id)
        {
            using (coderhouse context = new coderhouse())
            {

               Usuario? usuarioBuscado = context.Usuarios.Where(u=> u.Id==id).FirstOrDefault();
                return usuarioBuscado;
            }
        }

        internal static bool AgregarUsuario(Usuario usuario)
        {
            using (coderhouse context = new coderhouse())
            {
                context.Usuarios.Add(usuario);

                context.SaveChanges();

                return true;
            }
        }

        internal static bool ActualizarUsuarioPorId (Usuario usuario, int id)
        {
            using (coderhouse context = new coderhouse())
            {
                Usuario? usuarioBuscado = context.Usuarios.Where(u => u.Id == id).FirstOrDefault();
                usuarioBuscado.Nombre= usuario.Nombre;
                usuarioBuscado.NombreUsuario = usuario.NombreUsuario;
                usuarioBuscado.Apellido = usuario.Apellido;
                usuarioBuscado.Mail = usuario.Mail;

                context.Usuarios.Update(usuarioBuscado);

                context.SaveChanges();
                return true;
            }
        }

        internal static void EliminarUsuario(int id)
        {
            using (var context = new coderhouse())
            {
                var usuarioBuscado = context.Usuarios.Find(id);

                if (usuarioBuscado == null)
                {
                    context.Usuarios.Remove(usuarioBuscado);

                    context.SaveChanges();
                }
            }
        }
    }
}