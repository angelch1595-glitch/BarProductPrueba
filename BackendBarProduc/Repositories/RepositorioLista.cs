using BackendBarProduc.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace BackendBarProduc.Repositories
{
    public class RepositorioLista 
    {
        private List<Usuario> ListaUsuarios;
        public RepositorioLista()
        {
            ListaUsuarios = new List<Usuario>
            {
                new Usuario { IdUsuario = 1, Nombre = "Juan", Apellido = "Pérez", Correo = "juan.perez@example.com" },
                new Usuario { IdUsuario = 2, Nombre = "María", Apellido = "Gómez", Correo = "maria.gomez@example.com" },
                new Usuario { IdUsuario = 3, Nombre = "Pedro", Apellido = "López", Correo = "pedro.lopez@example.com" },
                new Usuario { IdUsuario = 4, Nombre = "Ana", Apellido = "Martínez", Correo = "ana.martinez@example.com" },
            };
        }

        public List<Usuario> ObtenerUsuarios() {
            return ListaUsuarios;
        }

        public Usuario ObtenerUsuarioPorId(int id) {
            return ListaUsuarios.FirstOrDefault(x => x.IdUsuario == id);
        }

        public void AgregarUsuario(Usuario Usuario) {
            ListaUsuarios.Add(Usuario);
        }

        public void ActualizarUsuario(int id, Usuario usuario) {
            Usuario usuarioEncontrado = ListaUsuarios.FirstOrDefault(x => x.IdUsuario == id);
            if (usuarioEncontrado != null) {
                usuarioEncontrado.Nombre = usuario.Nombre;
                usuarioEncontrado.Apellido= usuario.Apellido;
                usuarioEncontrado.Correo = usuario.Correo;
                usuarioEncontrado.Contraseña = usuario.Contraseña;

            }
        
        }
        public void EliminarUsuario(int id) {
            Usuario usuarioEncontrado = ListaUsuarios.FirstOrDefault(x => x.IdUsuario == id);
            if (usuarioEncontrado != null) { 
            ListaUsuarios.Remove(usuarioEncontrado);
            }

        }
    } 
}