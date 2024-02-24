using WebApi.database;
using WebApi.models;

namespace Proyecto_CoderHouse.Service
{
    public class UsuarioService
    {
        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            using (coderhouse context = new coderhouse())
            {
                List<Usuario> usuarios = context.Usuarios.ToList();

                return usuarios;
            }

        }

        internal static Usuario ObtenerUsuarioPorNombreUsuario(string nombreUsuario)
        {
            using (coderhouse context = new coderhouse())
            {

                Usuario? usuarioBuscado = context.Usuarios.Where(u => u.NombreUsuario == nombreUsuario).FirstOrDefault();
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

        internal static bool ActualizarUsuario(Usuario usuario)
        {
            using (coderhouse context = new coderhouse())
            {
                Usuario? usuarioBuscado = context.Usuarios.Where(u => u.Id == usuario.Id).FirstOrDefault();
                usuarioBuscado.Nombre = usuario.Nombre;
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