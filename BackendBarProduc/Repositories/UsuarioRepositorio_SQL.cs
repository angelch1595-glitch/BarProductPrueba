using BackendBarProduc.Data;
using BackendBarProduc.Models;
using Microsoft.EntityFrameworkCore;
namespace BackendBarProduc.Repositories
{
    public class UsuarioRepositorio_SQL:IRepositorio
    {

        private readonly UsuarioDbContext _context;
        public UsuarioRepositorio_SQL(UsuarioDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> ObtenerUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> ObtenerUsuarioPorIdAsync(int id)
        {
            return await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.IdUsuario == id);
        }

        public async Task<Usuario> CrearUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> ActualizarUsuarioAsync(Usuario usuario)
        {
            var usuarioExistente = await _context.Usuarios.FindAsync(usuario.IdUsuario);
            if (usuarioExistente == null)
            {
                return false;
            }
            usuarioExistente.Nombre = usuario.Nombre;
            usuarioExistente.Apellido = usuario.Apellido;
            usuarioExistente.Correo = usuario.Correo;
            usuarioExistente.Contraseña = usuario.Contraseña;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarUsuarioAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }

    }


}
