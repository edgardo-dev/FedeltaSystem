using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FedeltaSystem.Models
{
    public class tblResponsables
    {
        [Key]
        public int IdResponsable { get; set; }
        public string NombreResponsable { get; set; }
        public string ApellidoResponsable { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

    }
}