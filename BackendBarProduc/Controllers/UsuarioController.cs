using BackendBarProduc.Models;
using BackendBarProduc.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendBarProduc.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IRepositorio _repo;

        public UsuarioController(IRepositorio repo)
        {
            _repo = repo;
        }

        // Ver todos los usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await _repo.ObtenerUsuariosAsync();
            return Ok(usuarios);
        }

        // Ver un usuario por ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> GetUsuarioById(int id)
        {
            var usuario = await _repo.ObtenerUsuarioPorIdAsync(id);

            if (usuario == null)
            {
                return NotFound("Usuario no encontrado");
            }

            return Ok(usuario);
        }

        // Agregar un usuario
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Usuario>> AddUsuario(Usuario usuario)
        {
            var usuarioCreado = await _repo.CrearUsuarioAsync(usuario);

            return CreatedAtAction(
                nameof(GetUsuarioById),
                new { id = usuarioCreado.IdUsuario },
                usuarioCreado);
        }

        // Eliminar un usuario
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var eliminado = await _repo.EliminarUsuarioAsync(id);

            if (!eliminado)
            {
                return NotFound("Usuario no encontrado");
            }

            return NoContent();
        }

        // Actualizar un usuario
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUsuario(int id, Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return BadRequest(
                    "El ID de la URL no coincide con el ID del usuario");
            }

            var actualizado = await _repo.ActualizarUsuarioAsync(usuario);

            if (!actualizado)
            {
                return NotFound("Usuario no encontrado");
            }

            return NoContent();
        }
    }
}