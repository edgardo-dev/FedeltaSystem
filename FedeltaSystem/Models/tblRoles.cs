using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FedeltaSystem.Models
{
    public class tblRoles
    {
        [Key]
        public int IdRol { get; set; }

        [Required(ErrorMessage ="Este campo esobligatorio!")]
    [RegularExpression("^[a-zA-Z]*$", ErrorMessage ="Solo se permite ingresar letras")]
    public string Rol { get; set; }

      [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }


    }
}