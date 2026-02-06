using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Arac_Kiralama.API.Models;

namespace Arac_Kiralama.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SozlesmelerController : ControllerBase
    {
        private readonly AracKiralamaDbContext _context;

        public SozlesmelerController(AracKiralamaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSozlesmeler()
        {
            return Ok(await _context.Sozlesme.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSozlesme(int id)
        {
            var sozlesme = await _context.Sozlesme.FindAsync(id);

            if (sozlesme == null)
            {
                return NotFound("Sözleşme bulunamadı.");
            }
            return Ok(sozlesme);
        }

        [HttpPost]
        public async Task<IActionResult> SozlesmeEkle(Sozlesme yeniSozlesme)
        {   
            _context.Sozlesme.Add(yeniSozlesme);
            await _context.SaveChangesAsync();
            return Ok(yeniSozlesme);
        }

        [HttpPut]
        public async Task<IActionResult> SozlesmeGuncelle(Sozlesme gelenVeri)
        {
            var dbdekiSozlesme = await _context.Sozlesme.FindAsync(gelenVeri.Id);

            if (dbdekiSozlesme == null)
            {
                return NotFound("Güncellenecek sözleşme bulunamadı.");
            }

            dbdekiSozlesme.Tc = gelenVeri.Tc;
            dbdekiSozlesme.Adsoyad = gelenVeri.Adsoyad;
            dbdekiSozlesme.Telefon = gelenVeri.Telefon;
            dbdekiSozlesme.Ehliyetno = gelenVeri.Ehliyetno;
            dbdekiSozlesme.ETarih = gelenVeri.ETarih;
            dbdekiSozlesme.Plaka = gelenVeri.Plaka;
            dbdekiSozlesme.Marka = gelenVeri.Marka;
            dbdekiSozlesme.Modeladi = gelenVeri.Modeladi;
            dbdekiSozlesme.Modelyili = gelenVeri.Modelyili;
            dbdekiSozlesme.Renk = gelenVeri.Renk;
            dbdekiSozlesme.Kirasekli = gelenVeri.Kirasekli;
            dbdekiSozlesme.Kiraucreti = gelenVeri.Kiraucreti;
            dbdekiSozlesme.Gun = gelenVeri.Gun;
            dbdekiSozlesme.Tutar = gelenVeri.Tutar;
            dbdekiSozlesme.Ctarih = gelenVeri.Ctarih;
            dbdekiSozlesme.Dtarih = gelenVeri.Dtarih;

            await _context.SaveChangesAsync();
            return Ok("Sözleşme güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SozlesmeSil(int id)
        {
            var silinecekSozlesme = await _context.Sozlesme.FindAsync(id);

            if (silinecekSozlesme == null)
            {
                return NotFound("Silinecek sözleşme bulunamadı.");
            }

            _context.Sozlesme.Remove(silinecekSozlesme);
            await _context.SaveChangesAsync();
            return Ok("Sözleşme silindi.");
        }
    }
}
