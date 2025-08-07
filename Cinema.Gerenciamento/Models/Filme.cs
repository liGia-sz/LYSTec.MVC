using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Gerenciamento.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "A duração é obrigatória.")]
        public int DuracaoMinutos { get; set; }

        [StringLength(500)]
        public string? Descricao { get; set; }

        public string? ImagemUrl { get; set; }

        // Propriedade de navegação para o relacionamento com Sessao
        public virtual ICollection<Sessao> Sessoes { get; set; } = new List<Sessao>();   
         }
}