﻿using System.ComponentModel.DataAnnotations;

namespace API_listaTelefone.Models
{
    public class Telefone
    {
        [Key]
        public long Id { get; set; }
        public int numero { get; set; }
        public required Pessoa pessoa { get; set; }
    }
}
