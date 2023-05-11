using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using TesteEmpresa.Models;

namespace TesteEmpresa.Data.Context
{
    public class DbTesteContext: DbContext
    {
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venda>()
             .HasKey(v => v.Id);

            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Produto>()
                .HasKey(p => p.Id); ;

            modelBuilder.Entity<Venda>()
                .HasRequired(v => v.Cliente)
                .WithMany(c => c.Vendas)
                .HasForeignKey(v => v.ClienteId);

            modelBuilder.Entity<Venda>()
                .HasRequired(v => v.Produto)
                .WithMany(p => p.Vendas)
                .HasForeignKey(v => v.ProdutoId);

            modelBuilder.Entity<Venda>()
                .Property(v => v.ValorTota);
        }
    }
}