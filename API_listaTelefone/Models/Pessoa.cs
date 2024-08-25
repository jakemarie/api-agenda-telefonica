using System.ComponentModel.DataAnnotations;

namespace API_listaTelefone.Models
{
    public class Pessoa
    {
        [Key]
        public long Id { get; set; }
        public required string Nome { get; set; }
    }
}
