using System.ComponentModel.DataAnnotations;

namespace API_listaTelefone.Models
{
    public class Telefone
    {
       
            [Key]
            public long Id { get; set; }
            public int Numero { get; set; }
            public long PessoaId { get; set; }
            public required Pessoa Pessoa { get; set; }
        
    }
}
