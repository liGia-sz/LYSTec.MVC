using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Gerenciamento.Models
{
    public class Sala
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O número da sala é obrigatório.")]
        public int Numero { get; set; }

        [Required]
        public int CapacidadeTotal { get; set; }

        // Propriedades de navegação para os relacionamentos
        public virtual ICollection<Poltrona> Poltronas { get; set; }
        public virtual ICollection<Sessao> Sessoes { get; set; }
    }
}