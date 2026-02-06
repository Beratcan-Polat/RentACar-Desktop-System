using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Arac_Kiralama.API.Models;

namespace Arac_Kiralama.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AraclarController : ControllerBase
    {
        private readonly AracKiralamaDbContext _context;

        public AraclarController(AracKiralamaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAraclar()
        {
            return Ok(await _context.Arac.ToListAsync());
        }

        [HttpGet("{plaka}")]
        public async Task<IActionResult> GetArac(string plaka)
        {
            var bulunanArac = await _context.Arac.FindAsync(plaka);

            if (bulunanArac == null)
            {
                return NotFound("Bu plakaya sahip araç bulunamadı.");
            }
            return Ok(bulunanArac);
        }

        [HttpPost]
        public async Task<IActionResult> AracEkle(Arac yeniArac)
        {
            if (await _context.Arac.AnyAsync(a => a.Plaka == yeniArac.Plaka))
            {
                return BadRequest("Bu plaka zaten sistemde kayıtlı!");
            }

            _context.Arac.Add(yeniArac);
            await _context.SaveChangesAsync();
            return Ok(yeniArac);
        }

        [HttpPut]
        public async Task<IActionResult> AracGuncelle(Arac gelenVeri)
        {
            var dbdekiArac = await _context.Arac.FindAsync(gelenVeri.Plaka);

            if (dbdekiArac == null)
            {
                return NotFound("Güncellenecek araç bulunamadı (Plaka eşleşmedi).");
            }

            dbdekiArac.Marka = gelenVeri.Marka;
            dbdekiArac.ModelAdi = gelenVeri.ModelAdi;
            dbdekiArac.ModelYili = gelenVeri.ModelYili;
            dbdekiArac.Renk = gelenVeri.Renk;
            dbdekiArac.Km = gelenVeri.Km;
            dbdekiArac.Yakit = gelenVeri.Yakit;
            dbdekiArac.Vites = gelenVeri.Vites;
            dbdekiArac.KiraUcreti = gelenVeri.KiraUcreti;
            dbdekiArac.Resim = gelenVeri.Resim;
            dbdekiArac.Durumu = gelenVeri.Durumu;

            await _context.SaveChangesAsync();
            return Ok("Araç güncellendi.");
        }

        [HttpDelete("{plaka}")]
        public async Task<IActionResult> AracSil(string plaka)
        {
            var silinecekArac = await _context.Arac.FindAsync(plaka);

            if (silinecekArac == null)
            {
                return NotFound("Silinecek araç bulunamadı.");
            }

            _context.Arac.Remove(silinecekArac);
            await _context.SaveChangesAsync();
            return Ok("Araç silindi.");
        }
    }
}