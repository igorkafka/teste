using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteEmpresa.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}