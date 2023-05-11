using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TesteEmpresa.Extensions;

namespace TesteEmpresa.Models
{
    public class Produto : Entity
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Moeda]
        public decimal ValorUnitario { get; set; }

        public virtual ICollection<Venda> Vendas { get; set; }
    }
}