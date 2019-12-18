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

        public string NombreEmpleado { get; set; }

        public string ApellidoEmpleado { get; set; }
        public string Telefono { get; set; }

        public string Direccion { get; set; }



    }
}