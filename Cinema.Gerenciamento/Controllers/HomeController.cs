using Microsoft.AspNetCore.Mvc;
using Cinema.Gerenciamento.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Gerenciamento.Controllers
{
    public class HomeController : Controller
    {
        private readonly CinemaDbContext _context;

        public HomeController(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // 1. Número de alertas fiscais pendentes
            ViewBag.AlertasPendentes = await _context.AlertasFiscais
                .CountAsync(a => a.Status == "Aberto");

            // 2. Próximas sessões (ex: as 5 sessões mais próximas)
            var proximasSessoes = await _context.Sessoes
                .Include(s => s.Filme)
                .Include(s => s.Sala)
                .Where(s => s.HorarioInicio >= System.DateTime.Now)
                .OrderBy(s => s.HorarioInicio)
                .Take(5)
                .ToListAsync();

            // 3. A taxa de ocupação da última sessão (exemplo de lógica)
            var ultimaSessao = await _context.Sessoes
                .OrderByDescending(s => s.HorarioInicio)
                .FirstOrDefaultAsync();
            
            if (ultimaSessao != null)
            {
                var reservasUltimaSessao = await _context.Reservas
                    .CountAsync(r => r.SessaoId == ultimaSessao.Id);
                var capacidadeSala = await _context.Salas
                    .Where(s => s.Id == ultimaSessao.SalaId)
                    .Select(s => s.CapacidadeTotal)
                    .FirstOrDefaultAsync();

                if (capacidadeSala > 0)
                {
                    ViewBag.TaxaOcupacao = (double)reservasUltimaSessao / capacidadeSala * 100;
                }
            }
            else
            {
                ViewBag.TaxaOcupacao = 0.0;
            }

            return View(proximasSessoes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}