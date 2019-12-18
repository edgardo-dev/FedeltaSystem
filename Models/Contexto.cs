namespace FedeltaSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Contexto : DbContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'Contexto' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'FedeltaSystem.Models.Contexto' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'Contexto'  en el archivo de configuración de la aplicación.
        public Contexto()
            : base("name=Contexto")
        {
        }

        public DbSet<tblEmpleados> Empleados { get; set; }
        public DbSet<tblRoles> Roles { get; set; }
        public DbSet<tblUsuarios> Usuarios { get; set; }
        public DbSet<tblConsultas> Consultas { get; set; }
        public DbSet<tblResponsables> Responsables { get; set; }
        public DbSet<tblExpedientes> Expedientes { get; set; }
        public DbSet<tblPacientes> Pacientes { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}