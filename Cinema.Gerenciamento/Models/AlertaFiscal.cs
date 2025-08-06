using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Gerenciamento.Models
{
    public class AlertaFiscal
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
        public DateTime DataAlerta { get; set; }

        [Required]
        public string Status { get; set; } // Ex: "Aberto", "Verificado", "Falso"
    }
}