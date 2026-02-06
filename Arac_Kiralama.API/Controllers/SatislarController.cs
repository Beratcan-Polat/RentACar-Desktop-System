using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Arac_Kiralama.API.Models;

namespace Arac_Kiralama.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatislarController : ControllerBase
    {
        private readonly AracKiralamaDbContext _context;

        public SatislarController(AracKiralamaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSatislar()
        {
            return Ok(await _context.Satis.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> SatisEkle(Satis yeniSatis)
        {
            _context.Satis.Add(yeniSatis);
            await _context.SaveChangesAsync();
            return Ok(yeniSatis);
        }
    }
}
