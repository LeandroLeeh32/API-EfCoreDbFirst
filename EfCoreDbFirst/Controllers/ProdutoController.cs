using EfCoreDbFirst.Infrastructure.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EfCoreDbFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly leandroDbContext _context;

        public ProdutoController(leandroDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProtudo()
        {
            return Ok(await _context.TbPessoas.ToListAsync());
        }
    }
}
