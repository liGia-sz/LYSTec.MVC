using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Gerenciamento.Models
{
    public class Sessao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime HorarioInicio { get; set; }

        // Chave estrangeira para o Filme
        public int FilmeId { get; set; }
        [ForeignKey("FilmeId")]
        public virtual Filme Filme { get; set; }

        // Chave estrangeira para a Sala
        public int SalaId { get; set; }
        [ForeignKey("SalaId")]
        public virtual Sala Sala { get; set; }

        // Relacionamentos
        public virtual ICollection<Reserva> Reservas { get; set; }
        public virtual ICollection<AlertaFiscal> AlertasFiscais { get; set; }
    }
}