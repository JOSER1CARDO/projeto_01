using System.ComponentModel.DataAnnotations;

namespace Projeto02.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

    }
}
