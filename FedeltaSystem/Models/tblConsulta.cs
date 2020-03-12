using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FedeltaSystem.Models
{
    public class tblConsultas
    {
        [Key]
        public int IdConsulta { get; set; }

    /*------------------------------------------------------------------*/
    [Required(ErrorMessage = "Este campo es obligatorio!")]
    [Display(Name = "Fecha de Consulta")]
    public DateTime FechaConsulta { get; set; }

    /*------------------------------------------------------------------*/
    [Required(ErrorMessage = "Este campo es obligatorio!")]
    public double Peso { get; set; }

    /*------------------------------------------------------------------*/
    [Required(ErrorMessage = "Este campo es obligatorio!")]
    public double Temperatura { get; set; }

    /*------------------------------------------------------------------*/
    [DataType(DataType.MultilineText)]
    public string Diagnostico { get; set; }

    /*------------------------------------------------------------------*/
    [DataType(DataType.MultilineText)]
    public string Observaciones { get; set; }


    //Relaciones
    /*------------------------------------------------------------------*/
    [Display(Name = "Paciente")]
    public int IdPaciente { get; set; }
        public virtual tblPacientes Paciente { get; set; }


    }
}