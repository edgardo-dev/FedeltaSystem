namespace FedeltaSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblConsultas",
                c => new
                    {
                        IdConsulta = c.Int(nullable: false, identity: true),
                        IdPaciente = c.Int(nullable: false),
                        FechaConsulta = c.DateTime(nullable: false),
                        Peso = c.Double(nullable: false),
                        Temperatura = c.Double(nullable: false),
                        Diagnostico = c.String(),
                        Observaciones = c.String(),
                    })
                .PrimaryKey(t => t.IdConsulta)
                .ForeignKey("dbo.tblPacientes", t => t.IdPaciente, cascadeDelete: true)
                .Index(t => t.IdPaciente);
            
            CreateTable(
                "dbo.tblPacientes",
                c => new
                    {
                        IdPaciente = c.Int(nullable: false, identity: true),
                        NombrePaciente = c.String(),
                        Edad = c.Int(nullable: false),
                        Sexo = c.String(),
                        Raza = c.String(),
                        Especie = c.String(),
                        IdResponsable = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPaciente)
                .ForeignKey("dbo.tblResponsables", t => t.IdResponsable, cascadeDelete: true)
                .Index(t => t.IdResponsable);
            
            CreateTable(
                "dbo.tblResponsables",
                c => new
                    {
                        IdResponsable = c.Int(nullable: false, identity: true),
                        NombreResponsable = c.String(),
                        ApellidoResponsable = c.String(),
                        Direccion = c.String(),
                        Telefono = c.String(),
                    })
                .PrimaryKey(t => t.IdResponsable);
            
            CreateTable(
                "dbo.tblEmpleados",
                c => new
                    {
                        IdEmpleado = c.Int(nullable: false, identity: true),
                        NombreEmpleado = c.String(),
                        ApellidoEmpleado = c.String(),
                        Telefono = c.String(),
                        Direccion = c.String(),
                    })
                .PrimaryKey(t => t.IdEmpleado);
            
            CreateTable(
                "dbo.tblExpedientes",
                c => new
                    {
                        IdExpediente = c.Int(nullable: false, identity: true),
                        NumExpediente = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        IdPaciente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdExpediente)
                .ForeignKey("dbo.tblPacientes", t => t.IdPaciente, cascadeDelete: true)
                .Index(t => t.IdPaciente);
            
            CreateTable(
                "dbo.tblRoles",
                c => new
                    {
                        IdRol = c.Int(nullable: false, identity: true),
                        Rol = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.IdRol);
            
            CreateTable(
                "dbo.tblUsuarios",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false, identity: true),
                        Usuario = c.String(),
                        Clave = c.String(),
                        IdEmpleado = c.Int(nullable: false),
                        IdRol = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.tblEmpleados", t => t.IdEmpleado, cascadeDelete: true)
                .ForeignKey("dbo.tblRoles", t => t.IdRol, cascadeDelete: true)
                .Index(t => t.IdEmpleado)
                .Index(t => t.IdRol);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblUsuarios", "IdRol", "dbo.tblRoles");
            DropForeignKey("dbo.tblUsuarios", "IdEmpleado", "dbo.tblEmpleados");
            DropForeignKey("dbo.tblExpedientes", "IdPaciente", "dbo.tblPacientes");
            DropForeignKey("dbo.tblConsultas", "IdPaciente", "dbo.tblPacientes");
            DropForeignKey("dbo.tblPacientes", "IdResponsable", "dbo.tblResponsables");
            DropIndex("dbo.tblUsuarios", new[] { "IdRol" });
            DropIndex("dbo.tblUsuarios", new[] { "IdEmpleado" });
            DropIndex("dbo.tblExpedientes", new[] { "IdPaciente" });
            DropIndex("dbo.tblPacientes", new[] { "IdResponsable" });
            DropIndex("dbo.tblConsultas", new[] { "IdPaciente" });
            DropTable("dbo.tblUsuarios");
            DropTable("dbo.tblRoles");
            DropTable("dbo.tblExpedientes");
            DropTable("dbo.tblEmpleados");
            DropTable("dbo.tblResponsables");
            DropTable("dbo.tblPacientes");
            DropTable("dbo.tblConsultas");
        }
    }
}
