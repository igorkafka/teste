using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteEmpresa.Models
{
    public class Cliente : Entity
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        public virtual ICollection<Venda> Vendas { get; set; }
    }
}