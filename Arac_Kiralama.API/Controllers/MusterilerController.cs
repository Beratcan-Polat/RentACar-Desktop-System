using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Arac_Kiralama.API.Models;

namespace Arac_Kiralama.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusterilerController : ControllerBase
    {
        private readonly AracKiralamaDbContext _context;

        public MusterilerController(AracKiralamaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMusteriler()
        {
            return Ok(await _context.Musteri.ToListAsync());
        }

        [HttpGet("{tc}")]
        public async Task<IActionResult> GetMusteri(string tc)
        {
            var musteri = await _context.Musteri.FindAsync(tc);

            if (musteri == null)
            {
                return NotFound("Müşteri bulunamadı.");
            }
            return Ok(musteri);
        }

        [HttpPost]
        public async Task<IActionResult> MusteriEkle(Musteri yeniMusteri)
        {
            if (await _context.Musteri.AnyAsync(m => m.Tc == yeniMusteri.Tc))
            {
                return BadRequest("Bu TC kimlik numarası ile kayıtlı müşteri zaten var!");
            }

            _context.Musteri.Add(yeniMusteri);
            await _context.SaveChangesAsync();
            return Ok(yeniMusteri);
        }

        [HttpPut]
        public async Task<IActionResult> MusteriGuncelle(Musteri gelenVeri)
        {
            var dbdekiMusteri = await _context.Musteri.FindAsync(gelenVeri.Tc);

            if (dbdekiMusteri == null)
            {
                return NotFound("Güncellenecek müşteri bulunamadı.");
            }

            dbdekiMusteri.AdSoyad = gelenVeri.AdSoyad;
            dbdekiMusteri.Telefon = gelenVeri.Telefon;
            dbdekiMusteri.Adres = gelenVeri.Adres;
            dbdekiMusteri.Email = gelenVeri.Email;

            await _context.SaveChangesAsync();
            return Ok("Müşteri güncellendi.");
        }

        [HttpDelete("{tc}")]
        public async Task<IActionResult> MusteriSil(string tc)
        {
            var silinecekMusteri = await _context.Musteri.FindAsync(tc);

            if (silinecekMusteri == null)
            {
                return NotFound("Silinecek müşteri bulunamadı.");
            }

            _context.Musteri.Remove(silinecekMusteri);
            await _context.SaveChangesAsync();
            return Ok("Müşteri silindi.");
        }
    }
}
