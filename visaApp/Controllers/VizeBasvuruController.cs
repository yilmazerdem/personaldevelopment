using Microsoft.AspNetCore.Mvc;
using Npgsql;
using visaApp.Models;
using visaApp.Service;

namespace visaApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VizeBasvuruController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public VizeBasvuruController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("*HANGİ ALANLARI İSTECEK İSEK ALANLARI İSTEYEREK SAVE DB SERVİCE GÖNDERİCEZ*")]
        public async Task<IActionResult> SubmitBasvuru([FromBody] VizeBasvuru basvuru,ISaveDbService _saveDbService)
        {
            try
            {
                bool result = await _saveDbService.SaveDbServicelog();

                return Ok(new { message = "Başvuru başarıyla kaydedildi." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Bir hata oluştu.", error = ex.Message });
            }
        }
    }
}
