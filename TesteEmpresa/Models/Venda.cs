using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteEmpresa.Models
{
    public class Venda : Entity
    {
        public Guid ClienteId { get; set; }
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public decimal ValorTota { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Produto Produto { get; set; }
    }
}