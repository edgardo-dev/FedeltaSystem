using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FedeltaSystem.Models
{
    public class tblCitas
    {
        [Key]
        public int IdCita { get; set; }
        public DateTime Fecha { get; set; }

    /*------------------------------------------------------------------*/
    [DataType(DataType.MultilineText)]
    public string Descripcion { get; set; }

    /*------------------------------------------------------------------*/
    [Required(ErrorMessage ="Este campo es obligatorio!")]
        public string Estado { get; set; }

    /*------------------------------------------------------------------*/
    [Required(ErrorMessage ="Este campo es obligatorio!")]
    public string Paciente { get; set; }

    }
}