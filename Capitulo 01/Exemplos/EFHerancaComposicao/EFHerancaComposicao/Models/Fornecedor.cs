using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFHerancaComposicao.Models
{
    [Table("Fornecedores")]
    public class Fornecedor
    {
        [Key, ForeignKey("Pessoa")]
        public Guid PessoaId { get; set; }

        public TipoFornecedor TipoFornecedor { get; set; }

        public virtual Pessoa Pessoa { get; set; }

    }
}