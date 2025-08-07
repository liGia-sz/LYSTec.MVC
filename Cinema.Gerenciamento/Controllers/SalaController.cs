using Cinema.Gerenciamento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Gerenciamento.Controllers
{
    public class SalaController : Controller
    {
        private readonly CinemaDbContext _context;

        public SalaController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET: Sala/Mapa/5
        public async Task<IActionResult> Mapa(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Busca a sala com suas poltronas
            var sala = await _context.Salas
                .Include(s => s.Poltronas)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (sala == null)
            {
                return NotFound();
            }

            // Você também pode querer passar as reservas da sessão atual para a View
            // Exemplo (assumindo que você tem um ID de sessão na URL):
            // var sessao = await _context.Sessoes.Include(s => s.Reservas).FirstOrDefaultAsync(s => s.Id == idSessao);
            // ViewBag.Reservas = sessao.Reservas;

            return View(sala);
        }

        // POST (AJAX): Sala/AlterarStatusPoltrona
        [HttpPost]
        public async Task<IActionResult> AlterarStatusPoltrona(int poltronaId, string novoStatus)
        {
            var poltrona = await _context.Poltronas.FindAsync(poltronaId);
            if (poltrona == null)
            {
                return NotFound();
            }

            // Exemplo de como você poderia usar o status (você precisaria adaptar a sua lógica)
            // Poltrona.Status é uma propriedade que você adicionaria na sua Model de Poltrona
            // poltrona.Status = novoStatus; 

            await _context.SaveChangesAsync();
            
            // Retorna um JSON para o JavaScript
            return Json(new { success = true, poltronaId = poltronaId, novoStatus = novoStatus });
        }
    }
}