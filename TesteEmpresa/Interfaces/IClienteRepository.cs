using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteEmpresa.Data.Repository;
using TesteEmpresa.Models;

namespace TesteEmpresa.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
    }
}
