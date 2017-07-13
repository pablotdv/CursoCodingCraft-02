using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFHerancaComposicao.Models
{
    public class Cliente
    {
        [Key, ForeignKey("Pessoa")]
        public Guid PessoaId { get; set; }

        public TipoCliente TipoCliente { get; set; }

        public virtual Pessoa Pessoa { get; set; }

    }
}