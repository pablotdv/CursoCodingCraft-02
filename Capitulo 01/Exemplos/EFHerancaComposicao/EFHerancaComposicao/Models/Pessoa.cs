using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EFHerancaComposicao.Models
{
    [Table("Pessoas")]
    public class Pessoa
    {
        [Key]
        public Guid PessoaId { get; set; }

        [Required]
        [MaxLength(18)]
        [Index(IsUnique = true)]
        //[CpfCnpj]
        public string CpfCnpj { get; set; }

        [Required]
        public String NomeOuRazaoSocial { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }
    }
}