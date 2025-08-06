using Microsoft.EntityFrameworkCore;

namespace Cinema.Gerenciamento.Models
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options)
        {
        }

        // Propriedades DbContext para cada entidade
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Poltrona> Poltronas { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<AlertaFiscal> AlertasFiscais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Opcional: Adicione configurações adicionais aqui, como chaves compostas ou índices.
            // Por exemplo, para garantir a unicidade de uma combinação de campos.
        }
    }
}