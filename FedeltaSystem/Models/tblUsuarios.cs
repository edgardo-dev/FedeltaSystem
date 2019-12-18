using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FedeltaSystem.Models
{
    public class tblUsuarios
    {
        [Key]
        public int IdUsuario { get; set; }

        public string Usuario { get; set; }


        public string Clave { get; set; }


        //Relaciones Empleados
        public int IdEmpleado { get; set; }
        public virtual tblEmpleados Empleados { get; set; }

        //Relaciones Roles
        public int IdRol { get; set; }
        public virtual tblRoles Roles { get; set; }
    }
}