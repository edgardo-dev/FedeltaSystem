namespace FedeltaSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Base2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCitas",
                c => new
                    {
                        IdCita = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Descripcion = c.String(),
                        Estado = c.String(),
                        Paciente = c.String(),
                    })
                .PrimaryKey(t => t.IdCita);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblCitas");
        }
    }
}
