namespace TesteEmpresa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClienteId = c.Guid(nullable: false),
                        ProdutoId = c.Guid(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        ValorUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Data = c.DateTime(nullable: false),
                        ValorTota = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.ProdutoId);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(),
                        ValorUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendas", "ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.Vendas", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Vendas", new[] { "ProdutoId" });
            DropIndex("dbo.Vendas", new[] { "ClienteId" });
            DropTable("dbo.Produtoes");
            DropTable("dbo.Vendas");
            DropTable("dbo.Clientes");
        }
    }
}
