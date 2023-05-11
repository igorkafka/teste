using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteEmpresa.Models;

namespace TesteEmpresa.Interfaces
{
    public interface IVendaRepository : IRepository<Venda>
    {
        Task<IEnumerable<Venda>> PesquisarVenda(string descricao);
    }
}
