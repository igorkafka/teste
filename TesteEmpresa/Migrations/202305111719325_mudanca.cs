namespace TesteEmpresa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mudanca : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Produtoes", "Nome", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produtoes", "Nome", c => c.String());
            AlterColumn("dbo.Clientes", "Nome", c => c.String());
        }
    }
}
