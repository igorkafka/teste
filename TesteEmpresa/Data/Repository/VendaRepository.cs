using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TesteEmpresa.Data.Context;
using TesteEmpresa.Interfaces;
using TesteEmpresa.Models;

namespace TesteEmpresa.Data.Repository
{
    public class VendaRepositroy : Repository<Venda>, IVendaRepository
    {
        public VendaRepositroy(DbTesteContext context) : base(context) { }

        public async Task<IEnumerable<Venda>> PesquisarVenda(string descricao)
        {
            return await Db.Vendas.Include(x => x.Cliente).Include(x => x.Produto).Where(x => x.Cliente.Nome.Contains(descricao) || x.Produto.Nome.Contains(descricao)).ToListAsync();
        }
    }
}