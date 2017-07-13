using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFHerancaComposicao.Models
{
    [Table("PessoasFisicas")]
    public class PessoaFisica : Pessoa
    {
        [Required]
        public String Rg { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

    }
}