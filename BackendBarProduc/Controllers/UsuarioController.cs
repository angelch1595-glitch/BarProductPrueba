using BackendBarProduc.Models;
using BackendBarProduc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendBarProduc.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IServicio _servicio;

        public UsuarioController(IServicio repo)
        {
            _servicio = repo;
        }

        // Ver todos los usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await _servicio.ObtenerUsuariosAsync();
            return Ok(usuarios);
        }

        // Ver un usuario por ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> GetUsuarioById(int id)
        {
            var usuario = await _servicio.ObtenerUsuarioPorIdAsync(id);

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
            var usuarioCreado = await _servicio.CrearUsuarioAsync(usuario);

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
            var eliminado = await _servicio.EliminarUsuarioAsync(id);

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

            var actualizado = await _servicio.ActualizarUsuarioAsync(usuario);

            if (!actualizado)
            {
                return NotFound("Usuario no encontrado");
            }

            return NoContent();
        }
    }
}