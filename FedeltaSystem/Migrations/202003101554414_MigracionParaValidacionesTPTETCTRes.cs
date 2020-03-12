namespace FedeltaSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionParaValidacionesTPTETCTRes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblCitas", "Estado", c => c.String(nullable: false));
            AlterColumn("dbo.tblCitas", "Paciente", c => c.String(nullable: false));
            AlterColumn("dbo.tblPacientes", "NombrePaciente", c => c.String(nullable: false));
            AlterColumn("dbo.tblPacientes", "Sexo", c => c.String(nullable: false));
            AlterColumn("dbo.tblPacientes", "Raza", c => c.String(nullable: false));
            AlterColumn("dbo.tblResponsables", "NombreResponsable", c => c.String(nullable: false));
            AlterColumn("dbo.tblResponsables", "ApellidoResponsable", c => c.String(nullable: false));
            AlterColumn("dbo.tblResponsables", "Telefono", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblResponsables", "Telefono", c => c.String());
            AlterColumn("dbo.tblResponsables", "ApellidoResponsable", c => c.String());
            AlterColumn("dbo.tblResponsables", "NombreResponsable", c => c.String());
            AlterColumn("dbo.tblPacientes", "Raza", c => c.String());
            AlterColumn("dbo.tblPacientes", "Sexo", c => c.String());
            AlterColumn("dbo.tblPacientes", "NombrePaciente", c => c.String());
            AlterColumn("dbo.tblCitas", "Paciente", c => c.String());
            AlterColumn("dbo.tblCitas", "Estado", c => c.String());
        }
    }
}
