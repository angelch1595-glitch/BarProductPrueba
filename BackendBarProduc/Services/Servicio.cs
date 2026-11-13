using BackendBarProduc.Repositories;
using BackendBarProduc.Models;

namespace BackendBarProduc.Services
{
    public class Servicio : IServicio
    {
        private readonly IRepositorio _repo;

        public Servicio(IRepositorio repo)
        {
            _repo = repo;
        }

        public Task<List<Usuario>> ObtenerUsuariosAsync()
        {
            return _repo.ObtenerUsuariosAsync();
        }

        public Task<Usuario?> ObtenerUsuarioPorIdAsync(int id)
        {
            return _repo.ObtenerUsuarioPorIdAsync(id);
        }

        public Task<Usuario> CrearUsuarioAsync(Usuario usuario)
        {
            return _repo.CrearUsuarioAsync(usuario);
        }

        public Task<bool> ActualizarUsuarioAsync(Usuario usuario)
        {
            return _repo.ActualizarUsuarioAsync(usuario);
        }

        public Task<bool> EliminarUsuarioAsync(int id)
        {
            return _repo.EliminarUsuarioAsync(id);
        }
    }
}