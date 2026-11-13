using BackendBarProduc.Data;
using BackendBarProduc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendBarProduc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProveedoresController : ControllerBase
    {
        private readonly UsuarioDbContext _context;

        public ProveedoresController(UsuarioDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Proveedor>> CrearProveedor([FromBody] Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();

            return StatusCode(201, proveedor);
        }
    }
}
