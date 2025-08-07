using Cinema.Gerenciamento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Gerenciamento.Controllers
{
    public class AlertaFiscalController : Controller
    {
        private readonly CinemaDbContext _context;

        public AlertaFiscalController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET: AlertaFiscal
        public async Task<IActionResult> Index()
        {
            // Busca apenas os alertas que ainda não foram resolvidos
            var alertasPendentes = await _context.AlertasFiscais
                .Include(a => a.Sessao)
                .Include(a => a.Poltrona)
                .Where(a => a.Status == "Aberto")
                .ToListAsync();

            return View(alertasPendentes);
        }

        // POST: AlertaFiscal/Resolver/5
        [HttpPost]
        public async Task<IActionResult> Resolver(int id)
        {
            var alerta = await _context.AlertasFiscais.FindAsync(id);
            if (alerta == null)
            {
                return NotFound();
            }

            alerta.Status = "Resolvido";
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Exemplo de uma Action para um Alerta vindo do App Mobile (API)
        [HttpPost]
        [Route("api/alerta")]
        public async Task<IActionResult> RegistrarAlerta([FromBody] AlertaFiscal alerta)
        {
            if (alerta == null)
            {
                return BadRequest();
            }

            // Adapte a lógica para a sua necessidade
            alerta.DataAlerta = System.DateTime.Now;
            alerta.Status = "Aberto";
            _context.AlertasFiscais.Add(alerta);
            await _context.SaveChangesAsync();

            return Ok(alerta);
        }
    }
}