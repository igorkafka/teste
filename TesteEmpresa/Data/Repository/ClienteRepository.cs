using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteEmpresa.Data.Context;
using TesteEmpresa.Interfaces;
using TesteEmpresa.Models;

namespace TesteEmpresa.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DbTesteContext context) : base(context) { }
    }
}