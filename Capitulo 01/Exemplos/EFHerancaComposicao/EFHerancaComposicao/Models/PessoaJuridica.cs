using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFHerancaComposicao.Models
{
    [Table("PessoasJuridicas")]
    public class PessoaJuridica : Pessoa
    {
        public String NomeFantasia { get; set; }

    }
}