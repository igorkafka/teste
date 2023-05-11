namespace TesteEmpresa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vendas", "ValorTota", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vendas", "ValorTota", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
