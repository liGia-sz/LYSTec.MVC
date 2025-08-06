using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Gerenciamento.Models
{
    public class Poltrona
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O número da poltrona é obrigatório.")]
        public string Numero { get; set; }

        // Chave estrangeira para a Sala
        public int SalaId { get; set; }
        [ForeignKey("SalaId")]
        public virtual Sala Sala { get; set; }

        [Required]
        public string CodigoQR { get; set; }

        // Relacionamento com as reservas
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}