namespace FedeltaSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionParaValidacionesTRTUTE : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblEmpleados", "NombreEmpleado", c => c.String(nullable: false));
            AlterColumn("dbo.tblEmpleados", "ApellidoEmpleado", c => c.String(nullable: false));
            AlterColumn("dbo.tblEmpleados", "Telefono", c => c.String(nullable: false));
            AlterColumn("dbo.tblRoles", "Rol", c => c.String(nullable: false));
            AlterColumn("dbo.tblUsuarios", "Usuario", c => c.String(nullable: false));
            AlterColumn("dbo.tblUsuarios", "Clave", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblUsuarios", "Clave", c => c.String());
            AlterColumn("dbo.tblUsuarios", "Usuario", c => c.String());
            AlterColumn("dbo.tblRoles", "Rol", c => c.String());
            AlterColumn("dbo.tblEmpleados", "Telefono", c => c.String());
            AlterColumn("dbo.tblEmpleados", "ApellidoEmpleado", c => c.String());
            AlterColumn("dbo.tblEmpleados", "NombreEmpleado", c => c.String());
        }
    }
}
