using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Gerenciamento.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SessaoId { get; set; }
        [ForeignKey("SessaoId")]
        public virtual Sessao Sessao { get; set; }

        [Required]
        public int PoltronaId { get; set; }
        [ForeignKey("PoltronaId")]
        public virtual Poltrona Poltrona { get; set; }

        [Required]
        public DateTime DataReserva { get; set; }

        [Required]
        public string ClienteNome { get; set; } // Ou um Id de usuário, se tivermos autenticação de cliente
        public string StatusReserva { get; set; } // Ex: "Confirmada", "Cancelada", "Ocupada"
    }
}