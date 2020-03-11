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

       [Required(ErrorMessage ="Este campo es obligatorio!")]
       public string Usuario { get; set; }

        [Required(ErrorMessage ="Este campo esobligatorio!")]
        public string Clave { get; set; }


        //Relaciones Empleados
        [Display(Name ="Empleado")]
        public int IdEmpleado { get; set; }
        public virtual tblEmpleados Empleados { get; set; }

        //Relaciones Roles
        [Display(Name ="Rol")]
        public int IdRol { get; set; }
        public virtual tblRoles Roles { get; set; }
    }
}