using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FedeltaSystem.Models
{
    public class tblEmpleados
    {

        [Key]
        public int IdEmpleado { get; set; }

    
    /*-----------------------------------------------------------------*/
      [Display(Name ="Nombre Empleado")]
      [Required(ErrorMessage ="Este campo es obligatorio!")]
        public string NombreEmpleado { get; set; }

    /*-----------------------------------------------------------------*/
      [Display(Name ="Apellido Empleado")]
      [Required(ErrorMessage ="Este campo es obligatorio!")]
        public string ApellidoEmpleado { get; set; }

    
    /*-----------------------------------------------------------------*/
      [Required(ErrorMessage ="Este campo es obligatorio!")]
      [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

    
    /*-----------------------------------------------------------------*/
    [DataType(DataType.MultilineText)]
        public string Direccion { get; set; }



    }
}