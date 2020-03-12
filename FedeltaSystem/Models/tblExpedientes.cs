using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FedeltaSystem.Models
{
    public class tblExpedientes
    {
        [Key]
        public int IdExpediente { get; set; }

    /*------------------------------------------------------------------*/
    [Required(ErrorMessage = "Este campo es obligatorio!")]
    [Display(Name = "N° Expediente")]
    public int NumExpediente { get; set; }

    /*------------------------------------------------------------------*/
    [Required(ErrorMessage = "Este campo es obligatorio!")]
    [Display(Name = "Fecha de registro")]
    public DateTime FechaCreacion { get; set; }

    //Relacion Pacientes

    /*------------------------------------------------------------------*/

    [Display(Name = "Paciente")]
    public int IdPaciente { get; set; }
        public virtual tblPacientes Paciente { get; set; }


    }
}